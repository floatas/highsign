using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using HighSign.Common.UI;
using ManagedWinapi.Windows;
using HighSign.Common.Drawing;

namespace HighSign.UI.Forms
{
	public partial class Options : Form
	{
		#region Private Variables

		Pen _MiniViewPen = null;
		Pen _VisualFeedbackPen = null;
		Color _VisualFeedbackColor = Color.Blue;
		Color _MiniViewColor = Color.Blue;

		#endregion

		#region Constructors

		public Options()
		{
			InitializeComponent();

			// Set icon using icon from resource file
			this.Icon = Icon.FromHandle(Properties.Resources.MouseIcon.GetHicon());

			// Attempt to load settings
			LoadSettings();

			this.Load += new EventHandler(Options_Load);
			this.FormClosing += new FormClosingEventHandler(Options_FormClosing);
			this.picVisualFeedbackExample.Paint += new PaintEventHandler(picVisualFeedbackExample_Paint);
			this.picVisualFeedbackExample.Click += new EventHandler(picVisualFeedbackExample_Click);
			this.picMiniViewExample.Paint += new PaintEventHandler(picMiniViewExample_Paint);
			this.picMiniViewExample.Click += new EventHandler(picMiniViewExample_Click);
			this.tbVisualFeedbackWidth.ValueChanged += new EventHandler(tbVisualFeedbackWidth_ValueChanged);
			this.cmdDataSelectFolder.Click += new EventHandler(cmdDataSelectFolder_Click);
			this.cmdPluginsSelectFolder.Click += new EventHandler(cmdPluginsSelectFolder_Click);
			this.cmdSave.Click += new EventHandler(cmdSave_Click);
			this.cmdCancel.Click += new EventHandler(cmdCancel_Click);
			this.cmdDefault.Click += new EventHandler(cmdDefault_Click);
			this.tbOpacity.ValueChanged += new EventHandler(tbOpacity_ValueChanged);
			//this.txtDataPath.LostFocus += new EventHandler(Path_LostFocus);
			//this.txtPlugins.LostFocus += new EventHandler(Path_LostFocus);
		}

		#endregion

		#region Custom Events

		// Create event to notify subscribers that options have been saved
		public event OptionsSavedEventHandler OptionsSaved;

		protected virtual void OnOptionsSaved()
		{
			if (OptionsSaved != null) OptionsSaved(this, new EventArgs());
		}

		#endregion

		#region Events

		protected void Options_Load(object sender, EventArgs e)
		{
			// Disable gestures while options are open
			Input.MouseCapture.Instance.DisableMouseCapture();

			RefreshPens();
			UpdateVisualFeedbackExample();
			UpdateMiniViewExample();
			DisableIncompatibleControls();
		}

		protected void Options_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Disable gestures while options are open
			Input.MouseCapture.Instance.EnableMouseCapture();
		}

		protected void picVisualFeedbackExample_Paint(object sender, PaintEventArgs e)
		{
			// Enable drawing anti-aliasing
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

			// Redraw rounded rectangle
			ImageHelper.DrawRoundedRectangle(e.Graphics, new Rectangle(0, 0, picVisualFeedbackExample.ClientSize.Width - 1, picVisualFeedbackExample.ClientSize.Height - 1), 11, new Pen(SystemColors.ControlDark, 1), Color.White);

			// Redraw example stroke
			e.Graphics.DrawLine(_VisualFeedbackPen, 15, 40, 40, 15);
		}

		protected void picMiniViewExample_Paint(object sender, PaintEventArgs e)
		{
			// Enable drawing anti-aliasing
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

			// Redraw rounded rectangle
			ImageHelper.DrawRoundedRectangle(e.Graphics, new Rectangle(0, 0, picMiniViewExample.ClientSize.Width - 1, picMiniViewExample.ClientSize.Height - 1), 11, new Pen(SystemColors.ControlDark, 1), Color.White);

			// Redraw example stroke
			e.Graphics.DrawLine(_MiniViewPen, 10, 45, 45, 10);
		}

