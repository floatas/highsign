using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using HighSign.Common;
using HighSign.Common.UI;
using HighSign.Common.Input;

namespace HighSign.UI
{
	public class TrayManager : ILoadable, ITrayManager
	{

		#region Private Variables

		// Create variable to hold the only allowed instance of this class
		static readonly TrayManager _Instance = new TrayManager();

		#endregion

		#region Controls Initialization

		private  NotifyIcon TrayIcon;
		private  ContextMenuStrip TrayMenu;
		private  ToolStripMenuItem miTrainingMode;
		private  ToolStripMenuItem miDisableGestures;
		private  ToolStripSeparator miSeperator1;
		private  ToolStripMenuItem miAvailableActions;
		private  ToolStripMenuItem miAvailableGestures;
		private  ToolStripMenuItem miIgnoredApplications;
		private  ToolStripMenuItem miOptions;
		private  ToolStripSeparator miSeperator2;
		private  ToolStripMenuItem miExitHighSign;

		#endregion

		#region Private Methods

		private void SetupTrayIconAndTrayMenu()
		{
			TrayIcon = new NotifyIcon();
			TrayMenu = new ContextMenuStrip();
			miTrainingMode = new ToolStripMenuItem();
			miDisableGestures = new ToolStripMenuItem();
			miSeperator1 = new ToolStripSeparator();
			miAvailableActions = new ToolStripMenuItem();
			miAvailableGestures = new ToolStripMenuItem();
			miIgnoredApplications = new ToolStripMenuItem();
			miOptions = new ToolStripMenuItem();
			miSeperator2 = new ToolStripSeparator();
			miExitHighSign = new ToolStripMenuItem();

			// Tray Icon
			TrayIcon.ContextMenuStrip = TrayMenu;
			TrayIcon.Text = "High Sign";
			TrayIcon.Visible = true;
			TrayIcon.DoubleClick += (o, e) => { TrayIcon_Click(o, (MouseEventArgs)e); };
			TrayIcon.Click += (o, e) => { TrayIcon_Click(o, (MouseEventArgs)e); };

			// Tray Menu
			TrayMenu.Items.AddRange(new ToolStripItem[] { miTrainingMode, miDisableGestures, miSeperator1, miAvailableActions, miAvailableGestures, miIgnoredApplications, miOptions, miSeperator2, miExitHighSign });
			TrayMenu.Name = "TrayMenu";
			TrayMenu.Size = new Size(194, 82);
			TrayMenu.Text = "High Sign Tray Menu";
			TrayMenu.Opened += (o, e) => { Input.MouseCapture.Instance.DisableMouseCapture(); };
			TrayMenu.Closed += (o, e) => { Input.MouseCapture.Instance.EnableMouseCapture(); };

			// Training Mode Menu Item
			miTrainingMode.Checked = true;
			miTrainingMode.CheckOnClick = true;
			miTrainingMode.CheckState = CheckState.Checked;
			miTrainingMode.Name = "TrainingModeMenuItem";
			miTrainingMode.Size = new Size(193, 22);
			miTrainingMode.Text = "Training Mode";
			miTrainingMode.Click += (o, e) => { ToggleTeaching(); };

			// Disable Gestures Menu Item
			miDisableGestures.Checked = false;
			miDisableGestures.CheckOnClick = true;
			miDisableGestures.CheckState = CheckState.Unchecked;
			miDisableGestures.Name = "DisableGesturesMenuItem";
			miDisableGestures.Size = new Size(193, 22);
			miDisableGestures.Text = "Disable Gestures";
			miDisableGestures.Click += (o, e) => { ToggleDisableGestures(); };

			// First Seperator Menu Item
			miSeperator1.Name = "Seperator1";
			miSeperator1.Size = new Size(190, 6);

			// Available Actions Menu Item
			miAvailableActions.Name = "AvailableActions";
			miAvailableActions.Size = new Size(193, 22);
			miAvailableActions.Text = "Available Actions";
			miAvailableActions.Click += (o, e) => { UI.FormManager.Instance.AvailableActions.Show(); };

			// Available Gestures Menu Item
			miAvailableGestures.Name = "AvailableGestures";
			miAvailableGestures.Size = new Size(193, 22);
			miAvailableGestures.Text = "Available Gestures";
			miAvailableGestures.Click += (o, e) => { UI.FormManager.Instance.AvailableGestures.Show(); };

			// Ignored Applications Menu Item
			miIgnoredApplications.Name = "IgnoredApplications";
			miIgnoredApplications.Size = new Size(192,22);
			miIgnoredApplications.Text = "Ignored Applications";
			miIgnoredApplications.Click += (o, e) => { UI.FormManager.Instance.IgnoredApplications.Show(); };

			// Options Menu Item
			miOptions.Name = "Options";
			miOptions.Size = new Size(193, 22);
			miOptions.Text = "Preferences";
			miOptions.Click += (o, e) => { UI.FormManager.Instance.Options.Show(); };

			// Second Seperator Menu Item
			miSeperator2.Name = "Seperator2";
			miSeperator2.Size = new Size(190, 6);

			// Exit High Sign Menu Item
			miExitHighSign.Name = "ExitHighSign";
			miExitHighSign.Size = new Size(193, 22);
			miExitHighSign.Text = "Exit High Sign";
			miExitHighSign.Click += (o, e) =>
			{
				// Uninstall mouse hook and exit program
				TrayIcon.Visible = false;
				Input.MouseCapture.Instance.DestroyMouseHook();
				Application.ExitThread();
			};
		}

