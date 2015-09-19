using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HighSign.Common.Plugins;
using HighSign.Common.Applications;

namespace HighSign.UI.Forms
{
	public partial class ActionDefinition : Form
	{
		#region Private Variables

		private string strInstructionText = "-- Available Actions --";
		// Create variable to hold current selected plugin
		IPluginInfo _PluginInfo = null;
		IAction _CurrentAction = null;

		#endregion

		#region Properties

		public bool AllowEscapeKey { get; set; }

		#endregion

		#region Constructors

		public ActionDefinition()
		{
			InitializeComponent();

			// By default, allow escape key
			AllowEscapeKey = true;

			this.Load += new EventHandler(ActionDefinition_Load);
			this.cmbPlugins.SelectedIndexChanged += new EventHandler(cmbPlugins_SelectedIndexChanged);
			this.FormClosing += new FormClosingEventHandler(ActionDefinition_FormClosing);
			this.cmdCancel.Click += new EventHandler(cmdCancel_Click);
			this.cmdDone.Click += new EventHandler(cmdDone_Click);
			this.KeyDown += new KeyEventHandler(ActionDefinition_KeyDown);
		}

		#endregion

		#region Events

		protected void ActionDefinition_Load(object sender, EventArgs e)
		{
			PopulateForm();
		}