		protected void picVisualFeedbackExample_Click(object sender, EventArgs e)
		{
			// Set color picker dialog color to current visual feedback color
			cdColorPicker.Color = _VisualFeedbackColor;

			// Show color picker dialog
			if (cdColorPicker.ShowDialog() != DialogResult.OK)
			    return;

			// Change color of visual feedback and refresh example
			_VisualFeedbackColor = cdColorPicker.Color;
			UpdateVisualFeedbackExample();
		}

		protected void picMiniViewExample_Click(object sender, EventArgs e)
		{
			// Set color picker dialog color to current mini view color
			cdColorPicker.Color = _MiniViewColor;

			// Show color picker dialog
			if (cdColorPicker.ShowDialog() != DialogResult.OK)
				return;

			// Change color of mini view and refresh example
			_MiniViewColor = cdColorPicker.Color;
			UpdateMiniViewExample();
		}

		protected void tbVisualFeedbackWidth_ValueChanged(object sender, EventArgs e)
		{
			UpdateVisualFeedbackExample();
		}

		protected void cmdDataSelectFolder_Click(object sender, EventArgs e)
		{
			// Set folder dialog description and path
			fbdFolders.Description = "Please select a folder location where you would like High Sign to watch store its data and configuration settings.";
			fbdFolders.SelectedPath = txtDataPath.Text;

			// Show folder browser dialog
			if (fbdFolders.ShowDialog() != DialogResult.OK)
				return;

			// Set data path to selected user path
			txtDataPath.Text = fbdFolders.SelectedPath;
		}

		protected void cmdPluginsSelectFolder_Click(object sender, EventArgs e)
		{
			// Set folder dialog description
			fbdFolders.Description = "Please select a folder location where you would like High Sign to watch for plugins.";
			fbdFolders.SelectedPath = txtPlugins.Text;

			// Show folder browser dialog
			if (fbdFolders.ShowDialog() != DialogResult.OK)
				return;

			// Set plugins path to selected user path
			txtPlugins.Text = fbdFolders.SelectedPath;
		}

		protected void cmdSave_Click(object sender, EventArgs e)
		{
			if (!SaveSettings())
				return;

			// Everything saved correctly, notify subscribers and exit form
			OnOptionsSaved();
			this.Close();
		}

		protected void cmdCancel_Click(object sender, EventArgs e)
		{
			// Nothing to do, close the form
			this.Close();
		}