		private void TrayIcon_Click(object sender, MouseEventArgs e)
		{
			switch (e.Button)
			{
				case MouseButtons.Left:
					if (e.Clicks == 2)
						ToggleTeaching();
					break;
				case MouseButtons.Right:
					break;
				case MouseButtons.Middle:
					ToggleDisableGestures();
					break;
			}
		}

		#endregion

		#region Constructors

		protected TrayManager()
		{
			Input.MouseCapture.Instance.StateChanged += new StateChangedEventHandler(CaptureState_Changed);
		}



		#endregion

		#region Public Properties

		public static TrayManager Instance
		{
			get { return _Instance; }
		}

		public void Load()
		{
			SetupTrayIconAndTrayMenu();
			EnterUserDefinedMode();
		}

		#endregion

		#region Events

		protected void CaptureState_Changed(object sender, StateChangedEventArgs e)
		{
			// Update tray icon based on new state
			if (e.State == CaptureState.UserDisabled)
			{
				miTrainingMode.Enabled = false;
				miDisableGestures.Checked = true;
				TrayIcon.Icon = Icon.FromHandle(HighSign.Properties.Resources.MouseIconDisabled.GetHicon());
			}
			else
			{
				miTrainingMode.Enabled = true;
				miDisableGestures.Checked = false;
				// Consider state of Training Mode and load according icon
				if (miTrainingMode.Checked)
					TrayIcon.Icon = Icon.FromHandle(HighSign.Properties.Resources.MouseIconTraining.GetHicon());
				else
					TrayIcon.Icon = Icon.FromHandle(HighSign.Properties.Resources.MouseIcon.GetHicon());
			}
		}

		#endregion

		#region Public Methods

		public void EnterUserDefinedMode()
		{
			switch ((Configuration.StartupMode)Properties.Settings.Default.StartupMode)
			{
				case Configuration.StartupMode.Training:
					StartTeaching();
					break;
				case Configuration.StartupMode.Gesture:
					StopTeaching();
					break;
				case Configuration.StartupMode.LastInstance:
					if (Properties.Settings.Default.Teaching)
						StartTeaching();
					else
						StopTeaching();
					break;
			}
		}

		public void ToggleTeaching()
		{
			// Toggle teaching mode, unless is UserDisable gestures mode
			if (Input.MouseCapture.Instance.State != CaptureState.UserDisabled)
				if (Properties.Settings.Default.Teaching)
					StopTeaching();
				else
					StartTeaching();
		}

		public void ToggleDisableGestures()
		{
			Input.MouseCapture.Instance.ToggleUserDisableMouseCapture();
		}

		public void StartTeaching()
		{
			Properties.Settings.Default.Teaching = miTrainingMode.Checked = true;
			Properties.Settings.Default.Save();

			// Assign resource icon as tray icon
			TrayIcon.Icon = Icon.FromHandle(HighSign.Properties.Resources.MouseIconTraining.GetHicon());
		}

		public void StopTeaching()
		{
			Properties.Settings.Default.Teaching = miTrainingMode.Checked = false;
			Properties.Settings.Default.Save();

			// Assign resource icon as tray icon
			TrayIcon.Icon = Icon.FromHandle(HighSign.Properties.Resources.MouseIcon.GetHicon());
		}

		#endregion

	}
}
