using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.ComponentModel;
using HighSign.Common.Gestures;

namespace HighSign.Common.UI.Forms.Controls
{
	public class GesturePictureBox : PictureBox
	{
		#region Private Instance Fields

		Pen _DrawingPen = null;
		Color _FillColor = Color.White;
		Color _StrokeColor = Color.Gray;
		int _StrokeWidth = 1;
		int _CornerRadius = 10;
		IGesture _Gesture = null;
		Size _GestureSize = default(Size);

		#endregion
		
		#region Constructors

		public GesturePictureBox()
		{
			UpdateDisplay();
		}

		#endregion

		#region Base Method Overrides

		protected override void OnResize(EventArgs e)
		{
			UpdateDisplay();
			
			base.OnResize(e);
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			// We want the rounded rectangle smooth
			pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

			// Draw background rectangle
			Drawing.ImageHelper.DrawRoundedRectangle(pe.Graphics, this.ClientRectangle, _CornerRadius, _DrawingPen, _FillColor);

			// Draw gesture if it exists
			if (_Gesture != null && _GestureSize != default(Size))
			{
				Image centeredImage = Drawing.ImageHelper.AlignImage(Drawing.GestureThumbnail.Create(_Gesture.Points, _GestureSize, true), this.ClientSize, ContentAlignment.MiddleCenter);
				pe.Graphics.DrawImageUnscaled(centeredImage, 0, 0);
			}

			base.OnPaint(pe);
		}

		#endregion

		#region Public Instance Properties

		[Browsable(true)]
		public Color FillColor
		{
			get { return _FillColor; }
			set
			{
				_FillColor = value;
				UpdateDisplay();
			}
		}

		[Browsable(true)]
		public Color StrokeColor
		{
			get { return _StrokeColor; }
			set
			{
				_StrokeColor = value;
				UpdateDisplay();
			}
		}

		[Browsable(true)]
		[DefaultValue(1)]
		public int StrokeWidth
		{
			get { return _StrokeWidth; }
			set
			{
				_StrokeWidth = value;
				UpdateDisplay();
			}
		}

		[Browsable(true)]
		[DefaultValue(10)]
		public int CornerRadius
		{
			get { return _CornerRadius; }
			set
			{
				_CornerRadius = value;
				UpdateDisplay();
			}
		}

		public IGesture Gesture
		{
			get { return _Gesture; }
			set { _Gesture = value; }
		}

		#endregion

		#region Private Instance Methods

		private void UpdateDisplay()
		{
			int gestureWidth = Convert.ToInt32(Math.Floor((float)this.ClientSize.Width * 0.8F));
			int gestureHeight = Convert.ToInt32(Math.Floor((float)this.ClientSize.Height * 0.8F));

			_GestureSize = new Size(gestureWidth, gestureHeight);
			_DrawingPen = new Pen(_StrokeColor, _StrokeWidth);

			Invalidate();
		}

		#endregion
	}
}
