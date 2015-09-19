namespace HighSign.UI.Forms
{
	partial class AvailableActions
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
			this.grpAvailableActions = new System.Windows.Forms.GroupBox();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.lstAvailableActions = new System.Windows.Forms.ListView();
			this.clmName = new System.Windows.Forms.ColumnHeader();
			this.clmDescription = new System.Windows.Forms.ColumnHeader();
			this.imgGestureThumbnails = new System.Windows.Forms.ImageList(this.components);
			this.grpAvailableActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpAvailableActions
			// 
			this.grpAvailableActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpAvailableActions.Controls.Add(this.cmdPrint);
			this.grpAvailableActions.Controls.Add(this.cmdDelete);
			this.grpAvailableActions.Controls.Add(this.cmdEdit);
			this.grpAvailableActions.Controls.Add(this.lstAvailableActions);
			this.grpAvailableActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpAvailableActions.Location = new System.Drawing.Point(12, 12);
			this.grpAvailableActions.Name = "grpAvailableActions";
			this.grpAvailableActions.Size = new System.Drawing.Size(512, 489);
			this.grpAvailableActions.TabIndex = 0;
			this.grpAvailableActions.TabStop = false;
			this.grpAvailableActions.Text = "Available Actions";
			// 
			// cmdPrint
			// 
			this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdPrint.Image = global::HighSign.Properties.Resources.Print;
			this.cmdPrint.Location = new System.Drawing.Point(471, 448);
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.Size = new System.Drawing.Size(30, 30);
			this.cmdPrint.TabIndex = 5;
			this.cmdPrint.UseVisualStyleBackColor = true;
			this.cmdPrint.Visible = false;
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdDelete.Image = global::HighSign.Properties.Resources.DeleteIcon;
			this.cmdDelete.Location = new System.Drawing.Point(471, 59);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new System.Drawing.Size(30, 30);
			this.cmdDelete.TabIndex = 4;
			this.cmdDelete.UseVisualStyleBackColor = true;
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdEdit.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.cmdEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.cmdEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdEdit.Image = global::HighSign.Properties.Resources.Edit;
			this.cmdEdit.Location = new System.Drawing.Point(471, 25);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.Size = new System.Drawing.Size(30, 30);
			this.cmdEdit.TabIndex = 3;
			this.cmdEdit.UseVisualStyleBackColor = true;
			// 
			// lstAvailableActions
			// 
			this.lstAvailableActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lstAvailableActions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmDescription});
			this.lstAvailableActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstAvailableActions.HideSelection = false;
			this.lstAvailableActions.LargeImageList = this.imgGestureThumbnails;
			this.lstAvailableActions.Location = new System.Drawing.Point(11, 25);
			this.lstAvailableActions.Name = "lstAvailableActions";
			this.lstAvailableActions.Size = new System.Drawing.Size(454, 453);
			this.lstAvailableActions.TabIndex = 0;
			this.lstAvailableActions.TileSize = new System.Drawing.Size(445, 58);
			this.lstAvailableActions.UseCompatibleStateImageBehavior = false;
			this.lstAvailableActions.View = System.Windows.Forms.View.Tile;
			// 
			// clmName
			// 
			this.clmName.Text = "Name";
			// 
			// clmDescription
			// 
			this.clmDescription.Text = "Description";
			// 
			// imgGestureThumbnails
			// 
			this.imgGestureThumbnails.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imgGestureThumbnails.ImageSize = new System.Drawing.Size(62, 52);
			this.imgGestureThumbnails.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// AvailableActions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(536, 513);
			this.Controls.Add(this.grpAvailableActions);
			this.Name = "AvailableActions";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "High Sign - Available Actions";
			this.grpAvailableActions.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpAvailableActions;
		private System.Windows.Forms.ListView lstAvailableActions;
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdPrint;
		private System.Windows.Forms.ColumnHeader clmName;
		private System.Windows.Forms.ColumnHeader clmDescription;
		private System.Windows.Forms.ImageList imgGestureThumbnails;
	}
}