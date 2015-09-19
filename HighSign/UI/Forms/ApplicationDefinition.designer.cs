namespace HighSign.UI.Forms
{
	partial class ApplicationDefinition
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
			this.components = new System.ComponentModel.Container();
			this.imgApplicationIcons = new System.Windows.Forms.ImageList(this.components);
			this.grpApplications = new System.Windows.Forms.GroupBox();
			this.cmbExistingApplication = new System.Windows.Forms.ComboBox();
			this.txtFriendlyName = new System.Windows.Forms.TextBox();
			this.lblFriendlyName = new System.Windows.Forms.Label();
			this.lblMatchUsing = new System.Windows.Forms.Label();
			this.cmbMatchCriteria = new System.Windows.Forms.ComboBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdNext = new System.Windows.Forms.Button();
			this.grpRunningApplications = new System.Windows.Forms.GroupBox();
			this.cmdRefresh = new System.Windows.Forms.Button();
			this.lstRunningApplications = new HighSign.Common.UI.Controls.ApplicationListView();
			this.grpApplications.SuspendLayout();
			this.grpRunningApplications.SuspendLayout();
			this.SuspendLayout();
			// 
			// imgApplicationIcons
			// 
			this.imgApplicationIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imgApplicationIcons.ImageSize = new System.Drawing.Size(35, 25);
			this.imgApplicationIcons.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// grpApplications
			// 
			this.grpApplications.Controls.Add(this.cmbExistingApplication);
			this.grpApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpApplications.Location = new System.Drawing.Point(12, 12);
			this.grpApplications.Name = "grpApplications";
			this.grpApplications.Size = new System.Drawing.Size(400, 62);
			this.grpApplications.TabIndex = 1;
			this.grpApplications.TabStop = false;
			this.grpApplications.Text = "What application do you want to control?";
			// 
			// cmbExistingApplication
			// 
			this.cmbExistingApplication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbExistingApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbExistingApplication.FormattingEnabled = true;
			this.cmbExistingApplication.Location = new System.Drawing.Point(11, 25);
			this.cmbExistingApplication.Name = "cmbExistingApplication";
			this.cmbExistingApplication.Size = new System.Drawing.Size(378, 24);
			this.cmbExistingApplication.TabIndex = 5;
			// 
			// txtFriendlyName
			// 
			this.txtFriendlyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtFriendlyName.Location = new System.Drawing.Point(105, 274);
			this.txtFriendlyName.Name = "txtFriendlyName";
			this.txtFriendlyName.Size = new System.Drawing.Size(284, 23);
			this.txtFriendlyName.TabIndex = 4;
			// 
			// lblFriendlyName
			// 
			this.lblFriendlyName.AutoSize = true;
			this.lblFriendlyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFriendlyName.Location = new System.Drawing.Point(54, 277);
			this.lblFriendlyName.Name = "lblFriendlyName";
			this.lblFriendlyName.Size = new System.Drawing.Size(45, 17);
			this.lblFriendlyName.TabIndex = 3;
			this.lblFriendlyName.Text = "Name";
			// 
			// lblMatchUsing
			// 
			this.lblMatchUsing.AutoSize = true;
			this.lblMatchUsing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMatchUsing.Location = new System.Drawing.Point(13, 247);
			this.lblMatchUsing.Name = "lblMatchUsing";
			this.lblMatchUsing.Size = new System.Drawing.Size(86, 17);
			this.lblMatchUsing.TabIndex = 2;
			this.lblMatchUsing.Text = "Match Using";
			// 
			// cmbMatchCriteria
			// 
			this.cmbMatchCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMatchCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbMatchCriteria.FormattingEnabled = true;
			this.cmbMatchCriteria.Items.AddRange(new object[] {
            "Window Class Name",
            "Window Title",
            "Executable Filename"});
			this.cmbMatchCriteria.Location = new System.Drawing.Point(105, 244);
			this.cmbMatchCriteria.Name = "cmbMatchCriteria";
			this.cmbMatchCriteria.Size = new System.Drawing.Size(189, 24);
			this.cmbMatchCriteria.TabIndex = 1;
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.Location = new System.Drawing.Point(12, 397);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 7;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// cmdNext
			// 
			this.cmdNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdNext.Location = new System.Drawing.Point(338, 397);
			this.cmdNext.Name = "cmdNext";
			this.cmdNext.Size = new System.Drawing.Size(75, 23);
			this.cmdNext.TabIndex = 6;
			this.cmdNext.Text = "Next";
			this.cmdNext.UseVisualStyleBackColor = true;
			// 
			// grpRunningApplications
			// 
			this.grpRunningApplications.Controls.Add(this.lstRunningApplications);
			this.grpRunningApplications.Controls.Add(this.cmdRefresh);
			this.grpRunningApplications.Controls.Add(this.txtFriendlyName);
			this.grpRunningApplications.Controls.Add(this.cmbMatchCriteria);
			this.grpRunningApplications.Controls.Add(this.lblFriendlyName);
			this.grpRunningApplications.Controls.Add(this.lblMatchUsing);
			this.grpRunningApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpRunningApplications.Location = new System.Drawing.Point(12, 80);
			this.grpRunningApplications.Name = "grpRunningApplications";
			this.grpRunningApplications.Size = new System.Drawing.Size(400, 310);
			this.grpRunningApplications.TabIndex = 8;
			this.grpRunningApplications.TabStop = false;
			this.grpRunningApplications.Text = "Select a Running Application";
			// 
			// cmdRefresh
			// 
			this.cmdRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdRefresh.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.cmdRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.cmdRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.cmdRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRefresh.Image = global::HighSign.Properties.Resources.Refresh;
			this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdRefresh.Location = new System.Drawing.Point(300, 244);
			this.cmdRefresh.Name = "cmdRefresh";
			this.cmdRefresh.Size = new System.Drawing.Size(89, 24);
			this.cmdRefresh.TabIndex = 5;
			this.cmdRefresh.Text = "Refresh List";
			this.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdRefresh.UseVisualStyleBackColor = true;
			// 
			// lstRunningApplications
			// 
			this.lstRunningApplications.Location = new System.Drawing.Point(11, 22);
			this.lstRunningApplications.MatchUsing = HighSign.Common.Applications.MatchUsing.WindowClass;
			this.lstRunningApplications.Name = "lstRunningApplications";
			this.lstRunningApplications.Size = new System.Drawing.Size(378, 216);
			this.lstRunningApplications.TabIndex = 6;
			this.lstRunningApplications.UseCompatibleStateImageBehavior = false;
			this.lstRunningApplications.Windows = null;
			// 
			// ApplicationDefinition
			// 
			this.AcceptButton = this.cmdNext;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(425, 430);
			this.Controls.Add(this.grpRunningApplications);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdNext);
			this.Controls.Add(this.grpApplications);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ApplicationDefinition";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Application Definition";
			this.TopMost = true;
			this.grpApplications.ResumeLayout(false);
			this.grpRunningApplications.ResumeLayout(false);
			this.grpRunningApplications.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ImageList imgApplicationIcons;
		private System.Windows.Forms.GroupBox grpApplications;
		private System.Windows.Forms.ComboBox cmbMatchCriteria;
		private System.Windows.Forms.Label lblMatchUsing;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdNext;
		private System.Windows.Forms.TextBox txtFriendlyName;
		private System.Windows.Forms.Label lblFriendlyName;
		private System.Windows.Forms.ComboBox cmbExistingApplication;
		private System.Windows.Forms.GroupBox grpRunningApplications;
		private System.Windows.Forms.Button cmdRefresh;
		private HighSign.Common.UI.Controls.ApplicationListView lstRunningApplications;
	}
}

