namespace HighSign.CorePlugins.SendKeystrokes
{
	partial class SendKeystrokesUI
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
			this.txtSendKeys = new System.Windows.Forms.TextBox();
			this.cmsSendKeys = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.escapeTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.cmsSendKeys.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtSendKeys
			// 
			this.txtSendKeys.ContextMenuStrip = this.cmsSendKeys;
			this.txtSendKeys.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSendKeys.Location = new System.Drawing.Point(6, 6);
			this.txtSendKeys.Multiline = true;
			this.txtSendKeys.Name = "txtSendKeys";
			this.txtSendKeys.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtSendKeys.Size = new System.Drawing.Size(307, 88);
			this.txtSendKeys.TabIndex = 0;
			// 
			// cmsSendKeys
			// 
			this.cmsSendKeys.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.escapeTextToolStripMenuItem});
			this.cmsSendKeys.Name = "cmsSendKeys";
			this.cmsSendKeys.Size = new System.Drawing.Size(111, 26);
			// 
			// escapeTextToolStripMenuItem
			// 
			this.escapeTextToolStripMenuItem.Name = "escapeTextToolStripMenuItem";
			this.escapeTextToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.escapeTextToolStripMenuItem.Text = "Escape";
			this.escapeTextToolStripMenuItem.Click += new System.EventHandler(this.escapeTextToolStripMenuItem_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 97);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(304, 19);
			this.label1.TabIndex = 2;
			this.label1.Text = "Standard SendKeys syntax applies. ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SendKeystrokesUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(319, 120);
			this.Controls.Add(this.txtSendKeys);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "SendKeystrokesUI";
			this.Padding = new System.Windows.Forms.Padding(6, 6, 6, 26);
			this.Text = "SendKeystrokesUI";
			this.cmsSendKeys.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.TextBox txtSendKeys;
		private System.Windows.Forms.ContextMenuStrip cmsSendKeys;
		private System.Windows.Forms.ToolStripMenuItem escapeTextToolStripMenuItem;
		private System.Windows.Forms.Label label1;

	}
}