		protected void cmdDefault_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to restore settings to their default values?", "Confirm Default Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				Properties.Settings.Default.Reset();
				Properties.Settings.Default.Save();
				LoadSettings();
			}
		}

		protected void Path_LostFocus(object sender, EventArgs e)
		{
			// Validate path
			string sPath = ((TextBox)sender).Text;
			if (!Directory.Exists(sPath))
				MessageBox.Show(String.Format("'{0}'\ndoes not exist", sPath), "Path Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
		}

		protected void tbOpacity_ValueChanged(object sender, EventArgs e)
		{
			UpdateVisualFeedbackExample();
		}

		#endregion

		#region Private Methods

		private bool SaveSettings()
		{
			// Ensure that the user defined paths exist
			if (!Directory.Exists(txtDataPath.Text.Trim()))
			{
				MessageBox.Show("The data storage location you selected, does not exist", "Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			if (!Directory.Exists(txtPlugins.Text.Trim()))
			{
				MessageBox.Show("The plugin storage location you selected, does not exist", "Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			try
			{
				// Save configuration settings
				Properties.Settings.Default.VisualFeedbackColor = _VisualFeedbackColor;
				Properties.Settings.Default.VisualFeedbackWidth = tbVisualFeedbackWidth.Value;
				Properties.Settings.Default.MiniViewColor = _MiniViewColor;
				Properties.Settings.Default.DataStoragePath = txtDataPath.Text.Trim();
				Properties.Settings.Default.PluginStoragePath = txtPlugins.Text.Trim();
				Properties.Settings.Default.StartupMode = cmbStartupMode.SelectedIndex;
				Properties.Settings.Default.CaptureWith = cmbCaptureWith.SelectedIndex;
				Properties.Settings.Default.IgnoreWith = cmbIgnoreWith.SelectedIndex;
				Properties.Settings.Default.Opacity = (byte)tbOpacity.Value;
				Properties.Settings.Default.Save();

				// Update registry key for windows startup
				ChangeStartupStatus(chkWindowsStartup.Checked);

				return true;
			}
			catch
			{
				MessageBox.Show("Unable to save configuration settings", "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		private bool LoadSettings()
		{
			try
			{
				// Try to load saved settings
				Properties.Settings.Default.Reload();

				_VisualFeedbackColor = Properties.Settings.Default.VisualFeedbackColor;
				tbVisualFeedbackWidth.Value = Properties.Settings.Default.VisualFeedbackWidth;
				_MiniViewColor = Properties.Settings.Default.MiniViewColor;
				txtDataPath.Text = Properties.Settings.Default.DataStoragePath;
				txtPlugins.Text = Properties.Settings.Default.PluginStoragePath;
				chkWindowsStartup.Checked = GetStartupStatus();
				cmbStartupMode.SelectedIndex = Properties.Settings.Default.StartupMode;
				cmbCaptureWith.SelectedIndex = Properties.Settings.Default.CaptureWith;
				cmbIgnoreWith.SelectedIndex = Properties.Settings.Default.IgnoreWith;
				tbOpacity.Value = Properties.Settings.Default.Opacity;

				return true;
			}
			catch
			{
				MessageBox.Show("Unable to load configuration settings", "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		private void UpdateVisualFeedbackExample()
		{
			// Show new example graphic if visual feedback is enabled
			if (tbVisualFeedbackWidth.Value > 0)
			{
				// Change standard pen size and color
				_VisualFeedbackPen.Width = tbVisualFeedbackWidth.Value;
				_VisualFeedbackPen.Color = Color.FromArgb(tbOpacity.Enabled ? tbOpacity.Value : byte.MaxValue, _VisualFeedbackColor);

				// Change size display text with new size
				lblVisualFeedbackWidthText.Text = String.Format("{0}px", tbVisualFeedbackWidth.Value);
			}
			else
			{
				// Hide visual feedback example stroke and display disabled as display text
				_VisualFeedbackPen.Color = Color.White;
				lblVisualFeedbackWidthText.Text = "Disabled";
			}

			// Change opacity display text with new value
			lblOpacity.Text = String.Format("Opacity: {0}%", GetAlphaPercentage(tbOpacity.Value));

			// Refresh example
			picVisualFeedbackExample.Refresh();
		}

		private void UpdateMiniViewExample()
		{
			// Change mini view pen color
			_MiniViewPen.Color = _MiniViewColor;

			// Refresh example
			picMiniViewExample.Refresh();
		}

		private void RefreshPens()
		{
			// Create new standard cap and pen
			_VisualFeedbackPen = new Pen(Color.Blue, 4);
			_VisualFeedbackPen.StartCap = _VisualFeedbackPen.EndCap = LineCap.Round;

			// Create new arrow cap and pen
			_MiniViewPen = new Pen(Color.Blue, 3);
			AdjustableArrowCap arrowCap = new AdjustableArrowCap(4, 4, true);
			arrowCap.BaseCap = LineCap.Square;
			_MiniViewPen.CustomEndCap = arrowCap;
		}

		private bool GetStartupStatus()
		{
			// Get registry key to startup area
			RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

			if (rkApp.GetValue("HighSign") == null)
				return false;
			else
				return true;
		}

		private void ChangeStartupStatus(bool AutomaticallyStart)
		{
			// Get registry key to startup area
			RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

			// What does the user want to do
			if (AutomaticallyStart)
				rkApp.SetValue("HighSign", Application.ExecutablePath);
			else
				rkApp.DeleteValue("HighSign", false);
		}

		private int GetAlphaPercentage(int Alpha)
		{
			return (int)Math.Round(Alpha * (100f / 255f));
		}

		private void DisableIncompatibleControls()
		{
			tbOpacity.Enabled = lblOpacity.Enabled = DesktopWindowManager.IsCompositionEnabled();
		}

		#endregion
	}
}
