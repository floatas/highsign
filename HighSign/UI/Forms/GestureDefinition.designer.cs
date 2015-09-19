namespace HighSign.UI.Forms
{
	partial class GestureDefinition
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
			this.picGestureThumbnail = new System.Windows.Forms.PictureBox();
			this.cmbExistingGestures = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmdDeleteGesture = new System.Windows.Forms.Button();
			this.txtNewGestureName = new System.Windows.Forms.TextBox();
			this.lblNewGestureName = new System.Windows.Forms.Label();
			this.cmdNext = new System.Windows.Forms.Button();
			this.cmdDone = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.picGestureThumbnail)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// picGestureThumbnail
			// 
			this.picGestureThumbnail.BackColor = System.Drawing.SystemColors.Control;
			this.picGestureThumbnail.Location = new System.Drawing.Point(15, 30);
			this.picGestureThumbnail.Name = "picGestureThumbnail";
			this.picGestureThumbnail.Size = new System.Drawing.Size(85, 85);
			this.picGestureThumbnail.TabIndex = 0;
			this.picGestureThumbnail.TabStop = false;
			// 
			// cmbExistingGestures
			// 
			this.cmbExistingGestures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbExistingGestures.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbExistingGestures.FormattingEnabled = true;
			this.cmbExistingGestures.Location = new System.Drawing.Point(116, 31);
			this.cmbExistingGestures.MaxDropDownItems = 6;
			this.cmbExistingGestures.Name = "cmbExistingGestures";
			this.cmbExistingGestures.Size = new System.Drawing.Size(198, 24);
			this.cmbExistingGestures.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmdDeleteGesture);
			this.groupBox1.Controls.Add(this.txtNewGestureName);
			this.groupBox1.Controls.Add(this.lblNewGestureName);
			this.groupBox1.Controls.Add(this.cmbExistingGestures);
			this.groupBox1.Controls.Add(this.picGestureThumbnail);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(329, 130);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "What did you draw?";
			// 
			// cmdDeleteGesture
			// 
			this.cmdDeleteGesture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdDeleteGesture.Image = global::HighSign.Properties.Resources.DeleteIcon;
			this.cmdDeleteGesture.Location = new System.Drawing.Point(116, 61);
			this.cmdDeleteGesture.Name = "cmdDeleteGesture";
			this.cmdDeleteGesture.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
			this.cmdDeleteGesture.Size = new System.Drawing.Size(142, 28);
			this.cmdDeleteGesture.TabIndex = 4;
			this.cmdDeleteGesture.Text = "Delete Gesture";
			this.cmdDeleteGesture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdDeleteGesture.UseVisualStyleBackColor = true;
			// 
			// txtNewGestureName
			// 
			this.txtNewGestureName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNewGestureName.Location = new System.Drawing.Point(116, 92);
			this.txtNewGestureName.Name = "txtNewGestureName";
			this.txtNewGestureName.Size = new System.Drawing.Size(198, 23);
			this.txtNewGestureName.TabIndex = 3;
			this.txtNewGestureName.Visible = false;
			// 
			// lblNewGestureName
			// 
			this.lblNewGestureName.AutoSize = true;
			this.lblNewGestureName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNewGestureName.Location = new System.Drawing.Point(116, 69);
			this.lblNewGestureName.Name = "lblNewGestureName";
			this.lblNewGestureName.Size = new System.Drawing.Size(131, 17);
			this.lblNewGestureName.TabIndex = 2;
			this.lblNewGestureName.Text = "New Gesture Name";
			this.lblNewGestureName.Visible = false;
			// 
			// cmdNext
			// 
			this.cmdNext.Location = new System.Drawing.Point(266, 152);
			this.cmdNext.Name = "cmdNext";
			this.cmdNext.Size = new System.Drawing.Size(75, 23);
			this.cmdNext.TabIndex = 3;
			this.cmdNext.Text = "Next";
			this.cmdNext.UseVisualStyleBackColor = true;
			// 
			// cmdDone
			// 
			this.cmdDone.Location = new System.Drawing.Point(185, 152);
			this.cmdDone.Name = "cmdDone";
			this.cmdDone.Size = new System.Drawing.Size(75, 23);
			this.cmdDone.TabIndex = 4;
			this.cmdDone.Text = "Done";
			this.cmdDone.UseVisualStyleBackColor = true;
			// 
			// cmdCancel
			// 
			this.cmdCancel.Location = new System.Drawing.Point(12, 152);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// GestureDefinition
			// 
			this.AcceptButton = this.cmdNext;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(354, 186);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdDone);
			this.Controls.Add(this.cmdNext);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GestureDefinition";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Gesture Definition";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.picGestureThumbnail)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox picGestureThumbnail;
		private System.Windows.Forms.ComboBox cmbExistingGestures;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtNewGestureName;
		private System.Windows.Forms.Label lblNewGestureName;
		private System.Windows.Forms.Button cmdNext;
		private System.Windows.Forms.Button cmdDone;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdDeleteGesture;
	}
}