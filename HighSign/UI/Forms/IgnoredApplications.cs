using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using HighSign.Common;
using HighSign.Common.Input;
using HighSign.Input;
using HighSign.Applications;
using HighSign.Common.Applications;



namespace HighSign.UI.Forms
{
	public partial class IgnoredApplications : Form
	{

		public IgnoredApplications()
		{
			InitializeComponent();
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnAddRunning.Click += new System.EventHandler(this.btnAddRunning_Click);
			this.alvRunningApplications.SelectedIndexChanged += (o, e) => { EnableButtons(); };
			this.lstIgnoredApplications.SelectedIndexChanged += (o, e) => { EnableButtons(); };
			this.txtFile.TextChanged += (o, e) => { EnableButtons(); };
			this.txtClass.TextChanged += (o, e) => { EnableButtons(); };
			this.btnClassAddManual.Click += new System.EventHandler(this.btnClassAddManual_Click);
			this.cboApplicationType.SelectedIndexChanged += new System.EventHandler(this.cboApplicationType_SelectedIndexChanged);
			this.btnFileAddManual.Click += new System.EventHandler(this.btnFileAddManual_Click);
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			this.crosshairMain.CrosshairDragged += new System.EventHandler(this.crosshairMain_CrosshairDragged);
			this.crosshairMain.CrosshairDragging += new System.EventHandler(this.crosshairMain_CrosshairDragging);
			this.txtTitle.TextChanged += (o, e) => { EnableButtons(); };
			this.btnTitleAddManual.Click += new System.EventHandler(this.btnTitleAddManual_Click);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.alvRunningApplications.DoubleClick += new System.EventHandler(this.btnAddRunning_Click);
		}

		private void IgnoredApplications_Load(object sender, EventArgs e)
		{
			cboApplicationType.SelectedIndex = 0;
			grpRunningApplications.Visible = true;
			grpFile.Visible = false;
			grpClass.Visible = false;
			grpTitle.Visible = false;
			grpCrosshair.Visible = false;
			BindIgnoredApplications();
			EnableButtons();
		}

		private void BindIgnoredApplications()
		{
			lstIgnoredApplications.Items.Clear();

			ListViewGroup grpIgnoredByFileName = new ListViewGroup("Ignored By Executable Name");
			lstIgnoredApplications.Groups.Add(grpIgnoredByFileName);

			ListViewGroup grpIgnoredByClassName = new ListViewGroup("Ignored By Window Class");
			lstIgnoredApplications.Groups.Add(grpIgnoredByClassName);

			ListViewGroup grpIgnoredByTitle = new ListViewGroup("Ignored By Window Title");
			lstIgnoredApplications.Groups.Add(grpIgnoredByTitle);

			ListViewGroup grpIgnoredByTitlePattern = new ListViewGroup("Ignored By Window Title Pattern");
			lstIgnoredApplications.Groups.Add(grpIgnoredByTitlePattern);

			IApplication[] lstApplications = Applications.ApplicationManager.Instance.GetIgnoredApplications();

			foreach (IgnoredApplication App in lstApplications)
			{
				ListViewItem newItem = null;
				switch (App.MatchUsing)
				{
					case MatchUsing.ExecutableFilename :
						newItem = new ListViewItem(grpIgnoredByFileName);
						newItem.Group = grpIgnoredByFileName;
						break;

					case MatchUsing.WindowClass :
						newItem = new ListViewItem(grpIgnoredByClassName);
						newItem.Group = grpIgnoredByClassName;
						break;

					case MatchUsing.WindowTitle :
						newItem = new ListViewItem(grpIgnoredByTitle);
						newItem.Group = grpIgnoredByTitle;
						break;
				}
			
				newItem.Text = App.Name;
				ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
				subItem.Text = "Match as pattern: "+App.IsRegEx.ToString();
				newItem.SubItems.Add(subItem);
				lstIgnoredApplications.Items.Add(newItem);
			}
		}



