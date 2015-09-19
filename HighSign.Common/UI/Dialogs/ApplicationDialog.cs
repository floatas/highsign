using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HighSign.Common.Applications;
using HighSign.Common.UI.Controls;
using ManagedWinapi.Windows;
using System.IO;
using System.Text.RegularExpressions;

namespace HighSign.Common.UI.Dialogs
{
	public partial class ApplicationDialog : Form
	{
		#region Private Instance Fields

		private IApplication _SelectedApplication = null;

		private class MatchUsingComboBoxItem
		{
			public string DisplayText { get; set; }
			public MatchUsing MatchUsing { get; set; }
		}

		private class ApplicationComboBoxItem
		{
			public string ApplicationName { get; set; }
			public MatchUsing MatchUsing { get; set; }
			public string MatchString { get; set; }
			public bool IsRegEx { get; set; }
		}

		private enum ApplicationItemType
		{
			NewApplication = 0,
			AllApplications = 1
		}

		private enum TabType
		{
			Running = 0,
			Custom = 1
		}

		#endregion

		#region Constructor

		public ApplicationDialog(IApplicationManager ApplicationManager)
		{
			InitializeComponent();

			this.Icon = Icon.FromHandle(Properties.Resources.SelectApplication.GetHicon());
			this.ApplicationManager = ApplicationManager;

			BindMatchUsingComboBoxes();
			BindExistingApplications();
			alvRunningApplications.RefreshApplications();

			this.tcApplications.SelectedIndexChanged += new EventHandler(tcApplications_TabIndexChanged);
			this.cmbExistingApplication.SelectedIndexChanged += new EventHandler(cmbExistingApplication_SelectedIndexChanged);
			this.cmbMatchUsingRunning.SelectedIndexChanged += new EventHandler(cmbMatchUsingRunning_SelectedIndexChanged);
			this.cmbMatchUsingCustom.SelectedIndexChanged += new EventHandler(cmbMatchUsingCustom_SelectedIndexChanged);
			this.alvRunningApplications.SelectedIndexChanged += new EventHandler(alvRunningApplications_SelectedIndexChanged);
			this.chCrosshair.CrosshairDragging += new EventHandler(chCrosshair_CrosshairDragging);
			this.cmdBrowse.Click += new EventHandler(cmdBrowse_Click);
			this.cmsRunningApplications.Items[0].Click += new EventHandler(ApplicationDialog_Click);
			this.cmdDone.Click += new EventHandler(cmdDone_Click);
			this.FormClosing += new FormClosingEventHandler(ApplicationDialog_FormClosing);
			this.alvRunningApplications.DoubleClick += new EventHandler(alvRunningApplications_DoubleClick);
		}

		#endregion

		#region Events

		protected void tcApplications_TabIndexChanged(object sender, EventArgs e)
		{
			int intTabHeight = tcApplications.ItemSize.Height;
			tcApplications.Height = (SelectedTab == TabType.Running ? pnlRunningApplications.Height : pnlCustomApplication.Height) + intTabHeight;
		}

		protected void cmbExistingApplication_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Hide selection panels if we don't need them
			pnlBody.Visible = ((ApplicationItemType)cmbExistingApplication.SelectedIndex != ApplicationItemType.AllApplications);

			ApplicationItemType applicationType = (ApplicationItemType)cmbExistingApplication.SelectedIndex;
			SelectedApplication = applicationType != ApplicationItemType.AllApplications && applicationType != ApplicationItemType.NewApplication ? (IApplication)cmbExistingApplication.SelectedItem : null;
		}

		protected void cmbMatchUsingCustom_SelectedIndexChanged(object sender, EventArgs e)
		{
			cmdBrowse.Visible = (((MatchUsingComboBoxItem)cmbMatchUsingCustom.SelectedItem).MatchUsing == MatchUsing.ExecutableFilename);
		}

		protected void cmbMatchUsingRunning_SelectedIndexChanged(object sender, EventArgs e)
		{
			alvRunningApplications.MatchUsing = ((MatchUsingComboBoxItem)cmbMatchUsingRunning.SelectedItem).MatchUsing;
		}

