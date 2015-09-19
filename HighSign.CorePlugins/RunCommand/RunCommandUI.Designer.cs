namespace HighSign.CorePlugins.RunCommand
{
	partial class RunCommandUI
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
			this.lblRunCommand = new System.Windows.Forms.Label();
			this.txtCommand = new System.Windows.Forms.TextBox();
			this.lblArguments = new System.Windows.Forms.Label();
			this.txtArguments = new System.Windows.Forms.TextBox();
			this.cmdSelectFile = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblRunCommand
			// 
			this.lblRunCommand.AutoSize = true;
			this.lblRunCommand.Location = new System.Drawing.Point(6, 3);
			this.lblRunCommand.Name = "lblRunCommand";
			this.lblRunCommand.Size = new System.Drawing.Size(71, 17);
			this.lblRunCommand.TabIndex = 0;
			this.lblRunCommand.Text = "Command";
			// 
			// txtCommand
			// 
			this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtCommand.Location = new System.Drawing.Point(7, 24);
			this.txtCommand.Name = "txtCommand";
			this.txtCommand.Size = new System.Drawing.Size(277, 23);
			this.txtCommand.TabIndex = 1;
			// 
			// lblArguments
			// 
			this.lblArguments.AutoSize = true;
			this.lblArguments.Location = new System.Drawing.Point(6, 50);
			this.lblArguments.Name = "lblArguments";
			this.lblArguments.Size = new System.Drawing.Size(76, 17);
			this.lblArguments.TabIndex = 0;
			this.lblArguments.Text = "Arguments";
			// 
			// txtArguments
			// 
			this.txtArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtArguments.Location = new System.Drawing.Point(7, 71);
			this.txtArguments.Name = "txtArguments";
			this.txtArguments.Size = new System.Drawing.Size(306, 23);
			this.txtArguments.TabIndex = 1;
			// 
			// cmdSelectFile
			// 
			this.cmdSelectFile.Image = global::HighSign.CorePlugins.Properties.Resources.Folder;
			this.cmdSelectFile.Location = new System.Drawing.Point(290, 24);
			this.cmdSelectFile.Name = "cmdSelectFile";
			this.cmdSelectFile.Size = new System.Drawing.Size(23, 23);
			this.cmdSelectFile.TabIndex = 6;
			this.cmdSelectFile.UseVisualStyleBackColor = true;
			// 
			// RunCommandUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(319, 102);
			this.Controls.Add(this.cmdSelectFile);
			this.Controls.Add(this.txtArguments);
			this.Controls.Add(this.lblArguments);
			this.Controls.Add(this.txtCommand);
			this.Controls.Add(this.lblRunCommand);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "RunCommandUI";
			this.ShowInTaskbar = false;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblRunCommand;
		private System.Windows.Forms.TextBox txtCommand;
		private System.Windows.Forms.Label lblArguments;
		private System.Windows.Forms.TextBox txtArguments;
		private System.Windows.Forms.Button cmdSelectFile;
	}
}