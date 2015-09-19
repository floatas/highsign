namespace HighSign.CorePlugins.HotKey
{
	partial class HotKeyUI
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
			this.txtKey = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.LLKeyHook = new ManagedWinapi.Hooks.LowLevelKeyboardHook();
			this.SuspendLayout();
			// 
			// txtKey
			// 
			this.txtKey.AcceptsReturn = true;
			this.txtKey.AcceptsTab = true;
			this.txtKey.Location = new System.Drawing.Point(68, 6);
			this.txtKey.Margin = new System.Windows.Forms.Padding(4);
			this.txtKey.Name = "txtKey";
			this.txtKey.ShortcutsEnabled = false;
			this.txtKey.Size = new System.Drawing.Size(246, 23);
			this.txtKey.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label2.Location = new System.Drawing.Point(4, 9);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Hot Key";
			// 
			// LLKeyHook
			// 
			this.LLKeyHook.Type = ManagedWinapi.Hooks.HookType.WH_KEYBOARD_LL;
			// 
			// HotKeyUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(319, 36);
			this.Controls.Add(this.txtKey);
			this.Controls.Add(this.label2);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "HotKeyUI";
			this.Text = "HotKey";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtKey;
		private System.Windows.Forms.Label label2;
		private ManagedWinapi.Hooks.LowLevelKeyboardHook LLKeyHook;
	}
}