using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using HighSign.Common.Applications;
using ManagedWinapi.Windows;
using HighSign.Common.UI.Controls;

namespace HighSign.UI.Forms
{
	public partial class ApplicationDefinition : Form
	{
		#region Constants

		const int HeightOpen = 456;
		const int HeightClosed = 140;

		#endregion

		#region Enumerations

		private enum SpecialItem
		{
			NewApplication = 0,
			AllApplications = 1
		}

		#endregion

		#region Constructors

		public ApplicationDefinition()
		{
			InitializeComponent();

			HideRunningApplications();

			this.KeyDown += new KeyEventHandler(ApplicationDefinition_KeyDown);
			this.cmbMatchCriteria.SelectedIndexChanged += new EventHandler(cmbMatchCriteria_SelectedIndexChanged);
			this.cmdCancel.Click += new EventHandler(cmdCancel_Click);
			this.FormClosing += new FormClosingEventHandler(ApplicationDefinition_FormClosing);
			this.Load += new EventHandler(ApplicationDefinition_Load);
			this.cmdNext.Click += new EventHandler(cmdNext_Click);
			this.cmbExistingApplication.SelectedIndexChanged += new EventHandler(cmbExistingApplication_SelectedIndexChanged);
			this.cmdRefresh.Click += new EventHandler(cmdRefresh_Click);
			this.lstRunningApplications.SelectedIndexChanged += new EventHandler(lstRunningApplications_SelectedIndexChanged);
		}

		#endregion

		#region Events

		protected void ApplicationDefinition_Load(object sender, EventArgs e)
		{
			PopulateForm();
		}

		protected void ApplicationDefinition_FormClosing(object sender, FormClosingEventArgs e)
		{
			// User canceled dialog, re-enable gestures and hide form
			Input.MouseCapture.Instance.EnableMouseCapture();
			this.Dispose();
		}

		protected void ApplicationDefinition_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				this.Close();
		}

		protected void cmdRefresh_Click(object sender, EventArgs e)
		{
			lstRunningApplications.RefreshApplications();
		}

		protected void cmdCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		protected void cmdNext_Click(object sender, EventArgs e)
		{
			if (!SaveApplication())
				return;

			FormManager.Instance.ActionDefinition.Show();
			this.Close();
		}

		protected void cmbMatchCriteria_SelectedIndexChanged(object sender, EventArgs e)
		{
			lstRunningApplications.MatchUsing = (MatchUsing)cmbMatchCriteria.SelectedIndex;
			lstRunningApplications.SelectSimilar(Applications.ApplicationManager.Instance.CaptureWindow.ClassName);
		}