		private void cboApplicationType_SelectedIndexChanged(object sender, EventArgs e)
		{
			grpRunningApplications.Visible = !grpRunningApplications.Visible;
			grpFile.Visible = !grpFile.Visible;
			grpClass.Visible = !grpClass.Visible;
			grpTitle.Visible = !grpTitle.Visible;
			grpCrosshair.Visible = !grpCrosshair.Visible;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnAddRunning_Click(object sender, EventArgs e)
		{
			if (alvRunningApplications.SelectedIndices.Count == 0)
				return;
			AddIgnoredApplication("File: " + alvRunningApplications.SelectedApplication.WindowFilename, alvRunningApplications.SelectedApplication.WindowFilename, MatchUsing.ExecutableFilename, false);
			EnableButtons();
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			if (dlgOpen.ShowDialog() == DialogResult.OK)
				txtFile.Text = dlgOpen.SafeFileName;
		}

		private void crosshairMain_CrosshairDragging(object sender, EventArgs e)
		{
			if (this.Visible && chkCrosshairHide.Checked)
				this.Opacity = 0.00;
			txtFile.Text = Path.GetFileName(HighSign.Applications.ApplicationManager.Instance.GetWindowFromPoint(Cursor.Position).Process.MainModule.FileName);
			txtClass.Text = HighSign.Applications.ApplicationManager.Instance.GetWindowFromPoint(Cursor.Position).ClassName;
			txtTitle.Text = HighSign.Applications.ApplicationManager.Instance.GetWindowFromPoint(Cursor.Position).Title;
		}

		private void crosshairMain_CrosshairDragged(object sender, EventArgs e)
		{
			if (chkCrosshairHide.Checked)
				this.Opacity = 1.00;
		}

		private void btnFileAddManual_Click(object sender, EventArgs e)
		{
			AddIgnoredApplication("File: "+txtFile.Text, txtFile.Text, MatchUsing.ExecutableFilename, chkFilePattern.Checked);
			ClearManualFields();
			EnableButtons();
		}

		private void btnClassAddManual_Click(object sender, EventArgs e)
		{
			AddIgnoredApplication("Class: " + txtClass.Text, txtClass.Text, MatchUsing.WindowClass, chkClassPattern.Checked);
			ClearManualFields();
			EnableButtons();
		}

		private void btnTitleAddManual_Click(object sender, EventArgs e)
		{
			AddIgnoredApplication("Title: " + txtTitle.Text, txtTitle.Text, MatchUsing.WindowTitle, chkTitlePattern.Checked);
			ClearManualFields();
			EnableButtons();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			MessageBox.Show("May or may not implement, may add unnecessary effort for a rarely needed functionality at this point..");
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem lvItem in lstIgnoredApplications.SelectedItems)
				RemoveIgnoredApplication(lvItem.Text);
			ApplicationManager.Instance.SaveApplications();
			BindIgnoredApplications();
			EnableButtons();
		}

		private void AddIgnoredApplication(String Name, String MatchString, MatchUsing MatchUsing, bool IsRegEx)
		{
			if (ApplicationManager.Instance.ApplicationExists(Name))
				return;
			ApplicationManager.Instance.AddApplication(new IgnoredApplication(Name, MatchUsing, MatchString, IsRegEx));
			ApplicationManager.Instance.SaveApplications();
			BindIgnoredApplications();
		}

		private void RemoveIgnoredApplication(string Name)
		{
			ApplicationManager.Instance.RemoveApplication(ApplicationManager.Instance.GetIgnoredApplications().Single(a => a.Name == Name)); 
		}

		private void ClearManualFields()
		{
			txtFile.Text = "";
			txtClass.Text = "";
			txtTitle.Text = "";
		}

		private void EnableButtons()
		{
			if (alvRunningApplications.SelectedIndices.Count > 0)
				btnAddRunning.Enabled = true;
			else
				btnAddRunning.Enabled = false;

			if (lstIgnoredApplications.SelectedIndices.Count > 0)
			{
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
			}
			else
			{
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
			}

			if (txtFile.Text.Length > 0)
				btnFileAddManual.Enabled = true;
			else
				btnFileAddManual.Enabled = false;

			if (txtClass.Text.Length > 0)
				btnClassAddManual.Enabled = true;
			else
				btnClassAddManual.Enabled = false;

			if (txtTitle.Text.Length > 0)
				btnTitleAddManual.Enabled = true;
			else
				btnTitleAddManual.Enabled = false;
		}

	}
}