		protected void ActionDefinition_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape && AllowEscapeKey)
				this.Close();
		}

		protected void cmbPlugins_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (((IPluginInfo)cmbPlugins.SelectedItem).DisplayText == strInstructionText)
				UnloadPlugin();
			else
				LoadPlugin(((IPluginInfo)cmbPlugins.SelectedItem).Class, ((IPluginInfo)cmbPlugins.SelectedItem).Filename);
		}

		protected void ActionDefinition_FormClosing(object sender, FormClosingEventArgs e)
		{
			// User canceled dialog, re-enable gestures and hide form
			Input.MouseCapture.Instance.EnableMouseCapture();
			this.Dispose();
		}

		protected void cmdCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		protected void cmdDone_Click(object sender, EventArgs e)
		{
			if (!SaveAction())
				return;

			// Done saving gestures
			this.Close();
		}

		#endregion

		#region Private Methods

		private bool SaveAction()
		{
			if (((IPluginInfo)cmbPlugins.SelectedItem).DisplayText == strInstructionText)
			{
				MessageBox.Show("Please select an action you would like to perform", "No Action Specified", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			// Check if we're creating a new action
			bool _IsNew = false;
			if (_CurrentAction == null)
			{
				_CurrentAction = new Applications.Action();
				_IsNew = true;
			}

			if (_IsNew)
			{
				if (Applications.ApplicationManager.Instance.CurrentApplication is GlobalApplication)
				{
					if (Applications.ApplicationManager.Instance.IsGlobalAction(txtActionName.Text.Trim()))
					{
						MessageBox.Show(String.Format("Action '{0}' is already defined as a global action", txtActionName.Text.Trim()), "Action Already Defined", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}
				}
				else
				{
					if (Applications.ApplicationManager.Instance.IsUserAction(txtActionName.Text.Trim()))
					{
						MessageBox.Show(String.Format("Action '{0}' is already defined for {1}", txtActionName.Text.Trim(), Applications.ApplicationManager.Instance.CurrentApplication.Name), "Action Already Defined", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}
				}
			}
			else
			{
				if (Applications.ApplicationManager.Instance.CurrentApplication is GlobalApplication)
				{
					if (Applications.ApplicationManager.Instance.IsGlobalAction(txtActionName.Text.Trim()) && txtActionName.Text.Trim() != _CurrentAction.Name)
					{
						MessageBox.Show(String.Format("Action '{0}' is already defined as a global action", txtActionName.Text.Trim()), "Action Already Defined", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}
				}
				else
				{
					if (Applications.ApplicationManager.Instance.IsUserAction(txtActionName.Text.Trim()) && txtActionName.Text.Trim() != _CurrentAction.Name)
					{
						MessageBox.Show(String.Format("Action '{0}' is already defined for {1}", txtActionName.Text.Trim(), Applications.ApplicationManager.Instance.CurrentApplication.Name), "Action Already Defined", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}
				}
			}

			// Store new values
			_CurrentAction.GestureName = Gestures.GestureManager.Instance.GestureName;
			_CurrentAction.Name = txtActionName.Text.Trim();
			_CurrentAction.PluginClass = _PluginInfo.Class;
			_CurrentAction.PluginFilename = _PluginInfo.Filename;
			_CurrentAction.ActionSettings = _PluginInfo.Plugin.Serialize();

			// Check if we already have this action somewhere
			if (_IsNew)
				// Save new action to specific application
				Applications.ApplicationManager.Instance.CurrentApplication.AddAction(_CurrentAction);

			// Save entire list of applications
			Applications.ApplicationManager.Instance.SaveApplications();

			return true;
		}

		private void BindPlugins()
		{
			// Compile list of PluginInfo objects to bind to drop down
			List<IPluginInfo> availablePlugins = new List<IPluginInfo>();

			availablePlugins.Add(new Plugins.PluginInfo(null, null, null) { DisplayText = "-- Available Actions --" });
			availablePlugins.AddRange(Plugins.PluginManager.Instance.Plugins.Where(pi => pi.Plugin.IsAction).OrderBy(pi => pi.ToString()));

			// Bind available plugin list to combo box
			cmbPlugins.DisplayMember = "DisplayText";
			cmbPlugins.DataSource = availablePlugins;
		}

		private void LoadPlugin(string PluginClass, string PluginFilename)
		{
			// Try to load plugin, and set current plugin to newly selected plugin
			_PluginInfo = Plugins.PluginManager.Instance.FindPluginByClassAndFilename(PluginClass, PluginFilename);

			// Set action name
			if (IsPluginMatch(_CurrentAction, PluginClass, PluginFilename))
				txtActionName.Text = _CurrentAction.Name;
			else
				txtActionName.Text = _PluginInfo.Plugin.Name;

			// Load action settings or no settings
			_PluginInfo.Plugin.Deserialize(IsPluginMatch(_CurrentAction, PluginClass, PluginFilename) ? _CurrentAction.ActionSettings : "");

			// Does the plugin have a graphical interface
			if (_PluginInfo.Plugin.GUI != null)
				// Show plugins graphical interface
				ShowSettings(_PluginInfo);
			else
				// There is no interface for this plugin, hide settings but leave action name input box
				HideSettings(false);
		}

		private void UnloadPlugin()
		{
			HideSettings(true);
		}

		private void ShowSettings(IPluginInfo PluginInfo)
		{
			// Clear any existing controls
			pnlSettings.Controls.Clear();

			// Show settings interface
			PluginInfo.Plugin.GUI.Show();

			// Add settings to settings panel
			pnlSettings.Controls.Add(PluginInfo.Plugin.GUI);

			pnlSettings.Height = PluginInfo.Plugin.GUI.RestoreBounds.Height;
			grpSettings.Height = pnlSettings.Bottom + 3;
			pnlSettings.Visible = true;
			grpActions.Height = grpSettings.Bottom + 12;
			cmdCancel.Top = cmdDone.Top = grpActions.Bottom + 8;

			Screen currentScreen = Screen.FromControl(this);
			this.Top = Convert.ToInt32(currentScreen.Bounds.Height / 2 - this.Height / 2);
		}

		private void HideSettings(bool CollapseFully)
		{
			// Remove plugin settings interface from settings panel
			pnlSettings.Controls.Clear();

			pnlSettings.Height = 0;
			grpSettings.Height = CollapseFully ? 0 : pnlSettings.Bottom + 3;
			pnlSettings.Visible = false;
			grpActions.Height = grpSettings.Bottom + 12;
			cmdCancel.Top = cmdDone.Top = grpActions.Bottom + 8;

			Screen currentScreen = Screen.FromControl(this);
			this.Top = Convert.ToInt32(currentScreen.Bounds.Height / 2 - this.Height / 2);
		}

		private bool IsPluginMatch(IAction Action, string PluginClass, string PluginFilename)
		{
			return (Action != null && Action.PluginClass == PluginClass && Action.PluginFilename == PluginFilename);
		}

		private void PopulateForm()
		{
            BindPlugins();

			GetExistingAction();

			// Select current action (if any)
			if (_CurrentAction != null)
				foreach (object comboItem in cmbPlugins.Items)
				{
					IPluginInfo pluginInfo = (IPluginInfo)comboItem;

					if (pluginInfo.Class == _CurrentAction.PluginClass && pluginInfo.Filename == _CurrentAction.PluginFilename)
						cmbPlugins.SelectedItem = pluginInfo;
				}
		}

		private void GetExistingAction()
		{
			_CurrentAction = Applications.ApplicationManager.Instance.GetDefinedAction(Gestures.GestureManager.Instance.GestureName);
		}

		#endregion
	}
}