		protected void alvRunningApplications_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Show application name if something is selected
			if (alvRunningApplications.SelectedItems.Count > 0)
				SetApplicationName(alvRunningApplications.SelectedApplication.ApplicationName);
		}

		protected void chCrosshair_CrosshairDragging(object sender, EventArgs e)
		{
			Point cursorPosition = Cursor.Position;
			SystemWindow window = SystemWindow.FromPointEx(cursorPosition.X, cursorPosition.Y, true, true);

			// Set MatchUsings
			MatchUsing muRunning = ((MatchUsingComboBoxItem)cmbMatchUsingRunning.SelectedItem).MatchUsing;
			MatchUsing muCustom = ((MatchUsingComboBoxItem)cmbMatchUsingCustom.SelectedItem).MatchUsing;
			alvRunningApplications.MatchUsing = muRunning;

			// Which screen are we changing
			if (SelectedTab == TabType.Running)	// Running applications
			{
				switch (muRunning)
				{
					case MatchUsing.WindowClass:
						alvRunningApplications.SelectSimilar(window.ClassName);

						break;
					case MatchUsing.WindowTitle:
						alvRunningApplications.SelectSimilar(window.Title);

						break;
					case MatchUsing.ExecutableFilename:
						alvRunningApplications.SelectSimilar(Path.GetFileName(window.Process.MainModule.FileName));

						break;
				}
			}
			else  // Custom Application
			{
				switch (muCustom)
				{
					case MatchUsing.WindowClass:
						txtMatchString.Text = window.ClassName;

						break;
					case MatchUsing.WindowTitle:
						txtMatchString.Text = window.Title;

						break;
					case MatchUsing.ExecutableFilename:
						txtMatchString.Text = window.Process.MainModule.FileName;
						txtMatchString.SelectionStart = txtMatchString.Text.Length;

						break;
				}

				// Set application name from filename
				txtApplicationName.Text = window.Process.MainModule.FileVersionInfo.FileDescription;
			}
		}

		protected void cmdBrowse_Click(object sender, EventArgs e)
		{
			if (ValidateFilepath(txtMatchString.Text.Trim()))
			{
				ofdExecutable.InitialDirectory = Path.GetDirectoryName(txtMatchString.Text);
				ofdExecutable.FileName = Path.GetFileName(txtMatchString.Text);
			}

			if (ofdExecutable.ShowDialog() == DialogResult.OK)
				txtMatchString.Text = ofdExecutable.FileName;
		}

		protected void ApplicationDialog_Click(object sender, EventArgs e)
		{
			alvRunningApplications.RefreshApplications();
		}

		protected void cmdDone_Click(object sender, EventArgs e)
		{
			Close();
		}

		protected void ApplicationDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.OK)
				e.Cancel = !Save();
		}

		protected void alvRunningApplications_DoubleClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			Close();
		}

		#endregion

		#region Public Instance Properties

		public IApplicationManager ApplicationManager { get; set; }
		public IApplication SelectedApplication
		{
			get { return _SelectedApplication; }
			set { _SelectedApplication = value; PopulateApplicationInfo(); }
		}

		#endregion

		#region Private Instance Properties

		private TabType SelectedTab
		{
			get { return (TabType)tcApplications.SelectedIndex; }
		}

		#endregion

		#region Private Instance Methods

		private bool Save()
		{
			if (!IsValid())
				return false;

			// If the user selected an existing application, populate class properties and exit
			if (((ApplicationItemType)cmbExistingApplication.SelectedIndex) != ApplicationItemType.NewApplication)
				// Set existing application
				_SelectedApplication = (IApplication)cmbExistingApplication.SelectedItem;
			else
			{
				_SelectedApplication = new UserApplication();
				ApplicationManager.AddApplication(_SelectedApplication);
			}

			// Store application name
			_SelectedApplication.Name = txtApplicationName.Text;

			if (SelectedTab == TabType.Running)
			{
				_SelectedApplication.MatchString = alvRunningApplications.MatchString;
				_SelectedApplication.MatchUsing = alvRunningApplications.MatchUsing;
				_SelectedApplication.IsRegEx = false;
			}
			else
			{
				_SelectedApplication.MatchString = txtMatchString.Text.Trim();
				_SelectedApplication.MatchUsing = (MatchUsing)cmbMatchUsingCustom.SelectedIndex;
				_SelectedApplication.IsRegEx = chkRegex.Checked;
			}

			ApplicationManager.SaveApplications();

			return true;
		}

		private bool IsValid()
		{
			// If the user didn't select new application, everything is valid
			if (((ApplicationItemType)cmbExistingApplication.SelectedIndex) != ApplicationItemType.NewApplication)
			{
				if (ApplicationManager.ApplicationExists(txtApplicationName.Text.Trim()) && SelectedApplication.Name.ToLower() != txtApplicationName.Text.Trim().ToLower())
					return ShowErrorMessage("Application name already exists, please enter a different name.", "Application Name Already Exists");

				return true;
			}

			// Make sure we have a valid application name
			if (txtApplicationName.Text.Trim() == "")
				return ShowErrorMessage("Please specify the name of the application.", "No Application Name");

			if (ApplicationManager.ApplicationExists(txtApplicationName.Text.Trim()))
				return ShowErrorMessage("Application name already exists, please enter a different name.", "Application Name Already Exists");

			if (SelectedTab == TabType.Running)
			{
				// Make sure the user selected a running application
				if (alvRunningApplications.SelectedApplication == null)
					return ShowErrorMessage("Please select an application from the list or running applications.", "No Application Selected");
			}
			else
			{
				// Make sure the user entered a match string
				if (txtMatchString.Text.Trim() == "")
					return ShowErrorMessage("Please specify a custom match string for this application.", "No Custom Match String");
			}

			// Return if we're valid or not
			return true;
		}

		private bool ShowErrorMessage(string Message, string Caption)
		{
			MessageBox.Show(Message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}

		private void SetApplicationName(string ApplicationName)
		{
			if (!txtApplicationName.Modified || txtApplicationName.Text == "")
				txtApplicationName.Text = ApplicationName;
		}

		private void BindExistingApplications()
		{
			// Make sure we have an application manager instance
			if (ApplicationManager == null)
				throw new Exception("You must specify an ApplicationManager before using the Application Selection Dialog");

			// Clear existing items
			cmbExistingApplication.Items.Clear();

			// Add generic application listview item
			IApplication newApplicationItem = new UserApplication() { Name = "-- New Application --" };
			IApplication allApplicationsItem = ApplicationManager.GetGlobalApplication();
			IApplication[] existingApplications = ApplicationManager.GetAvailableUserApplications();

			// Add application items to the combobox
			cmbExistingApplication.DisplayMember = "Name";
			cmbExistingApplication.Items.Add(newApplicationItem);
			cmbExistingApplication.Items.Add(allApplicationsItem);
			cmbExistingApplication.Items.AddRange(existingApplications);

			// Select new applications
			cmbExistingApplication.SelectedItem = SelectedApplication ?? newApplicationItem;
		}

		private void BindMatchUsingComboBoxes()
		{
			MatchUsingComboBoxItem mciWindowClass = new MatchUsingComboBoxItem() { DisplayText = "Window Class", MatchUsing = MatchUsing.WindowClass };
			MatchUsingComboBoxItem mciWindowTitle = new MatchUsingComboBoxItem() { DisplayText = "Window Title", MatchUsing = MatchUsing.WindowTitle };
			MatchUsingComboBoxItem mciExecutableFilename = new MatchUsingComboBoxItem() { DisplayText = "Executable Filename", MatchUsing = MatchUsing.ExecutableFilename };

			cmbMatchUsingRunning.Items.AddRange(new MatchUsingComboBoxItem[] { mciWindowClass, mciWindowTitle, mciExecutableFilename });
			cmbMatchUsingCustom.Items.AddRange(new MatchUsingComboBoxItem[] { mciWindowClass, mciWindowTitle, mciExecutableFilename });

			cmbMatchUsingRunning.DisplayMember = cmbMatchUsingCustom.DisplayMember = "DisplayText";
			cmbMatchUsingRunning.SelectedItem = cmbMatchUsingCustom.SelectedItem = mciWindowClass;
		}

		private void PopulateApplicationInfo()
		{
			alvRunningApplications.MatchUsing = MatchUsing.WindowClass;
			alvRunningApplications.SelectSimilar("");
			SelectMatchUsing(cmbMatchUsingRunning, MatchUsing.WindowClass);

			if (SelectedApplication == null)
			{
				txtApplicationName.Text = "";
				SelectMatchUsing(cmbMatchUsingCustom, MatchUsing.WindowClass);
				txtMatchString.Text = "";
				chkRegex.Checked = false;
				tcApplications.SelectedIndex = (int)TabType.Running;
				return;
			}

			txtApplicationName.Text = SelectedApplication.Name;
			SelectMatchUsing(cmbMatchUsingCustom, SelectedApplication.MatchUsing);
			txtMatchString.Text = SelectedApplication.MatchString;
			chkRegex.Checked = SelectedApplication.IsRegEx;
			tcApplications.SelectedIndex = (int)TabType.Custom;
		}

		private void SelectMatchUsing(ComboBox MatchUsingList, MatchUsing Value)
		{
			MatchUsingList.SelectedItem = MatchUsingList.Items.Cast<MatchUsingComboBoxItem>().FirstOrDefault(ci => ci.MatchUsing == Value);
		}

		#endregion

		#region Type Methods

		public static bool ValidateFilepath(string path)
		{
			if (path.Trim() == String.Empty)
				return false;

			string pathname;
			string filename;

			try
			{
				pathname = Path.GetPathRoot(path);
				filename = Path.GetFileName(path);
			}
			catch (ArgumentException)
			{
				// GetPathRoot() and GetFileName() above will throw exceptions
				// if pathname/filename could not be parsed.

				return false;
			}

			// Make sure the filename part was actually specified
			if (filename.Trim() == String.Empty)
				return false;

			// Not sure if additional checking below is needed, but no harm done
			if (pathname.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
				return false;

			if (filename.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
				return false;

			return true;
		}

		#endregion
	}
}
