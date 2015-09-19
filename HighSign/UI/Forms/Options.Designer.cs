namespace HighSign.UI.Forms
{
	partial class Options
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
			this.cdColorPicker = new System.Windows.Forms.ColorDialog();
			this.grpVisualFeedback = new System.Windows.Forms.GroupBox();
			this.lblVisualFeedbackWidthText = new System.Windows.Forms.Label();
			this.tbVisualFeedbackWidth = new System.Windows.Forms.TrackBar();
			this.picVisualFeedbackExample = new System.Windows.Forms.PictureBox();
			this.grpMiniView = new System.Windows.Forms.GroupBox();
			this.picMiniViewExample = new System.Windows.Forms.PictureBox();
			this.ttVisualFeedbackColor = new System.Windows.Forms.ToolTip(this.components);
			this.grpStorageLocations = new System.Windows.Forms.GroupBox();
			this.cmdPluginsSelectFolder = new System.Windows.Forms.Button();
			this.cmdDataSelectFolder = new System.Windows.Forms.Button();
			this.txtPlugins = new System.Windows.Forms.TextBox();
			this.txtDataPath = new System.Windows.Forms.TextBox();
			this.lblPlugins = new System.Windows.Forms.Label();
			this.lblData = new System.Windows.Forms.Label();
			this.fbdFolders = new System.Windows.Forms.FolderBrowserDialog();
			this.grpStartup = new System.Windows.Forms.GroupBox();
			this.cmbStartupMode = new System.Windows.Forms.ComboBox();
			this.chkWindowsStartup = new System.Windows.Forms.CheckBox();
			this.cmdSave = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.grpGestureCapture = new System.Windows.Forms.GroupBox();
			this.cmbIgnoreWith = new System.Windows.Forms.ComboBox();
			this.lblIgnoreWith = new System.Windows.Forms.Label();
			this.cmbCaptureWith = new System.Windows.Forms.ComboBox();
			this.lblCaptureWith = new System.Windows.Forms.Label();
			this.cmdDefault = new System.Windows.Forms.Button();
			this.tbOpacity = new System.Windows.Forms.TrackBar();
			this.lblOpacity = new System.Windows.Forms.Label();
			this.grpVisualFeedback.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbVisualFeedbackWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picVisualFeedbackExample)).BeginInit();
			this.grpMiniView.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picMiniViewExample)).BeginInit();
			this.grpStorageLocations.SuspendLayout();
			this.grpStartup.SuspendLayout();
			this.grpGestureCapture.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).BeginInit();
			this.SuspendLayout();
			// 
			// grpVisualFeedback
			// 
			this.grpVisualFeedback.Controls.Add(this.lblOpacity);
			this.grpVisualFeedback.Controls.Add(this.tbOpacity);
			this.grpVisualFeedback.Controls.Add(this.lblVisualFeedbackWidthText);
			this.grpVisualFeedback.Controls.Add(this.tbVisualFeedbackWidth);
			this.grpVisualFeedback.Controls.Add(this.picVisualFeedbackExample);
			this.grpVisualFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpVisualFeedback.Location = new System.Drawing.Point(12, 12);
			this.grpVisualFeedback.Name = "grpVisualFeedback";
			this.grpVisualFeedback.Size = new System.Drawing.Size(295, 92);
			this.grpVisualFeedback.TabIndex = 2;
			this.grpVisualFeedback.TabStop = false;
			this.grpVisualFeedback.Text = "Visual Feedback";
			// 
			// lblVisualFeedbackWidthText
			// 
			this.lblVisualFeedbackWidthText.Location = new System.Drawing.Point(74, 58);
			this.lblVisualFeedbackWidthText.Name = "lblVisualFeedbackWidthText";
			this.lblVisualFeedbackWidthText.Size = new System.Drawing.Size(104, 23);
			this.lblVisualFeedbackWidthText.TabIndex = 4;
			this.lblVisualFeedbackWidthText.Text = "Disabled";
			this.lblVisualFeedbackWidthText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbVisualFeedbackWidth
			// 
			this.tbVisualFeedbackWidth.AutoSize = false;
			this.tbVisualFeedbackWidth.Location = new System.Drawing.Point(74, 25);
			this.tbVisualFeedbackWidth.Maximum = 20;
			this.tbVisualFeedbackWidth.Name = "tbVisualFeedbackWidth";
			this.tbVisualFeedbackWidth.Size = new System.Drawing.Size(104, 32);
			this.tbVisualFeedbackWidth.TabIndex = 3;
			this.tbVisualFeedbackWidth.TickFrequency = 2;
			// 
			// picVisualFeedbackExample
			// 
			this.picVisualFeedbackExample.BackColor = System.Drawing.SystemColors.Control;
			this.picVisualFeedbackExample.Location = new System.Drawing.Point(13, 26);
			this.picVisualFeedbackExample.Name = "picVisualFeedbackExample";
			this.picVisualFeedbackExample.Size = new System.Drawing.Size(55, 55);
			this.picVisualFeedbackExample.TabIndex = 1;
			this.picVisualFeedbackExample.TabStop = false;
			this.ttVisualFeedbackColor.SetToolTip(this.picVisualFeedbackExample, "Click to change visual feedback color");
			// 
			// grpMiniView
			// 
			this.grpMiniView.Controls.Add(this.picMiniViewExample);
			this.grpMiniView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpMiniView.Location = new System.Drawing.Point(313, 12);
			this.grpMiniView.Name = "grpMiniView";
			this.grpMiniView.Size = new System.Drawing.Size(83, 92);
			this.grpMiniView.TabIndex = 3;
			this.grpMiniView.TabStop = false;
			this.grpMiniView.Text = "Mini View";
			// 
			// picMiniViewExample
			// 
			this.picMiniViewExample.BackColor = System.Drawing.SystemColors.Control;
			this.picMiniViewExample.Location = new System.Drawing.Point(13, 25);
			this.picMiniViewExample.Name = "picMiniViewExample";
			this.picMiniViewExample.Size = new System.Drawing.Size(55, 55);
			this.picMiniViewExample.TabIndex = 2;
			this.picMiniViewExample.TabStop = false;
			this.ttVisualFeedbackColor.SetToolTip(this.picMiniViewExample, "Click to change mini view color");
			// 
			// ttVisualFeedbackColor
			// 
			this.ttVisualFeedbackColor.IsBalloon = true;
			// 
			// grpStorageLocations
			// 
			this.grpStorageLocations.Controls.Add(this.cmdPluginsSelectFolder);
			this.grpStorageLocations.Controls.Add(this.cmdDataSelectFolder);
			this.grpStorageLocations.Controls.Add(this.txtPlugins);
			this.grpStorageLocations.Controls.Add(this.txtDataPath);
			this.grpStorageLocations.Controls.Add(this.lblPlugins);
			this.grpStorageLocations.Controls.Add(this.lblData);
			this.grpStorageLocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpStorageLocations.Location = new System.Drawing.Point(12, 110);
			this.grpStorageLocations.Name = "grpStorageLocations";
			this.grpStorageLocations.Size = new System.Drawing.Size(384, 88);
			this.grpStorageLocations.TabIndex = 4;
			this.grpStorageLocations.TabStop = false;
			this.grpStorageLocations.Text = "Storage Locations";
			// 
			// cmdPluginsSelectFolder
			// 
			this.cmdPluginsSelectFolder.Image = global::HighSign.Properties.Resources.Folder;
			this.cmdPluginsSelectFolder.Location = new System.Drawing.Point(349, 52);
			this.cmdPluginsSelectFolder.Name = "cmdPluginsSelectFolder";
			this.cmdPluginsSelectFolder.Size = new System.Drawing.Size(23, 23);
			this.cmdPluginsSelectFolder.TabIndex = 5;
			this.cmdPluginsSelectFolder.UseVisualStyleBackColor = true;
			// 
			// cmdDataSelectFolder
			// 
			this.cmdDataSelectFolder.Image = global::HighSign.Properties.Resources.Folder;
			this.cmdDataSelectFolder.Location = new System.Drawing.Point(349, 26);
			this.cmdDataSelectFolder.Name = "cmdDataSelectFolder";
			this.cmdDataSelectFolder.Size = new System.Drawing.Size(23, 23);
			this.cmdDataSelectFolder.TabIndex = 5;
			this.cmdDataSelectFolder.UseVisualStyleBackColor = true;
			// 
			// txtPlugins
			// 
			this.txtPlugins.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.txtPlugins.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
			this.txtPlugins.Location = new System.Drawing.Point(65, 52);
			this.txtPlugins.Name = "txtPlugins";
			this.txtPlugins.Size = new System.Drawing.Size(278, 23);
			this.txtPlugins.TabIndex = 1;
			// 
			// txtDataPath
			// 
			this.txtDataPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.txtDataPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
			this.txtDataPath.Location = new System.Drawing.Point(65, 26);
			this.txtDataPath.Name = "txtDataPath";
			this.txtDataPath.Size = new System.Drawing.Size(278, 23);
			this.txtDataPath.TabIndex = 1;
			// 
			// lblPlugins
			// 
			this.lblPlugins.Location = new System.Drawing.Point(6, 52);
			this.lblPlugins.Name = "lblPlugins";
			this.lblPlugins.Size = new System.Drawing.Size(58, 23);
			this.lblPlugins.TabIndex = 0;
			this.lblPlugins.Text = "Plugins:";
			this.lblPlugins.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblData
			// 
			this.lblData.Location = new System.Drawing.Point(6, 26);
			this.lblData.Name = "lblData";
			this.lblData.Size = new System.Drawing.Size(58, 23);
			this.lblData.TabIndex = 0;
			this.lblData.Text = "Data:";
			this.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpStartup
			// 
			this.grpStartup.Controls.Add(this.cmbStartupMode);
			this.grpStartup.Controls.Add(this.chkWindowsStartup);
			this.grpStartup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpStartup.Location = new System.Drawing.Point(12, 206);
			this.grpStartup.Name = "grpStartup";
			this.grpStartup.Size = new System.Drawing.Size(384, 86);
			this.grpStartup.TabIndex = 5;
			this.grpStartup.TabStop = false;
			this.grpStartup.Text = "Startup";
			// 
			// cmbStartupMode
			// 
			this.cmbStartupMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStartupMode.FormattingEnabled = true;
			this.cmbStartupMode.Items.AddRange(new object[] {
            "Start in Training Mode",
            "Start in Gesture Mode",
            "Start in Last Instance\'s Mode"});
			this.cmbStartupMode.Location = new System.Drawing.Point(13, 50);
			this.cmbStartupMode.Name = "cmbStartupMode";
			this.cmbStartupMode.Size = new System.Drawing.Size(359, 24);
			this.cmbStartupMode.TabIndex = 1;
			// 
			// chkWindowsStartup
			// 
			this.chkWindowsStartup.AutoSize = true;
			this.chkWindowsStartup.Location = new System.Drawing.Point(14, 24);
			this.chkWindowsStartup.Name = "chkWindowsStartup";
			this.chkWindowsStartup.Size = new System.Drawing.Size(252, 21);
			this.chkWindowsStartup.TabIndex = 0;
			this.chkWindowsStartup.Text = "Start High Sign on Windows Startup";
			this.chkWindowsStartup.UseVisualStyleBackColor = true;
			// 
			// cmdSave
			// 
			this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdSave.Location = new System.Drawing.Point(322, 399);
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.Size = new System.Drawing.Size(75, 28);
			this.cmdSave.TabIndex = 6;
			this.cmdSave.Text = "Save";
			this.cmdSave.UseVisualStyleBackColor = true;
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdCancel.Location = new System.Drawing.Point(241, 399);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 28);
			this.cmdCancel.TabIndex = 6;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// grpGestureCapture
			// 
			this.grpGestureCapture.Controls.Add(this.cmbIgnoreWith);
			this.grpGestureCapture.Controls.Add(this.lblIgnoreWith);
			this.grpGestureCapture.Controls.Add(this.cmbCaptureWith);
			this.grpGestureCapture.Controls.Add(this.lblCaptureWith);
			this.grpGestureCapture.Enabled = false;
			this.grpGestureCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpGestureCapture.Location = new System.Drawing.Point(12, 298);
			this.grpGestureCapture.Name = "grpGestureCapture";
			this.grpGestureCapture.Size = new System.Drawing.Size(384, 92);
			this.grpGestureCapture.TabIndex = 7;
			this.grpGestureCapture.TabStop = false;
			this.grpGestureCapture.Text = "Gesture Capture (Not Implemented)";
			// 
			// cmbIgnoreWith
			// 
			this.cmbIgnoreWith.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbIgnoreWith.FormattingEnabled = true;
			this.cmbIgnoreWith.Items.AddRange(new object[] {
            "Ctrl Key",
            "Alt Key",
            "Shift Key"});
			this.cmbIgnoreWith.Location = new System.Drawing.Point(111, 55);
			this.cmbIgnoreWith.Name = "cmbIgnoreWith";
			this.cmbIgnoreWith.Size = new System.Drawing.Size(261, 24);
			this.cmbIgnoreWith.TabIndex = 1;
			// 
			// lblIgnoreWith
			// 
			this.lblIgnoreWith.Location = new System.Drawing.Point(11, 54);
			this.lblIgnoreWith.Name = "lblIgnoreWith";
			this.lblIgnoreWith.Size = new System.Drawing.Size(94, 24);
			this.lblIgnoreWith.TabIndex = 0;
			this.lblIgnoreWith.Text = "Ignore With:";
			this.lblIgnoreWith.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbCaptureWith
			// 
			this.cmbCaptureWith.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCaptureWith.FormattingEnabled = true;
			this.cmbCaptureWith.Items.AddRange(new object[] {
            "Left Mouse Button",
            "Middle Mouse Button",
            "Right Mouse Button"});
			this.cmbCaptureWith.Location = new System.Drawing.Point(111, 25);
			this.cmbCaptureWith.Name = "cmbCaptureWith";
			this.cmbCaptureWith.Size = new System.Drawing.Size(261, 24);
			this.cmbCaptureWith.TabIndex = 1;
			// 
			// lblCaptureWith
			// 
			this.lblCaptureWith.Location = new System.Drawing.Point(11, 24);
			this.lblCaptureWith.Name = "lblCaptureWith";
			this.lblCaptureWith.Size = new System.Drawing.Size(94, 24);
			this.lblCaptureWith.TabIndex = 0;
			this.lblCaptureWith.Text = "Capture With:";
			this.lblCaptureWith.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmdDefault
			// 
			this.cmdDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdDefault.Location = new System.Drawing.Point(12, 399);
			this.cmdDefault.Name = "cmdDefault";
			this.cmdDefault.Size = new System.Drawing.Size(75, 28);
			this.cmdDefault.TabIndex = 8;
			this.cmdDefault.Text = "Default";
			this.cmdDefault.UseVisualStyleBackColor = true;
			// 
			// tbOpacity
			// 
			this.tbOpacity.Location = new System.Drawing.Point(184, 25);
			this.tbOpacity.Maximum = 255;
			this.tbOpacity.Name = "tbOpacity";
			this.tbOpacity.Size = new System.Drawing.Size(104, 45);
			this.tbOpacity.TabIndex = 5;
			this.tbOpacity.TickFrequency = 23;
			// 
			// lblOpacity
			// 
			this.lblOpacity.Location = new System.Drawing.Point(184, 58);
			this.lblOpacity.Name = "lblOpacity";
			this.lblOpacity.Size = new System.Drawing.Size(104, 23);
			this.lblOpacity.TabIndex = 6;
			this.lblOpacity.Text = "Opacity: 100%";
			this.lblOpacity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Options
			// 
			this.AcceptButton = this.cmdSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(409, 438);
			this.Controls.Add(this.cmdDefault);
			this.Controls.Add(this.grpGestureCapture);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdSave);
			this.Controls.Add(this.grpStartup);
			this.Controls.Add(this.grpStorageLocations);
			this.Controls.Add(this.grpMiniView);
			this.Controls.Add(this.grpVisualFeedback);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Options";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "High Sign - Preferences";
			this.grpVisualFeedback.ResumeLayout(false);
			this.grpVisualFeedback.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbVisualFeedbackWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picVisualFeedbackExample)).EndInit();
			this.grpMiniView.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picMiniViewExample)).EndInit();
			this.grpStorageLocations.ResumeLayout(false);
			this.grpStorageLocations.PerformLayout();
			this.grpStartup.ResumeLayout(false);
			this.grpStartup.PerformLayout();
			this.grpGestureCapture.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ColorDialog cdColorPicker;
		private System.Windows.Forms.PictureBox picVisualFeedbackExample;
		private System.Windows.Forms.GroupBox grpVisualFeedback;
		private System.Windows.Forms.TrackBar tbVisualFeedbackWidth;
		private System.Windows.Forms.Label lblVisualFeedbackWidthText;
		private System.Windows.Forms.GroupBox grpMiniView;
		private System.Windows.Forms.PictureBox picMiniViewExample;
		private System.Windows.Forms.ToolTip ttVisualFeedbackColor;
		private System.Windows.Forms.GroupBox grpStorageLocations;
		private System.Windows.Forms.Label lblData;
		private System.Windows.Forms.TextBox txtPlugins;
		private System.Windows.Forms.TextBox txtDataPath;
		private System.Windows.Forms.Label lblPlugins;
		private System.Windows.Forms.Button cmdDataSelectFolder;
		private System.Windows.Forms.Button cmdPluginsSelectFolder;
		private System.Windows.Forms.FolderBrowserDialog fbdFolders;
		private System.Windows.Forms.GroupBox grpStartup;
		private System.Windows.Forms.ComboBox cmbStartupMode;
		private System.Windows.Forms.CheckBox chkWindowsStartup;
		private System.Windows.Forms.Button cmdSave;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.GroupBox grpGestureCapture;
		private System.Windows.Forms.ComboBox cmbCaptureWith;
		private System.Windows.Forms.Label lblCaptureWith;
		private System.Windows.Forms.ComboBox cmbIgnoreWith;
		private System.Windows.Forms.Label lblIgnoreWith;
		private System.Windows.Forms.Button cmdDefault;
		private System.Windows.Forms.Label lblOpacity;
		private System.Windows.Forms.TrackBar tbOpacity;
	}
}