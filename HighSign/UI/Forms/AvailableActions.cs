using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HighSign.Common.Plugins;
using HighSign.Common.Gestures;
using HighSign.Common.Applications;
using HighSign.Common.Drawing;

namespace HighSign.UI.Forms
{
	public partial class AvailableActions : Form
	{
		#region Constructors

		public AvailableActions()
		{
			InitializeComponent();

			// Set icon using icon from resource file
			this.Icon = Icon.FromHandle(Properties.Resources.MouseIcon.GetHicon());

			this.Load += new EventHandler(AvailableActions_Load);
			this.Resize += new EventHandler(AvailableActions_Resize);
			this.cmdEdit.Click += new EventHandler(cmdEdit_Click);
			this.cmdDelete.Click += new EventHandler(cmdDelete_Click);
			this.lstAvailableActions.SelectedIndexChanged += new EventHandler(lstAvailableActions_SelectedIndexChanged);
		}

		#endregion

		#region Events

		protected void AvailableActions_Resize(object sender, EventArgs e)
		{
			SetTileSize();
		}

		protected void AvailableActions_Load(object sender, EventArgs e)
		{
			BindActions();
			SetTileSize();
		}

		protected void cmdEdit_Click(object sender, EventArgs e)
		{
			// Make sure at least one item is selected
			if (lstAvailableActions.SelectedItems.Count == 0)
			{
			    MessageBox.Show("You must select an item before editing", "Please Select an Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			    return;
			}

			// Get first item selected, associated action, and selected application
			ListViewItem selectedItem = lstAvailableActions.SelectedItems[0];
			IAction selectedAction = null;
			IApplication selectedApplication = null;
			string selectedGesture = null;

			// Store selected item group header for later use
			string strApplicationHeader = selectedItem.Group.Header;

			if (selectedItem.Group.Header != "All Applications")
				selectedApplication = Applications.ApplicationManager.Instance.GetExistingUserApplication(strApplicationHeader);
			else
				selectedApplication = Applications.ApplicationManager.Instance.GetGlobalApplication();

			if (selectedApplication == null)
				// Select action from global application list
				selectedAction = Applications.ApplicationManager.Instance.GetGlobalApplication().Actions.FirstOrDefault(a => a.Name == selectedItem.Text);
			else
				// Select action from selected application list
				selectedAction = selectedApplication.Actions.FirstOrDefault(a => a.Name == selectedItem.Text);

			// Get currently assigned gesture
			selectedGesture = selectedAction.GestureName;

			// Set current application, current action, and current gestures
			Applications.ApplicationManager.Instance.CurrentApplication = selectedApplication;
			Gestures.GestureManager.Instance.GestureName = selectedGesture;

			if (UI.FormManager.Instance.ActionDefinition.ShowDialog() == DialogResult.OK)
			{
			    // User changed action, refresh list
			    BindActions();

			    // Reset selected item
			    foreach (ListViewItem lItem in lstAvailableActions.Items)
			        // Is this the item that was previously selected
			        if (lItem.Text == selectedAction.Name && lItem.Group.Header == strApplicationHeader)
			        {
			            lItem.Selected = true;
			            lItem.EnsureVisible();
			        }
			}
		}

		protected void cmdDelete_Click(object sender, EventArgs e)
		{
			DeleteAction();
		}

		protected void lstAvailableActions_SelectedIndexChanged(object sender, EventArgs e)
		{
			EnableRelevantButtons();
		}

		#endregion

		#region Private Methods

		private void EnableRelevantButtons()
		{
			cmdEdit.Enabled = (lstAvailableActions.SelectedItems.Count == 1);
			cmdDelete.Enabled = (lstAvailableActions.SelectedItems.Count > 0);
		}

		private void DeleteAction()
		{
			// Verify that we have an item selected
			if (lstAvailableActions.SelectedItems.Count == 0)
			{
				MessageBox.Show("Please select and item before trying to delete.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			// Confirm user really wants to delete selected items
			if (MessageBox.Show("Are you sure you want to delete the selected actions?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
				return;

			// Loop through selected actions
			for (int i = lstAvailableActions.SelectedItems.Count - 1; i >= 0; i--)
			{
				// Grab selected item
				ListViewItem selectedAction = lstAvailableActions.SelectedItems[i];

				// Get the name of the action
				string strActionName = selectedAction.Text;

				// Get name of application
				string strApplicationName = selectedAction.Group.Header;

				// Is this a global action or application specific
				if (strApplicationName == "All Applications")
					// Delete action from global list
					Applications.ApplicationManager.Instance.RemoveGlobalAction(strActionName);
				else
					// Delete action from application
					Applications.ApplicationManager.Instance.RemoveNonGlobalAction(strActionName);

				// Remove selected item from list
				lstAvailableActions.Items.Remove(selectedAction);
			}

			// Save entire list of applications
			Applications.ApplicationManager.Instance.SaveApplications();
		}

		private void SetTileSize()
		{
			// Make sure window isn't minimized
			if (this.WindowState == FormWindowState.Minimized)
				return;

			lstAvailableActions.TileSize = new Size(lstAvailableActions.Width - 25, lstAvailableActions.TileSize.Height);
		}

		private void BindActions()
		{
			// Clear all existing actions
			lstAvailableActions.Items.Clear();

			// Add "All Applications" group
			ListViewGroup grpAllApplications = new ListViewGroup("All Applications");
			lstAvailableActions.Groups.Add(grpAllApplications);

			// Add global actions to global applications group
			AddActionsToGroup(grpAllApplications, Applications.ApplicationManager.Instance.GetGlobalApplication().Actions.OrderBy(a => a.Name));

			// Get all applications
			IApplication[] lstApplications = Applications.ApplicationManager.Instance.GetAvailableUserApplications();

			foreach (UserApplication App in lstApplications)
			{
				// Create list view group for this application
				ListViewGroup grpApplication = new ListViewGroup(App.Name);
				lstAvailableActions.Groups.Add(grpApplication);

				// Add this applications actions to applications group
				AddActionsToGroup(grpApplication, App.Actions.OrderBy(a => a.Name));
			}

			EnableRelevantButtons();
		}

		private void AddActionsToGroup(ListViewGroup Group, IEnumerable<IAction> Actions)
		{
			Size sizThumbSize = new Size(45, 45);
			Size sizOutputSize = new Size(62, 52);

			// Loop through each global action
			foreach (Applications.Action currentAction in Actions)
			{
				// Ensure this action has a plugin
				if (!Plugins.PluginManager.Instance.PluginExists(currentAction.PluginClass, currentAction.PluginFilename))
					continue;

				// Get plugin for this action
				IPluginInfo pluginInfo = Plugins.PluginManager.Instance.FindPluginByClassAndFilename(currentAction.PluginClass, currentAction.PluginFilename);

				// Feed settings to plugin
				pluginInfo.Plugin.Deserialize(currentAction.ActionSettings);

				// Get handle of action gesture
				IGesture actionGesture = Gestures.GestureManager.Instance.GetNewestGestureSample(currentAction.GestureName);

				// Continue if we don't have a gesture
				if (actionGesture == null)
					continue;

				imgGestureThumbnails.Images.Add(ImageHelper.AlignImage(GestureThumbnail.Create(actionGesture.Points, sizThumbSize, true), sizOutputSize, ContentAlignment.MiddleCenter));

				ListViewItem newItem = new ListViewItem(Group);
				newItem.Text = !String.IsNullOrEmpty(currentAction.Name) ? currentAction.Name : pluginInfo.Plugin.Name;
				newItem.ImageIndex = imgGestureThumbnails.Images.Count - 1;

				ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
				subItem.Text = pluginInfo.Plugin.Description;
				newItem.SubItems.Add(subItem);

				newItem.Group = Group;
				lstAvailableActions.Items.Add(newItem);
			}
		}

		#endregion
	}
}