		protected void cmbExistingApplication_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbExistingApplication.SelectedIndex == (int)SpecialItem.NewApplication)
				ShowRunningApplications();
			else
				HideRunningApplications();
		}

		protected void lstRunningApplications_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstRunningApplications.SelectedApplication != null)
				txtFriendlyName.Text = lstRunningApplications.SelectedApplication.ApplicationName;
		}

		#endregion

		#region Private Methods

		private bool SaveApplication()
		{
			// Did user select all applications
			if (cmbExistingApplication.SelectedIndex == (int)SpecialItem.AllApplications)
			{
				Applications.ApplicationManager.Instance.CurrentApplication = Applications.ApplicationManager.Instance.GetGlobalApplication();
				return true;
			}

			// Did user select an existing application
			if (cmbExistingApplication.SelectedIndex != (int)SpecialItem.AllApplications && cmbExistingApplication.SelectedIndex != (int)SpecialItem.NewApplication)
			{
				Applications.ApplicationManager.Instance.CurrentApplication = Applications.ApplicationManager.Instance.GetExistingUserApplication(cmbExistingApplication.SelectedItem.ToString());
				return true;
			}

			// User is creating a new application
			// Make sure we have a valid name
			if (String.IsNullOrEmpty(txtFriendlyName.Text.Trim()))
			{
				MessageBox.Show("Please provide a name for the applications you selected", "No Application Name Specified", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			// Make sure the application name doesn't already exist
			if (Applications.ApplicationManager.Instance.ApplicationExists(txtFriendlyName.Text))
			{
				MessageBox.Show("The name you provided already exists, please provide a different name", "Name Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			// Find out how user wants to match other applications
			MatchUsing oMatchUsing = (MatchUsing)cmbMatchCriteria.SelectedIndex;

			// Create new application object
			UserApplication newApplication = new UserApplication();
			newApplication.MatchUsing = oMatchUsing;
			newApplication.Name = txtFriendlyName.Text.Trim();

			// Get the first selected item
			ApplicationListViewItem alvFirstItem = lstRunningApplications.SelectedApplication;

			switch (oMatchUsing)
			{
				case MatchUsing.WindowClass:
					newApplication.MatchString = alvFirstItem.WindowClass;
					break;
				case MatchUsing.WindowTitle:
					newApplication.MatchString = alvFirstItem.WindowTitle;
					break;
				case MatchUsing.ExecutableFilename:
					newApplication.MatchString = alvFirstItem.WindowFilename;
					break;
			}

			// Save new application to application list and set newly created application as selected application
			Applications.ApplicationManager.Instance.AddApplication(newApplication);
			Applications.ApplicationManager.Instance.CurrentApplication = newApplication;

			// Save entire list of applications
			Applications.ApplicationManager.Instance.SaveApplications();

			// Notify success
			return true;
		}

		private void BindExistingApplications()
		{
			// Clear out existing items
			cmbExistingApplication.Items.Clear();

			// Add special options
			cmbExistingApplication.Items.Add("-- New Application --");
			cmbExistingApplication.Items.Add("All Applications");

			// Populate drop down with list of saved applications
			cmbExistingApplication.Items.AddRange(Applications.ApplicationManager.Instance.GetAvailableUserApplications().Select(a => a.Name).ToArray());
		}

		private void PopulateForm()
		{
			// Show running applications
			lstRunningApplications.RefreshApplications();

			BindExistingApplications();

			cmbExistingApplication.SelectedIndex = 0;
			cmbMatchCriteria.SelectedIndex = 0;

			bool isGlobalGesture = Applications.ApplicationManager.Instance.IsGlobalGesture(Gestures.GestureManager.Instance.GestureName);
			bool isGlobalGestureOnly = Applications.ApplicationManager.Instance.IsGlobalApplication(Applications.ApplicationManager.Instance.CurrentApplication);
			bool isUserGesture = Applications.ApplicationManager.Instance.IsUserGesture(Gestures.GestureManager.Instance.GestureName);
			string applicationName = Applications.ApplicationManager.Instance.CurrentApplication.Name;
			bool alreadyExists = cmbExistingApplication.Items.Contains(applicationName);

			// User drew gesture that is globally assigned and not assigned to a specific application
			if (isGlobalGesture && !isUserGesture)
			{
				if (alreadyExists)
					cmbExistingApplication.SelectedItem = applicationName;
				else
					cmbExistingApplication.SelectedIndex = (int)SpecialItem.AllApplications;
			}

			// User drew gesture that is globally assigned and assigned to a specific appliation
			if (isGlobalGesture && isUserGesture)
			{
				if (isGlobalGestureOnly)
					cmbExistingApplication.SelectedIndex = (int)SpecialItem.AllApplications;
				else
					cmbExistingApplication.SelectedItem = applicationName;
			}

			// User drew gesture that is not globally assigned and not assigned to a specific appliation
			if (!isGlobalGesture && !isUserGesture)
			{
				if (alreadyExists)
					cmbExistingApplication.SelectedItem = applicationName;
				else
				{
					cmbExistingApplication.SelectedIndex = (int)SpecialItem.NewApplication;
					lstRunningApplications.SelectSimilar(Applications.ApplicationManager.Instance.CaptureWindow.ClassName);
				}
			}

			// User drew gesture that is not globally assigned and is assigned to a specific appliation
			if (!isGlobalGesture && isUserGesture)
				cmbExistingApplication.SelectedItem = applicationName;
		}

		private void ShowRunningApplications()
		{
			grpRunningApplications.Visible = true;
			this.Height = HeightOpen;
			Screen currentScreen = Screen.FromControl(this);
			this.Top = Convert.ToInt32(currentScreen.Bounds.Height / 2 - this.Height / 2);
		}

		private void HideRunningApplications()
		{
			grpRunningApplications.Visible = false;
			this.Height = HeightClosed;
			Screen currentScreen = Screen.FromControl(this);
			this.Top = Convert.ToInt32(currentScreen.Bounds.Height / 2 - this.Height / 2);
		}

		#endregion
	}
}