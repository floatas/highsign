namespace HighSign.UI.Forms
{
	partial class ActionDefinition
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
			this.grpActions = new System.Windows.Forms.GroupBox();
			this.grpSettings = new System.Windows.Forms.GroupBox();
			this.pnlSettings = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtActionName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbPlugins = new System.Windows.Forms.ComboBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdDone = new System.Windows.Forms.Button();
			this.grpActions.SuspendLayout();
			this.grpSettings.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpActions
			// 
			this.grpActions.Controls.Add(this.grpSettings);
			this.grpActions.Controls.Add(this.cmbPlugins);
			this.grpActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpActions.Location = new System.Drawing.Point(12, 12);
			this.grpActions.Name = "grpActions";
			this.grpActions.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.grpActions.Size = new System.Drawing.Size(349, 426);
			this.grpActions.TabIndex = 0;
			this.grpActions.TabStop = false;
			this.grpActions.Text = "What action do you want to perform?";
			// 
			// grpSettings
			// 
			this.grpSettings.Controls.Add(this.pnlSettings);
			this.grpSettings.Controls.Add(this.panel1);
			this.grpSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.grpSettings.Location = new System.Drawing.Point(11, 53);
			this.grpSettings.Name = "grpSettings";
			this.grpSettings.Size = new System.Drawing.Size(326, 362);
			this.grpSettings.TabIndex = 1;
			this.grpSettings.TabStop = false;
			// 
			// pnlSettings
			// 
			this.pnlSettings.Location = new System.Drawing.Point(3, 47);
			this.pnlSettings.Name = "pnlSettings";
			this.pnlSettings.Size = new System.Drawing.Size(320, 308);
			this.pnlSettings.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txtActionName);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Location = new System.Drawing.Point(3, 14);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(320, 32);
			this.panel1.TabIndex = 1;
			// 
			// txtActionName
			// 
			this.txtActionName.Location = new System.Drawing.Point(97, 4);
			this.txtActionName.Name = "txtActionName";
			this.txtActionName.Size = new System.Drawing.Size(217, 23);
			this.txtActionName.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "Action Name";
			// 
			// cmbPlugins
			// 
			this.cmbPlugins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPlugins.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbPlugins.FormattingEnabled = true;
			this.cmbPlugins.Location = new System.Drawing.Point(11, 29);
			this.cmbPlugins.Margin = new System.Windows.Forms.Padding(7, 3, 7, 0);
			this.cmbPlugins.Name = "cmbPlugins";
			this.cmbPlugins.Size = new System.Drawing.Size(326, 24);
			this.cmbPlugins.TabIndex = 0;
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(12, 444);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 9;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// cmdDone
			// 
			this.cmdDone.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdDone.Location = new System.Drawing.Point(286, 444);
			this.cmdDone.Name = "cmdDone";
			this.cmdDone.Size = new System.Drawing.Size(75, 23);
			this.cmdDone.TabIndex = 8;
			this.cmdDone.Text = "Done";
			this.cmdDone.UseVisualStyleBackColor = true;
			// 
			// ActionDefinition
			// 
			this.AcceptButton = this.cmdDone;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(372, 478);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.grpActions);
			this.Controls.Add(this.cmdDone);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ActionDefinition";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Action Definition";
			this.TopMost = true;
			this.grpActions.ResumeLayout(false);
			this.grpSettings.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpActions;
		private System.Windows.Forms.ComboBox cmbPlugins;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdDone;
		private System.Windows.Forms.GroupBox grpSettings;
		private System.Windows.Forms.Panel pnlSettings;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtActionName;
		private System.Windows.Forms.Label label2;
	}
}