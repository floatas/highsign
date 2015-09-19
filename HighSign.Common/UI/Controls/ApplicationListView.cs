using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using ManagedWinapi.Windows;
using System.IO;
using HighSign.Common.Applications;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace HighSign.Common.UI.Controls
{
	public class ApplicationListView : ListView
	{
		#region Private Instance Fields

		ImageList applicationIcons = new ImageList();
		MatchUsing _MatchUsing = MatchUsing.WindowClass;

		#endregion

		#region Constructors

		public ApplicationListView()
		{
			SetupControl();
		}

		#endregion

		#region Public Instance Properties

		public SystemWindow[] Windows { get; set; }
		public string MatchString { get; set; }
		public MatchUsing MatchUsing
		{
			get { return _MatchUsing; }
			set
			{
				_MatchUsing = value;
				SelectSimilar();
			}
		}
		public ApplicationListViewItem SelectedApplication
		{
			get { return (this.SelectedItems.Count > 0) ? this.SelectedItems[0] as ApplicationListViewItem : null; }
		}

		#endregion

		#region Public Instance Methods

		public void RefreshApplications()
		{
			Clear();
			ThreadPool.QueueUserWorkItem(new WaitCallback(GetValidWindows));
		}

		public void SelectSimilar(string MatchString)
		{
			// Save match string
			this.MatchString = MatchString ?? "";

			// Select all similar applications
			foreach (ListViewItem lItem in this.Items)
			{
				ApplicationListViewItem alvCurrentItem = (ApplicationListViewItem)lItem;

				switch (MatchUsing)
				{
					case MatchUsing.WindowClass:
						lItem.Selected = (alvCurrentItem.WindowClass.ToLower() == this.MatchString.ToLower());

						break;
					case MatchUsing.WindowTitle:
						lItem.Selected = (alvCurrentItem.WindowTitle.ToLower() == this.MatchString.ToLower());

						break;
					case MatchUsing.ExecutableFilename:
						lItem.Selected = (alvCurrentItem.WindowFilename.ToLower() == this.MatchString.ToLower());

						break;
				}
			}

			// Exit if nothing was selected
			if (this.SelectedItems.Count == 0)
				return;

			// Get first selected item
			ApplicationListViewItem alvFirstItem = this.SelectedItems[0] as ApplicationListViewItem;

			// Ensure selected item is visible
			if (alvFirstItem != null)
				alvFirstItem.EnsureVisible();
		}

		public new void Clear()
		{
			this.Items.Clear();
			this.applicationIcons.Images.Clear();
			this.applicationIcons.TransparentColor = Color.Black;
		}

		#endregion

		#region Private Instance Methods

		private void SetupControl()
		{
			// Application Icon ImageList
			this.applicationIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.applicationIcons.ImageSize = new System.Drawing.Size(32, 32);
			this.applicationIcons.TransparentColor = System.Drawing.Color.Transparent;

			// ListView Columns
			ColumnHeader clmAppTitle = new ColumnHeader() { Text = "AppTitle" };
			ColumnHeader clmWindowClassExecutable = new ColumnHeader() { Text = "WindowClassExecutable" };

			// ListView Properties
			this.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { clmAppTitle, clmWindowClassExecutable });
			this.FullRowSelect = true;
			this.HideSelection = false;
			this.LabelWrap = false;
			this.LargeImageList = applicationIcons;
			this.ShowItemToolTips = true;
			this.SmallImageList = applicationIcons;
			this.Sorting = SortOrder.Ascending;
			this.TileSize = new Size(300, 38);
			this.View = View.Tile;

			// Additional properties
			this.MatchUsing = MatchUsing.WindowClass;
		}

		private void GetValidWindows(object state)
		{
			// Get valid running windows
			Windows = SystemWindow.AllToplevelWindows.Where
				(
					w => w.Visible &&	// Must be a visible windows
					w.Title != "" &&	// Must have a window title
					IsProcessAccessible(w.Process) &&
					Path.GetDirectoryName(w.Process.MainModule.FileName) != Application.StartupPath &&	// Must not be a HighSign window
					(w.ExtendedStyle & WindowExStyleFlags.TOOLWINDOW) != WindowExStyleFlags.TOOLWINDOW	// Must not be a tool window
				).ToArray();

			GetValidWindowsComplete();
		}

		private void GetValidWindowsComplete()
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new MethodInvoker(GetValidWindowsComplete));
				return;
			}

			BindWindows(Windows);
			SelectSimilar(this.MatchString);
		}

		private void BindWindows(SystemWindow[] Windows)
		{
			Clear();

			foreach (SystemWindow sWind in Windows)
			{
				ApplicationListViewItem lItem = new ApplicationListViewItem();

				// Todo: Add no icon found image
				Bitmap bMap = sWind.Icon.ToBitmap();
				Bitmap bFinal = new Bitmap(applicationIcons.ImageSize.Width, applicationIcons.ImageSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				Graphics oGraphic = Graphics.FromImage(bFinal);
				oGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				oGraphic.Clear(Color.Transparent);
				oGraphic.DrawImage(bMap, 0, 0, bFinal.Width, bFinal.Height);
				applicationIcons.Images.Add(bFinal);

				// Store identifying information
				lItem.WindowClass = sWind.ClassName;
				lItem.WindowTitle = sWind.Title;
				lItem.WindowFilename = Path.GetFileName(sWind.Process.MainModule.FileName);
				lItem.ApplicationName = sWind.Process.MainModule.FileVersionInfo.FileDescription;
				lItem.Text = sWind.Title;
				lItem.ImageIndex = applicationIcons.Images.Count - 1;

				if (sWind.Title.Length > 40)
				{
					lItem.Text = sWind.Title.Substring(0, 40).Trim() + "...";
					lItem.ToolTipText = sWind.Title;
				}

				lItem.SubItems.Add(new ListViewItem.ListViewSubItem(lItem, String.Format("{0} ({1})", sWind.ClassName, Path.GetFileName(sWind.Process.MainModule.FileName))));

				this.Items.Add(lItem);
			}
		}

		private bool IsProcessAccessible(Process Process)
		{
			try
			{
				ProcessModule module = Process.MainModule;
				return true;
			}
			catch { return false; }
		}

		private void SelectSimilar()
		{
			if (this.SelectedApplication == null)
				return;

			switch (MatchUsing)
			{
				case MatchUsing.WindowClass:
					SelectSimilar(this.SelectedApplication.WindowClass);

					break;
				case MatchUsing.WindowTitle:
					SelectSimilar(this.SelectedApplication.WindowTitle);

					break;
				case MatchUsing.ExecutableFilename:
					SelectSimilar(this.SelectedApplication.WindowFilename);

					break;
			}
		}

		

		#endregion

		#region Base Class Overrides

		protected override void OnMouseUp(MouseEventArgs e)
		{
			SelectSimilar();

			base.OnMouseUp(e);
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			SelectSimilar();

			base.OnKeyUp(e);
		}

		#endregion
	}
}