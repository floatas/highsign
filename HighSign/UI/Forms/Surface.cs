using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using HighSign.Common.Input;
using HighSign.Common.UI;
using ManagedWinapi.Windows;
using Microsoft.Win32;

namespace HighSign.UI.Forms
{
	public partial class Surface : Form
	{
		#region Private Variables

		Color TransparentColor = Color.Fuchsia;
		Graphics SurfaceGraphics = null;
		CompatibilitySurface[] CompatibilitySurfaces = null;
		RenderMode RenderMethod = RenderMode.Standard;
		Pen DrawingPen = null;
		List<PointF> LastStroke = new List<PointF>();
		Size ScreenOffset = default(Size);

		private enum RenderMode
		{
			Compatible,
			Standard
		}

		private class CompatibilitySurface : IDisposable
		{
			public Graphics SurfaceGraphics = null;
			public Size Offset = default(Size);

			public PointF[] OffsetPoints(PointF[] Points)
			{
				return Points.Select(p => PointF.Subtract(p, Offset)).ToArray();
			}

			public void Dispose()
			{
				if (SurfaceGraphics != null)
					SurfaceGraphics.Dispose();
			}
		}

		#endregion

		#region Constructors

		public Surface()
		{
			InitializeForm();

			Input.MouseCapture.Instance.PointCaptured += new PointsCapturedEventHandler(MouseCapture_PointCaptured);
			Input.MouseCapture.Instance.CaptureEnded += new PointsCapturedEventHandler(MouseCapture_CaptureEnded);
			Input.MouseCapture.Instance.CaptureCanceled += new PointsCapturedEventHandler(MouseCapture_CaptureCanceled);
			UI.FormManager.Instance.InstanceRequested += new InstanceEventHandler(FormManager_InstanceRequested);

			// Respond to system event changes by reinitializing the form
			SystemEvents.DisplaySettingsChanged += (o, e) => { InitializeForm(); };
			SystemEvents.UserPreferenceChanged += (o, e) => { InitializeForm(); };
		}

		#endregion

		#region Events

		protected void MouseCapture_PointCaptured(object sender, PointsCapturedEventArgs e)
		{
			if (Properties.Settings.Default.VisualFeedbackWidth > 0 && e.State == CaptureState.Capturing)
				this.DrawSegments(e.Points);
		}

		protected void MouseCapture_CaptureEnded(object sender, PointsCapturedEventArgs e)
		{
			if (Properties.Settings.Default.VisualFeedbackWidth > 0)
				this.EndDraw();
		}

		protected void MouseCapture_CaptureCanceled(object sender, PointsCapturedEventArgs e)
		{
			if (Properties.Settings.Default.VisualFeedbackWidth > 0)
				this.EndDraw();
		}

		protected void FormManager_InstanceRequested(object sender, InstanceEventArgs e)
		{
			// If the options form was requested, wireup to options saved events
			if (e.Instance is Options)
				((Options)e.Instance).OptionsSaved += (o, se) => { InitializeForm(); };
		}

		#endregion

		#region Public Methods

		public void EndDraw()
		{
			ClearSurfaces();
			this.Hide();
		}

		public void DrawSegments(PointF[] Stroke)
		{
			if (RenderMethod == RenderMode.Standard)
			{
				// Ensure that surface is visible
				if (!this.Visible)
				{
					this.TopMost = true;
					this.Show();
				}

				// Create list of points that are new this draw
				List<PointF> NewPoints = new List<PointF>();

				// Get number of points added since last draw including last point of last stroke and add new points to new points list
				int iDelta = Stroke.Count() - LastStroke.Count() + 1;
				NewPoints.AddRange(Stroke.Skip(Stroke.Count() - iDelta).Take(iDelta));

				// Draw new line segments to main drawing surface
				SurfaceGraphics.DrawLines(DrawingPen, NewPoints.Select(p => TranslatePoint(p)).ToArray());

				// Set last stroke to copy of current stroke
				// ToList method creates value copy of stroke list and assigns it to last stroke
				LastStroke = Stroke.ToList();
			}
			else
			{
				foreach (CompatibilitySurface surface in CompatibilitySurfaces)
					surface.SurfaceGraphics.DrawLines(DrawingPen, surface.OffsetPoints(Stroke));
			}
		}

