namespace HighSign.UI.Forms
{
	partial class IgnoredApplications
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IgnoredApplications));
			this.btnClose = new System.Windows.Forms.Button();
			this.grpIgnoredApplications = new System.Windows.Forms.GroupBox();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.lstIgnoredApplications = new System.Windows.Forms.ListView();
			this.clmName = new System.Windows.Forms.ColumnHeader();
			this.clmDescription = new System.Windows.Forms.ColumnHeader();
			this.grpRunningApplications = new System.Windows.Forms.GroupBox();
			this.alvRunningApplications = new HighSign.Common.UI.Controls.ApplicationListView();
			this.btnAddRunning = new System.Windows.Forms.Button();
			this.grpIgnoreWhat = new System.Windows.Forms.GroupBox();
			this.cboApplicationType = new System.Windows.Forms.ComboBox();
			this.grpFile = new System.Windows.Forms.GroupBox();
			this.chkFilePattern = new System.Windows.Forms.CheckBox();
			this.btnFileAddManual = new System.Windows.Forms.Button();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.grpClass = new System.Windows.Forms.GroupBox();
			this.chkClassPattern = new System.Windows.Forms.CheckBox();
			this.txtClass = new System.Windows.Forms.TextBox();
			this.btnClassAddManual = new System.Windows.Forms.Button();
			this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.grpCrosshair = new System.Windows.Forms.GroupBox();
			this.chkCrosshairHide = new System.Windows.Forms.CheckBox();
			this.lblCrosshair = new System.Windows.Forms.Label();
			this.crosshairMain = new ManagedWinapi.Crosshair();
			this.grpTitle = new System.Windows.Forms.GroupBox();
			this.chkTitlePattern = new System.Windows.Forms.CheckBox();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.btnTitleAddManual = new System.Windows.Forms.Button();
			this.grpIgnoredApplications.SuspendLayout();
			this.grpRunningApplications.SuspendLayout();
			this.grpIgnoreWhat.SuspendLayout();
			this.grpFile.SuspendLayout();
			this.grpClass.SuspendLayout();
			this.grpCrosshair.SuspendLayout();
			this.grpTitle.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(765, 473);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// grpIgnoredApplications
			// 
			this.grpIgnoredApplications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpIgnoredApplications.Controls.Add(this.btnEdit);
			this.grpIgnoredApplications.Controls.Add(this.btnDelete);
			this.grpIgnoredApplications.Controls.Add(this.lstIgnoredApplications);
			this.grpIgnoredApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.grpIgnoredApplications.Location = new System.Drawing.Point(463, 12);
			this.grpIgnoredApplications.Name = "grpIgnoredApplications";
			this.grpIgnoredApplications.Size = new System.Drawing.Size(377, 455);
			this.grpIgnoredApplications.TabIndex = 5;
			this.grpIgnoredApplications.TabStop = false;
			this.grpIgnoredApplications.Text = "Current Ignore Rules";
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Image = global::HighSign.Properties.Resources.Edit;
			this.btnEdit.Location = new System.Drawing.Point(341, 58);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(30, 30);
			this.btnEdit.TabIndex = 7;
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Visible = false;
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Image = global::HighSign.Properties.Resources.DeleteIcon;
			this.btnDelete.Location = new System.Drawing.Point(341, 22);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(30, 30);
			this.btnDelete.TabIndex = 6;
			this.btnDelete.UseVisualStyleBackColor = true;
			// 
			// lstIgnoredApplications
			// 
			this.lstIgnoredApplications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lstIgnoredApplications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmDescription});
			this.lstIgnoredApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstIgnoredApplications.HideSelection = false;
			this.lstIgnoredApplications.Location = new System.Drawing.Point(15, 22);
			this.lstIgnoredApplications.Name = "lstIgnoredApplications";
			this.lstIgnoredApplications.Size = new System.Drawing.Size(320, 417);
			this.lstIgnoredApplications.TabIndex = 1;
			this.lstIgnoredApplications.TileSize = new System.Drawing.Size(250, 38);
			this.lstIgnoredApplications.UseCompatibleStateImageBehavior = false;
			this.lstIgnoredApplications.View = System.Windows.Forms.View.Tile;
			// 
			// clmName
			// 
			this.clmName.Text = "Name";
			// 
			// clmDescription
			// 
			this.clmDescription.Text = "Description";
			// 
			// grpRunningApplications
			// 
			this.grpRunningApplications.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.grpRunningApplications.Controls.Add(this.alvRunningApplications);
			this.grpRunningApplications.Controls.Add(this.btnAddRunning);
			this.grpRunningApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.grpRunningApplications.Location = new System.Drawing.Point(0, 0);
			this.grpRunningApplications.Name = "grpRunningApplications";
			this.grpRunningApplications.Size = new System.Drawing.Size(445, 391);
			this.grpRunningApplications.TabIndex = 6;
			this.grpRunningApplications.TabStop = false;
			this.grpRunningApplications.Text = "Running Applications";
			// 
			// alvRunningApplications
			// 
			this.alvRunningApplications.Location = new System.Drawing.Point(15, 22);
			this.alvRunningApplications.MatchUsing = HighSign.Common.Applications.MatchUsing.WindowClass;
			this.alvRunningApplications.Name = "alvRunningApplications";
			this.alvRunningApplications.Size = new System.Drawing.Size(412, 353);
			this.alvRunningApplications.TabIndex = 14;
			this.alvRunningApplications.UseCompatibleStateImageBehavior = false;
			this.alvRunningApplications.Windows = null;
			// 
			// btnAddRunning
			// 
			this.btnAddRunning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddRunning.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.btnAddRunning.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.btnAddRunning.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.btnAddRunning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddRunning.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRunning.Image")));
			this.btnAddRunning.Location = new System.Drawing.Point(397, 25);
			this.btnAddRunning.Name = "btnAddRunning";
			this.btnAddRunning.Size = new System.Drawing.Size(30, 30);
			this.btnAddRunning.TabIndex = 9;
			this.btnAddRunning.UseVisualStyleBackColor = true;
			// 
			// grpIgnoreWhat
			// 
			this.grpIgnoreWhat.Controls.Add(this.cboApplicationType);
			this.grpIgnoreWhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.grpIgnoreWhat.Location = new System.Drawing.Point(12, 12);
			this.grpIgnoreWhat.Name = "grpIgnoreWhat";
			this.grpIgnoreWhat.Size = new System.Drawing.Size(445, 58);
			this.grpIgnoreWhat.TabIndex = 7;
			this.grpIgnoreWhat.TabStop = false;
			this.grpIgnoreWhat.Text = "What application do you want to ignore?";
			// 
			// cboApplicationType
			// 
			this.cboApplicationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboApplicationType.FormattingEnabled = true;
			this.cboApplicationType.Items.AddRange(new object[] {
            "Select from list of running applications",
            "Create your own rule for what to ignore"});
			this.cboApplicationType.Location = new System.Drawing.Point(15, 23);
			this.cboApplicationType.Name = "cboApplicationType";
			this.cboApplicationType.Size = new System.Drawing.Size(412, 26);
			this.cboApplicationType.TabIndex = 0;
			// 
			// grpFile
			// 
			this.grpFile.Controls.Add(this.chkFilePattern);
			this.grpFile.Controls.Add(this.btnFileAddManual);
			this.grpFile.Controls.Add(this.btnBrowse);
			this.grpFile.Controls.Add(this.txtFile);
			this.grpFile.Controls.Add(this.grpRunningApplications);
			this.grpFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.grpFile.Location = new System.Drawing.Point(12, 76);
			this.grpFile.Name = "grpFile";
			this.grpFile.Size = new System.Drawing.Size(445, 87);
			this.grpFile.TabIndex = 0;
			this.grpFile.TabStop = false;
			this.grpFile.Text = "Executable Name";
			this.grpFile.Visible = false;
			// 
			// chkFilePattern
			// 
			this.chkFilePattern.AutoSize = true;
			this.chkFilePattern.Location = new System.Drawing.Point(15, 52);
			this.chkFilePattern.Name = "chkFilePattern";
			this.chkFilePattern.Size = new System.Drawing.Size(133, 21);
			this.chkFilePattern.TabIndex = 12;
			this.chkFilePattern.Text = "Match as pattern";
			this.chkFilePattern.UseVisualStyleBackColor = true;
			// 
			// btnFileAddManual
			// 
			this.btnFileAddManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFileAddManual.Image = ((System.Drawing.Image)(resources.GetObject("btnFileAddManual.Image")));
			this.btnFileAddManual.Location = new System.Drawing.Point(398, 16);
			this.btnFileAddManual.Name = "btnFileAddManual";
			this.btnFileAddManual.Size = new System.Drawing.Size(30, 30);
			this.btnFileAddManual.TabIndex = 11;
			this.btnFileAddManual.UseVisualStyleBackColor = true;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.btnBrowse.Location = new System.Drawing.Point(279, 23);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "Browse...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			// 
			// txtFile
			// 
			this.txtFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.txtFile.Location = new System.Drawing.Point(15, 25);
			this.txtFile.Name = "txtFile";
			this.txtFile.Size = new System.Drawing.Size(258, 21);
			this.txtFile.TabIndex = 0;
			// 
			// grpClass
			// 
			this.grpClass.Controls.Add(this.chkClassPattern);
			this.grpClass.Controls.Add(this.txtClass);
			this.grpClass.Controls.Add(this.btnClassAddManual);
			this.grpClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.grpClass.Location = new System.Drawing.Point(12, 168);
			this.grpClass.Name = "grpClass";
			this.grpClass.Size = new System.Drawing.Size(445, 87);
			this.grpClass.TabIndex = 1;
			this.grpClass.TabStop = false;
			this.grpClass.Text = "Window Class";
			this.grpClass.Visible = false;
			// 
			// chkClassPattern
			// 
			this.chkClassPattern.AutoSize = true;
			this.chkClassPattern.Location = new System.Drawing.Point(15, 53);
			this.chkClassPattern.Name = "chkClassPattern";
			this.chkClassPattern.Size = new System.Drawing.Size(133, 21);
			this.chkClassPattern.TabIndex = 9;
			this.chkClassPattern.Text = "Match as pattern";
			this.chkClassPattern.UseVisualStyleBackColor = true;
			// 
			// txtClass
			// 
			this.txtClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.txtClass.Location = new System.Drawing.Point(15, 26);
			this.txtClass.Name = "txtClass";
			this.txtClass.Size = new System.Drawing.Size(339, 21);
			this.txtClass.TabIndex = 8;
			// 
			// btnClassAddManual
			// 
			this.btnClassAddManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClassAddManual.Image = ((System.Drawing.Image)(resources.GetObject("btnClassAddManual.Image")));
			this.btnClassAddManual.Location = new System.Drawing.Point(397, 22);
			this.btnClassAddManual.Name = "btnClassAddManual";
			this.btnClassAddManual.Size = new System.Drawing.Size(30, 30);
			this.btnClassAddManual.TabIndex = 7;
			this.btnClassAddManual.UseVisualStyleBackColor = true;
			// 
			// dlgOpen
			// 
			this.dlgOpen.Filter = "Programs|*.exe";
			// 
			// grpCrosshair
			// 
			this.grpCrosshair.Controls.Add(this.chkCrosshairHide);
			this.grpCrosshair.Controls.Add(this.lblCrosshair);
			this.grpCrosshair.Controls.Add(this.crosshairMain);
			this.grpCrosshair.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.grpCrosshair.Location = new System.Drawing.Point(12, 352);
			this.grpCrosshair.Name = "grpCrosshair";
			this.grpCrosshair.Size = new System.Drawing.Size(445, 115);
			this.grpCrosshair.TabIndex = 10;
			this.grpCrosshair.TabStop = false;
			this.grpCrosshair.Text = "Locate Window";
			// 
			// chkCrosshairHide
			// 
			this.chkCrosshairHide.AutoSize = true;
			this.chkCrosshairHide.Location = new System.Drawing.Point(15, 77);
			this.chkCrosshairHide.Name = "chkCrosshairHide";
			this.chkCrosshairHide.Size = new System.Drawing.Size(312, 21);
			this.chkCrosshairHide.TabIndex = 12;
			this.chkCrosshairHide.Text = "Hide this window while dragging the crosshair";
			this.chkCrosshairHide.UseVisualStyleBackColor = true;
			// 
			// lblCrosshair
			// 
			this.lblCrosshair.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.lblCrosshair.Location = new System.Drawing.Point(12, 25);
			this.lblCrosshair.Name = "lblCrosshair";
			this.lblCrosshair.Size = new System.Drawing.Size(326, 34);
			this.lblCrosshair.TabIndex = 11;
			this.lblCrosshair.Text = "Drag and drop the crosshair on the window you would like High Sign to ignore.";
			// 
			// crosshairMain
			// 
			this.crosshairMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.crosshairMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.crosshairMain.Location = new System.Drawing.Point(392, 24);
			this.crosshairMain.Margin = new System.Windows.Forms.Padding(4);
			this.crosshairMain.Name = "crosshairMain";
			this.crosshairMain.Size = new System.Drawing.Size(35, 35);
			this.crosshairMain.TabIndex = 10;
			// 
			// grpTitle
			// 
			this.grpTitle.Controls.Add(this.chkTitlePattern);
			this.grpTitle.Controls.Add(this.txtTitle);
			this.grpTitle.Controls.Add(this.btnTitleAddManual);
			this.grpTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.grpTitle.Location = new System.Drawing.Point(12, 260);
			this.grpTitle.Name = "grpTitle";
			this.grpTitle.Size = new System.Drawing.Size(445, 87);
			this.grpTitle.TabIndex = 11;
			this.grpTitle.TabStop = false;
			this.grpTitle.Text = "Window Title";
			this.grpTitle.Visible = false;
			// 
			// chkTitlePattern
			// 
			this.chkTitlePattern.AutoSize = true;
			this.chkTitlePattern.Location = new System.Drawing.Point(15, 53);
			this.chkTitlePattern.Name = "chkTitlePattern";
			this.chkTitlePattern.Size = new System.Drawing.Size(133, 21);
			this.chkTitlePattern.TabIndex = 10;
			this.chkTitlePattern.Text = "Match as pattern";
			this.chkTitlePattern.UseVisualStyleBackColor = true;
			// 
			// txtTitle
			// 
			this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.txtTitle.Location = new System.Drawing.Point(15, 26);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(339, 21);
			this.txtTitle.TabIndex = 9;
			// 
			// btnTitleAddManual
			// 
			this.btnTitleAddManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTitleAddManual.Image = ((System.Drawing.Image)(resources.GetObject("btnTitleAddManual.Image")));
			this.btnTitleAddManual.Location = new System.Drawing.Point(397, 22);
			this.btnTitleAddManual.Name = "btnTitleAddManual";
			this.btnTitleAddManual.Size = new System.Drawing.Size(30, 30);
			this.btnTitleAddManual.TabIndex = 7;
			this.btnTitleAddManual.UseVisualStyleBackColor = true;
			// 
			// IgnoredApplications
			// 
			this.AcceptButton = this.btnClose;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(852, 508);
			this.Controls.Add(this.grpTitle);
			this.Controls.Add(this.grpCrosshair);
			this.Controls.Add(this.grpFile);
			this.Controls.Add(this.grpClass);
			this.Controls.Add(this.grpIgnoreWhat);
			this.Controls.Add(this.grpIgnoredApplications);
			this.Controls.Add(this.btnClose);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "IgnoredApplications";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Ignored Applications";
			this.Load += new System.EventHandler(this.IgnoredApplications_Load);
			this.grpIgnoredApplications.ResumeLayout(false);
			this.grpRunningApplications.ResumeLayout(false);
			this.grpIgnoreWhat.ResumeLayout(false);
			this.grpFile.ResumeLayout(false);
			this.grpFile.PerformLayout();
			this.grpClass.ResumeLayout(false);
			this.grpClass.PerformLayout();
			this.grpCrosshair.ResumeLayout(false);
			this.grpCrosshair.PerformLayout();
			this.grpTitle.ResumeLayout(false);
			this.grpTitle.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.GroupBox grpIgnoredApplications;
		private System.Windows.Forms.ListView lstIgnoredApplications;
		private System.Windows.Forms.ColumnHeader clmName;
		private System.Windows.Forms.ColumnHeader clmDescription;
		private System.Windows.Forms.GroupBox grpRunningApplications;
		private System.Windows.Forms.GroupBox grpIgnoreWhat;
		private System.Windows.Forms.ComboBox cboApplicationType;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnAddRunning;
		private System.Windows.Forms.GroupBox grpClass;
		private System.Windows.Forms.GroupBox grpFile;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.TextBox txtFile;
		private System.Windows.Forms.OpenFileDialog dlgOpen;
		private System.Windows.Forms.Button btnFileAddManual;
		private System.Windows.Forms.Button btnClassAddManual;
		private System.Windows.Forms.GroupBox grpCrosshair;
		private ManagedWinapi.Crosshair crosshairMain;
		private System.Windows.Forms.Label lblCrosshair;
		private System.Windows.Forms.GroupBox grpTitle;
		private System.Windows.Forms.Button btnTitleAddManual;
		private System.Windows.Forms.CheckBox chkFilePattern;
		private System.Windows.Forms.CheckBox chkClassPattern;
		private System.Windows.Forms.TextBox txtClass;
		private System.Windows.Forms.CheckBox chkTitlePattern;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.CheckBox chkCrosshairHide;
		private HighSign.Common.UI.Controls.ApplicationListView alvRunningApplications;
	}
}