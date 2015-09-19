namespace HighSign.Common.UI.Dialogs
{
	partial class ApplicationDialog
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
			this.grpSelectApplication = new System.Windows.Forms.GroupBox();
			this.cmbExistingApplication = new System.Windows.Forms.ComboBox();
			this.tcApplications = new System.Windows.Forms.TabControl();
			this.tpRunningApplications = new System.Windows.Forms.TabPage();
			this.pnlRunningApplications = new System.Windows.Forms.Panel();
			this.cmbMatchUsingRunning = new System.Windows.Forms.ComboBox();
			this.lblMatchUsing1 = new System.Windows.Forms.Label();
			this.cmsRunningApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmiRefreshApplications = new System.Windows.Forms.ToolStripMenuItem();
			this.tpCustomApplication = new System.Windows.Forms.TabPage();
			this.pnlCustomApplication = new System.Windows.Forms.Panel();
			this.chkRegex = new System.Windows.Forms.CheckBox();
			this.cmbMatchUsingCustom = new System.Windows.Forms.ComboBox();
			this.txtMatchString = new System.Windows.Forms.TextBox();
			this.lblMatchUsing2 = new System.Windows.Forms.Label();
			this.lblMatchString = new System.Windows.Forms.Label();
			this.cmdDone = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.chCrosshair = new ManagedWinapi.Crosshair();
			this.lblCrosshair = new System.Windows.Forms.Label();
			this.pnlBody = new System.Windows.Forms.Panel();
			this.txtApplicationName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.pnlCrosshair = new System.Windows.Forms.Panel();
			this.pnlControls = new System.Windows.Forms.Panel();
			this.ofdExecutable = new System.Windows.Forms.OpenFileDialog();
			this.cmdBrowse = new System.Windows.Forms.Button();
			this.alvRunningApplications = new HighSign.Common.UI.Controls.ApplicationListView();
			this.grpSelectApplication.SuspendLayout();
			this.tcApplications.SuspendLayout();
			this.tpRunningApplications.SuspendLayout();
			this.pnlRunningApplications.SuspendLayout();
			this.cmsRunningApplications.SuspendLayout();
			this.tpCustomApplication.SuspendLayout();
			this.pnlCustomApplication.SuspendLayout();
			this.pnlBody.SuspendLayout();
			this.pnlCrosshair.SuspendLayout();
			this.pnlControls.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpSelectApplication
			// 
			this.grpSelectApplication.Controls.Add(this.cmbExistingApplication);
			this.grpSelectApplication.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpSelectApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpSelectApplication.Location = new System.Drawing.Point(10, 10);
			this.grpSelectApplication.Margin = new System.Windows.Forms.Padding(4);
			this.grpSelectApplication.Name = "grpSelectApplication";
			this.grpSelectApplication.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
			this.grpSelectApplication.Size = new System.Drawing.Size(334, 55);
			this.grpSelectApplication.TabIndex = 1;
			this.grpSelectApplication.TabStop = false;
			this.grpSelectApplication.Text = "Select Application";
			// 
			// cmbExistingApplication
			// 
			this.cmbExistingApplication.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cmbExistingApplication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbExistingApplication.FormattingEnabled = true;
			this.cmbExistingApplication.Location = new System.Drawing.Point(8, 22);
			this.cmbExistingApplication.Margin = new System.Windows.Forms.Padding(4);
			this.cmbExistingApplication.Name = "cmbExistingApplication";
			this.cmbExistingApplication.Size = new System.Drawing.Size(318, 24);
			this.cmbExistingApplication.TabIndex = 0;
			// 
			// tcApplications
			// 
			this.tcApplications.Controls.Add(this.tpRunningApplications);
			this.tcApplications.Controls.Add(this.tpCustomApplication);
			this.tcApplications.Dock = System.Windows.Forms.DockStyle.Top;
			this.tcApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tcApplications.Location = new System.Drawing.Point(0, 40);
			this.tcApplications.Margin = new System.Windows.Forms.Padding(4);
			this.tcApplications.Name = "tcApplications";
			this.tcApplications.SelectedIndex = 0;
			this.tcApplications.Size = new System.Drawing.Size(334, 300);
			this.tcApplications.TabIndex = 2;
			// 
			// tpRunningApplications
			// 
			this.tpRunningApplications.Controls.Add(this.pnlRunningApplications);
			this.tpRunningApplications.Location = new System.Drawing.Point(4, 25);
			this.tpRunningApplications.Margin = new System.Windows.Forms.Padding(4);
			this.tpRunningApplications.Name = "tpRunningApplications";
			this.tpRunningApplications.Padding = new System.Windows.Forms.Padding(4);
			this.tpRunningApplications.Size = new System.Drawing.Size(326, 271);
			this.tpRunningApplications.TabIndex = 0;
			this.tpRunningApplications.Text = "Running Applications";
			this.tpRunningApplications.UseVisualStyleBackColor = true;
			// 
			// pnlRunningApplications
			// 
			this.pnlRunningApplications.AutoSize = true;
			this.pnlRunningApplications.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.pnlRunningApplications.BackColor = System.Drawing.Color.White;
			this.pnlRunningApplications.Controls.Add(this.cmbMatchUsingRunning);
			this.pnlRunningApplications.Controls.Add(this.lblMatchUsing1);
			this.pnlRunningApplications.Controls.Add(this.alvRunningApplications);
			this.pnlRunningApplications.Location = new System.Drawing.Point(0, 0);
			this.pnlRunningApplications.Margin = new System.Windows.Forms.Padding(0);
			this.pnlRunningApplications.Name = "pnlRunningApplications";
			this.pnlRunningApplications.Padding = new System.Windows.Forms.Padding(0, 10, 0, 9);
			this.pnlRunningApplications.Size = new System.Drawing.Size(324, 279);
			this.pnlRunningApplications.TabIndex = 0;
			// 
			// cmbMatchUsingRunning
			// 
			this.cmbMatchUsingRunning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMatchUsingRunning.FormattingEnabled = true;
			this.cmbMatchUsingRunning.Location = new System.Drawing.Point(100, 8);
			this.cmbMatchUsingRunning.Margin = new System.Windows.Forms.Padding(4);
			this.cmbMatchUsingRunning.Name = "cmbMatchUsingRunning";
			this.cmbMatchUsingRunning.Size = new System.Drawing.Size(220, 24);
			this.cmbMatchUsingRunning.TabIndex = 5;
			// 
			// lblMatchUsing1
			// 
			this.lblMatchUsing1.Location = new System.Drawing.Point(2, 7);
			this.lblMatchUsing1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblMatchUsing1.Name = "lblMatchUsing1";
			this.lblMatchUsing1.Size = new System.Drawing.Size(92, 24);
			this.lblMatchUsing1.TabIndex = 4;
			this.lblMatchUsing1.Text = "Match Using:";
			this.lblMatchUsing1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmsRunningApplications
			// 
			this.cmsRunningApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefreshApplications});
			this.cmsRunningApplications.Name = "cmsRunningApplications";
			this.cmsRunningApplications.ShowImageMargin = false;
			this.cmsRunningApplications.Size = new System.Drawing.Size(177, 26);
			// 
			// tsmiRefreshApplications
			// 
			this.tsmiRefreshApplications.Name = "tsmiRefreshApplications";
			this.tsmiRefreshApplications.ShortcutKeyDisplayString = "F5";
			this.tsmiRefreshApplications.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.tsmiRefreshApplications.Size = new System.Drawing.Size(176, 22);
			this.tsmiRefreshApplications.Text = "Refresh Applications";
			// 
			// tpCustomApplication
			// 
			this.tpCustomApplication.Controls.Add(this.pnlCustomApplication);
			this.tpCustomApplication.Location = new System.Drawing.Point(4, 25);
			this.tpCustomApplication.Margin = new System.Windows.Forms.Padding(4);
			this.tpCustomApplication.Name = "tpCustomApplication";
			this.tpCustomApplication.Padding = new System.Windows.Forms.Padding(4);
			this.tpCustomApplication.Size = new System.Drawing.Size(326, 271);
			this.tpCustomApplication.TabIndex = 1;
			this.tpCustomApplication.Text = "Custom Application";
			this.tpCustomApplication.UseVisualStyleBackColor = true;
			// 
			// pnlCustomApplication
			// 
			this.pnlCustomApplication.AutoSize = true;
			this.pnlCustomApplication.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.pnlCustomApplication.Controls.Add(this.cmdBrowse);
			this.pnlCustomApplication.Controls.Add(this.chkRegex);
			this.pnlCustomApplication.Controls.Add(this.cmbMatchUsingCustom);
			this.pnlCustomApplication.Controls.Add(this.txtMatchString);
			this.pnlCustomApplication.Controls.Add(this.lblMatchUsing2);
			this.pnlCustomApplication.Controls.Add(this.lblMatchString);
			this.pnlCustomApplication.Location = new System.Drawing.Point(0, 3);
			this.pnlCustomApplication.Margin = new System.Windows.Forms.Padding(0);
			this.pnlCustomApplication.Name = "pnlCustomApplication";
			this.pnlCustomApplication.Padding = new System.Windows.Forms.Padding(0, 10, 0, 14);
			this.pnlCustomApplication.Size = new System.Drawing.Size(323, 108);
			this.pnlCustomApplication.TabIndex = 5;
			// 
			// chkRegex
			// 
			this.chkRegex.AutoSize = true;
			this.chkRegex.Location = new System.Drawing.Point(100, 69);
			this.chkRegex.Name = "chkRegex";
			this.chkRegex.Size = new System.Drawing.Size(97, 21);
			this.chkRegex.TabIndex = 4;
			this.chkRegex.Text = "Use RegEx";
			this.chkRegex.UseVisualStyleBackColor = true;
			// 
			// cmbMatchUsingCustom
			// 
			this.cmbMatchUsingCustom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMatchUsingCustom.FormattingEnabled = true;
			this.cmbMatchUsingCustom.Location = new System.Drawing.Point(100, 5);
			this.cmbMatchUsingCustom.Name = "cmbMatchUsingCustom";
			this.cmbMatchUsingCustom.Size = new System.Drawing.Size(220, 24);
			this.cmbMatchUsingCustom.TabIndex = 1;
			// 
			// txtMatchString
			// 
			this.txtMatchString.Location = new System.Drawing.Point(100, 37);
			this.txtMatchString.Name = "txtMatchString";
			this.txtMatchString.Size = new System.Drawing.Size(220, 23);
			this.txtMatchString.TabIndex = 3;
			// 
			// lblMatchUsing2
			// 
			this.lblMatchUsing2.Location = new System.Drawing.Point(0, 4);
			this.lblMatchUsing2.Name = "lblMatchUsing2";
			this.lblMatchUsing2.Size = new System.Drawing.Size(94, 24);
			this.lblMatchUsing2.TabIndex = 2;
			this.lblMatchUsing2.Text = "Match Using:";
			this.lblMatchUsing2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblMatchString
			// 
			this.lblMatchString.Location = new System.Drawing.Point(3, 37);
			this.lblMatchString.Name = "lblMatchString";
			this.lblMatchString.Size = new System.Drawing.Size(91, 23);
			this.lblMatchString.TabIndex = 2;
			this.lblMatchString.Text = "Match String:";
			this.lblMatchString.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmdDone
			// 
			this.cmdDone.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdDone.Location = new System.Drawing.Point(249, 6);
			this.cmdDone.Margin = new System.Windows.Forms.Padding(4);
			this.cmdDone.Name = "cmdDone";
			this.cmdDone.Size = new System.Drawing.Size(85, 28);
			this.cmdDone.TabIndex = 3;
			this.cmdDone.Text = "Done";
			this.cmdDone.UseVisualStyleBackColor = true;
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(0, 6);
			this.cmdCancel.Margin = new System.Windows.Forms.Padding(4);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(85, 28);
			this.cmdCancel.TabIndex = 3;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// chCrosshair
			// 
			this.chCrosshair.BackColor = System.Drawing.SystemColors.Control;
			this.chCrosshair.Location = new System.Drawing.Point(7, 7);
			this.chCrosshair.Margin = new System.Windows.Forms.Padding(4);
			this.chCrosshair.Name = "chCrosshair";
			this.chCrosshair.Size = new System.Drawing.Size(32, 33);
			this.chCrosshair.TabIndex = 0;
			// 
			// lblCrosshair
			// 
			this.lblCrosshair.Location = new System.Drawing.Point(46, 5);
			this.lblCrosshair.Name = "lblCrosshair";
			this.lblCrosshair.Size = new System.Drawing.Size(280, 37);
			this.lblCrosshair.TabIndex = 4;
			this.lblCrosshair.Text = "Finder Tool: Identify application by draging crosshair over window and releasing." +
				"";
			// 
			// pnlBody
			// 
			this.pnlBody.AutoSize = true;
			this.pnlBody.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.pnlBody.Controls.Add(this.txtApplicationName);
			this.pnlBody.Controls.Add(this.lblName);
			this.pnlBody.Controls.Add(this.pnlCrosshair);
			this.pnlBody.Controls.Add(this.tcApplications);
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlBody.Location = new System.Drawing.Point(10, 65);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
			this.pnlBody.Size = new System.Drawing.Size(334, 388);
			this.pnlBody.TabIndex = 5;
			// 
			// txtApplicationName
			// 
			this.txtApplicationName.Location = new System.Drawing.Point(63, 7);
			this.txtApplicationName.Name = "txtApplicationName";
			this.txtApplicationName.Size = new System.Drawing.Size(271, 23);
			this.txtApplicationName.TabIndex = 7;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.Location = new System.Drawing.Point(3, 10);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(54, 17);
			this.lblName.TabIndex = 6;
			this.lblName.Text = "Name:";
			// 
			// pnlCrosshair
			// 
			this.pnlCrosshair.Controls.Add(this.lblCrosshair);
			this.pnlCrosshair.Controls.Add(this.chCrosshair);
			this.pnlCrosshair.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlCrosshair.Location = new System.Drawing.Point(0, 340);
			this.pnlCrosshair.Name = "pnlCrosshair";
			this.pnlCrosshair.Size = new System.Drawing.Size(334, 48);
			this.pnlCrosshair.TabIndex = 5;
			// 
			// pnlControls
			// 
			this.pnlControls.Controls.Add(this.cmdDone);
			this.pnlControls.Controls.Add(this.cmdCancel);
			this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlControls.Location = new System.Drawing.Point(10, 453);
			this.pnlControls.Name = "pnlControls";
			this.pnlControls.Size = new System.Drawing.Size(334, 35);
			this.pnlControls.TabIndex = 6;
			// 
			// ofdExecutable
			// 
			this.ofdExecutable.Filter = "Executable Files|*.exe";
			// 
			// cmdBrowse
			// 
			this.cmdBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdBrowse.Image = global::HighSign.Common.Properties.Resources.FolderIcon;
			this.cmdBrowse.Location = new System.Drawing.Point(246, 66);
			this.cmdBrowse.Name = "cmdBrowse";
			this.cmdBrowse.Size = new System.Drawing.Size(74, 25);
			this.cmdBrowse.TabIndex = 5;
			this.cmdBrowse.Text = "Browse";
			this.cmdBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdBrowse.UseVisualStyleBackColor = true;
			this.cmdBrowse.Visible = false;
			// 
			// alvRunningApplications
			// 
			this.alvRunningApplications.ContextMenuStrip = this.cmsRunningApplications;
			this.alvRunningApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.alvRunningApplications.FullRowSelect = true;
			this.alvRunningApplications.HideSelection = false;
			this.alvRunningApplications.LabelWrap = false;
			this.alvRunningApplications.Location = new System.Drawing.Point(4, 40);
			this.alvRunningApplications.Margin = new System.Windows.Forms.Padding(4);
			this.alvRunningApplications.MatchString = null;
			this.alvRunningApplications.MatchUsing = HighSign.Common.Applications.MatchUsing.WindowClass;
			this.alvRunningApplications.Name = "alvRunningApplications";
			this.alvRunningApplications.ShowItemToolTips = true;
			this.alvRunningApplications.Size = new System.Drawing.Size(316, 226);
			this.alvRunningApplications.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.alvRunningApplications.TabIndex = 3;
			this.alvRunningApplications.TileSize = new System.Drawing.Size(280, 38);
			this.alvRunningApplications.UseCompatibleStateImageBehavior = false;
			this.alvRunningApplications.View = System.Windows.Forms.View.Tile;
			this.alvRunningApplications.Windows = null;
			// 
			// ApplicationDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(354, 493);
			this.Controls.Add(this.pnlControls);
			this.Controls.Add(this.pnlBody);
			this.Controls.Add(this.grpSelectApplication);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(360, 36);
			this.Name = "ApplicationDialog";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Application";
			this.grpSelectApplication.ResumeLayout(false);
			this.tcApplications.ResumeLayout(false);
			this.tpRunningApplications.ResumeLayout(false);
			this.tpRunningApplications.PerformLayout();
			this.pnlRunningApplications.ResumeLayout(false);
			this.cmsRunningApplications.ResumeLayout(false);
			this.tpCustomApplication.ResumeLayout(false);
			this.tpCustomApplication.PerformLayout();
			this.pnlCustomApplication.ResumeLayout(false);
			this.pnlCustomApplication.PerformLayout();
			this.pnlBody.ResumeLayout(false);
			this.pnlBody.PerformLayout();
			this.pnlCrosshair.ResumeLayout(false);
			this.pnlControls.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox grpSelectApplication;
		private System.Windows.Forms.ComboBox cmbExistingApplication;
		private System.Windows.Forms.TabControl tcApplications;
		private System.Windows.Forms.TabPage tpRunningApplications;
		private System.Windows.Forms.TabPage tpCustomApplication;
		private System.Windows.Forms.Button cmdDone;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.ComboBox cmbMatchUsingCustom;
		private ManagedWinapi.Crosshair chCrosshair;
		private System.Windows.Forms.Label lblMatchUsing2;
		private System.Windows.Forms.Label lblCrosshair;
		private System.Windows.Forms.TextBox txtMatchString;
		private System.Windows.Forms.CheckBox chkRegex;
		private System.Windows.Forms.Label lblMatchString;
		private System.Windows.Forms.Panel pnlCustomApplication;
		private System.Windows.Forms.Panel pnlRunningApplications;
		private System.Windows.Forms.ComboBox cmbMatchUsingRunning;
		private System.Windows.Forms.Label lblMatchUsing1;
		private HighSign.Common.UI.Controls.ApplicationListView alvRunningApplications;
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.Panel pnlCrosshair;
		private System.Windows.Forms.Panel pnlControls;
		private System.Windows.Forms.TextBox txtApplicationName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Button cmdBrowse;
		private System.Windows.Forms.OpenFileDialog ofdExecutable;
		private System.Windows.Forms.ContextMenuStrip cmsRunningApplications;
		private System.Windows.Forms.ToolStripMenuItem tsmiRefreshApplications;
	}
}