		#endregion

		#region Private Methods

		private void InitializeGraphics()
		{
			if (RenderMethod == RenderMode.Standard)
			{
				// Create graphics to allow drawing on surface form
				SurfaceGraphics = this.CreateGraphics();
				SurfaceGraphics.Clear(TransparentColor);
			}
			else
			{
				// Create graphics for each display using compatibility mode
				CompatibilitySurfaces = Screen.AllScreens.Select(s => new CompatibilitySurface()
					{
						SurfaceGraphics = Graphics.FromHdc(CreateDC(null, s.DeviceName, null, IntPtr.Zero)),
						Offset = new Size(s.Bounds.Location)
					}).ToArray();
			}

			// Create pens using settings from configuration
			InitializePen();
		}

		private void InitializePen()
		{
			DrawingPen = new Pen(Properties.Settings.Default.VisualFeedbackColor, Properties.Settings.Default.VisualFeedbackWidth);
			DrawingPen.StartCap = DrawingPen.EndCap = LineCap.Round;
			DrawingPen.LineJoin = LineJoin.Round;
		}

		private void InitializeForm()
		{
			// Set basic variables
			this.FormBorderStyle = FormBorderStyle.None;
			this.Name = "Surface";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = FormStartPosition.Manual;

			if (DesktopWindowManager.IsCompositionEnabled())
			{
				// This window should be on top of every other window
				this.TopMost = true;

				// Combine monitor screen sizes and set form size to combined size
				Rectangle rOutput = new Rectangle();

				foreach (Screen oScreen in Screen.AllScreens)
					rOutput = Rectangle.Union(rOutput, oScreen.Bounds);

				this.Left = Screen.AllScreens.Min(s => s.Bounds.Left);
				this.Top = Screen.AllScreens.Min(s => s.Bounds.Top);
				this.Width = rOutput.Width;
				this.Height = rOutput.Height;

				// Store offset in class field
				ScreenOffset = new Size(this.Location);

				// Reset transparent color
				this.BackColor = TransparentColor;
				this.TransparencyKey = TransparentColor;

				// Set opacity value
				this.Opacity = GetFormOpacity(HighSign.Properties.Settings.Default.Opacity);

				// We have composition enabled, use standard mode
				RenderMethod = RenderMode.Standard;
			}
			else
			{
				// This window should not be on top, and should be hidden
				this.TopMost = false;
				this.Hide();

				// We don't have composition enabled, we need to render using compatiblity mode
				RenderMethod = RenderMode.Compatible;
			}

			// Update graphics object with new size
			InitializeGraphics();
		}

		private PointF TranslatePoint(PointF Point)
		{
			// Add point offset
			return PointF.Subtract(Point, ScreenOffset);
		}

		private void ClearSurfaces()
		{
			if (RenderMethod == RenderMode.Standard)
			{
				// Nothing to end if the graphics haven't been initialized
				if (SurfaceGraphics != null)
					SurfaceGraphics.Clear(TransparentColor);

				LastStroke.Clear();
			}
			else
				InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
		}

		#endregion

		#region Private Instance Methods

		private float GetFormOpacity(byte Opacity)
		{
			return Convert.ToSingle(Opacity * (1.0f / 255f));
		}

		#endregion

		#region P/Invoke Methods

		[DllImport("gdi32.dll")]
		static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);

		[DllImport("user32.dll")]
		static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

		#endregion

		#region Base Method Overrides

		protected override CreateParams CreateParams
		{
			get
			{
				const int WS_EX_NOACTIVATE = 0x08000000;
				CreateParams myParams = base.CreateParams;
				myParams.ExStyle = myParams.ExStyle | WS_EX_NOACTIVATE;
				return myParams;
			}
		}

		#endregion
	}
}