namespace HighSign.UI.Forms
{
	partial class AvailableGestures
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
			this.lstAvailableGestures = new System.Windows.Forms.ListView();
			this.grpAvailableGestures = new System.Windows.Forms.GroupBox();
			this.imgGestures = new System.Windows.Forms.ImageList(this.components);
			this.cmdDelete = new System.Windows.Forms.Button();
			this.grpAvailableGestures.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstAvailableGestures
			// 
			this.lstAvailableGestures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lstAvailableGestures.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lstAvailableGestures.HideSelection = false;
			this.lstAvailableGestures.LargeImageList = this.imgGestures;
			this.lstAvailableGestures.Location = new System.Drawing.Point(11, 25);
			this.lstAvailableGestures.Name = "lstAvailableGestures";
			this.lstAvailableGestures.Size = new System.Drawing.Size(415, 323);
			this.lstAvailableGestures.TabIndex = 0;
			this.lstAvailableGestures.UseCompatibleStateImageBehavior = false;
			// 
			// grpAvailableGestures
			// 
			this.grpAvailableGestures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpAvailableGestures.Controls.Add(this.cmdDelete);
			this.grpAvailableGestures.Controls.Add(this.lstAvailableGestures);
			this.grpAvailableGestures.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.grpAvailableGestures.Location = new System.Drawing.Point(12, 12);
			this.grpAvailableGestures.Name = "grpAvailableGestures";
			this.grpAvailableGestures.Size = new System.Drawing.Size(472, 360);
			this.grpAvailableGestures.TabIndex = 1;
			this.grpAvailableGestures.TabStop = false;
			this.grpAvailableGestures.Text = "Available Gestures";
			// 
			// imgGestures
			// 
			this.imgGestures.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imgGestures.ImageSize = new System.Drawing.Size(52, 52);
			this.imgGestures.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdDelete.Enabled = false;
			this.cmdDelete.Image = global::HighSign.Properties.Resources.DeleteIcon;
			this.cmdDelete.Location = new System.Drawing.Point(432, 25);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new System.Drawing.Size(30, 30);
			this.cmdDelete.TabIndex = 5;
			this.cmdDelete.UseVisualStyleBackColor = true;
			// 
			// AvailableGestures
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 384);
			this.Controls.Add(this.grpAvailableGestures);
			this.Name = "AvailableGestures";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "HighSign - Available Gestures";
			this.grpAvailableGestures.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lstAvailableGestures;
		private System.Windows.Forms.GroupBox grpAvailableGestures;
		private System.Windows.Forms.ImageList imgGestures;
		private System.Windows.Forms.Button cmdDelete;
	}
}