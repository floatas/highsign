namespace HighSign.UI.Forms
{
	partial class ActionConfiguration
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionConfiguration));
			this.grpGesture = new System.Windows.Forms.GroupBox();
			this.gpbGesture = new HighSign.Common.UI.Forms.Controls.GesturePictureBox();
			this.cmdChangeGesture = new System.Windows.Forms.Button();
			this.grpSelectApplication = new System.Windows.Forms.GroupBox();
			this.cmdChangeApplication = new System.Windows.Forms.Button();
			this.lblUseRegex = new System.Windows.Forms.Label();
			this.lblTagUseRegex = new System.Windows.Forms.Label();
			this.lblMatchString = new System.Windows.Forms.Label();
			this.lblTagMatchString = new System.Windows.Forms.Label();
			this.lblTagApplicationName = new System.Windows.Forms.Label();
			this.lblApplicationName = new System.Windows.Forms.Label();
			this.lblMatchUsing = new System.Windows.Forms.Label();
			this.lblTagMatchUsing = new System.Windows.Forms.Label();
			this.pbApplicationIcon = new System.Windows.Forms.PictureBox();
			this.grpConfigureActions = new System.Windows.Forms.GroupBox();
			this.cmdDeleteAction = new System.Windows.Forms.Button();
			this.cmdEditAction = new System.Windows.Forms.Button();
			this.cmdAddAction = new System.Windows.Forms.Button();
			this.lstActions = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdSave = new System.Windows.Forms.Button();
			this.grpGesture.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gpbGesture)).BeginInit();
			this.grpSelectApplication.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbApplicationIcon)).BeginInit();
			this.grpConfigureActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpGesture
			// 
			this.grpGesture.Controls.Add(this.gpbGesture);
			this.grpGesture.Controls.Add(this.cmdChangeGesture);
			this.grpGesture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpGesture.Location = new System.Drawing.Point(12, 12);
			this.grpGesture.Name = "grpGesture";
			this.grpGesture.Size = new System.Drawing.Size(95, 135);
			this.grpGesture.TabIndex = 0;
			this.grpGesture.TabStop = false;
			this.grpGesture.Text = "Gesture";
			// 
			// gpbGesture
			// 
			this.gpbGesture.FillColor = System.Drawing.Color.White;
			this.gpbGesture.Gesture = null;
			this.gpbGesture.Location = new System.Drawing.Point(10, 22);
			this.gpbGesture.Name = "gpbGesture";
			this.gpbGesture.Size = new System.Drawing.Size(73, 75);
			this.gpbGesture.StrokeColor = System.Drawing.Color.Gray;
			this.gpbGesture.TabIndex = 6;
			this.gpbGesture.TabStop = false;
			// 
			// cmdChangeGesture
			// 
			this.cmdChangeGesture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdChangeGesture.Location = new System.Drawing.Point(10, 103);
			this.cmdChangeGesture.Name = "cmdChangeGesture";
			this.cmdChangeGesture.Size = new System.Drawing.Size(75, 23);
			this.cmdChangeGesture.TabIndex = 5;
			this.cmdChangeGesture.Text = "Change...";
			this.cmdChangeGesture.UseVisualStyleBackColor = true;
			// 
			// grpSelectApplication
			// 
			this.grpSelectApplication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpSelectApplication.Controls.Add(this.cmdChangeApplication);
			this.grpSelectApplication.Controls.Add(this.lblUseRegex);
			this.grpSelectApplication.Controls.Add(this.lblTagUseRegex);
			this.grpSelectApplication.Controls.Add(this.lblMatchString);
			this.grpSelectApplication.Controls.Add(this.lblTagMatchString);
			this.grpSelectApplication.Controls.Add(this.lblTagApplicationName);
			this.grpSelectApplication.Controls.Add(this.lblApplicationName);
			this.grpSelectApplication.Controls.Add(this.lblMatchUsing);
			this.grpSelectApplication.Controls.Add(this.lblTagMatchUsing);
			this.grpSelectApplication.Controls.Add(this.pbApplicationIcon);
			this.grpSelectApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpSelectApplication.Location = new System.Drawing.Point(113, 12);
			this.grpSelectApplication.Name = "grpSelectApplication";
			this.grpSelectApplication.Size = new System.Drawing.Size(363, 135);
			this.grpSelectApplication.TabIndex = 1;
			this.grpSelectApplication.TabStop = false;
			this.grpSelectApplication.Text = "Select Application";
			// 
			// cmdChangeApplication
			// 
			this.cmdChangeApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdChangeApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdChangeApplication.Location = new System.Drawing.Point(280, 103);
			this.cmdChangeApplication.Name = "cmdChangeApplication";
			this.cmdChangeApplication.Size = new System.Drawing.Size(75, 23);
			this.cmdChangeApplication.TabIndex = 6;
			this.cmdChangeApplication.Text = "Change...";
			this.cmdChangeApplication.UseVisualStyleBackColor = true;
			// 
			// lblUseRegex
			// 
			this.lblUseRegex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblUseRegex.AutoEllipsis = true;
			this.lblUseRegex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUseRegex.Location = new System.Drawing.Point(121, 73);
			this.lblUseRegex.Name = "lblUseRegex";
			this.lblUseRegex.Size = new System.Drawing.Size(234, 15);
			this.lblUseRegex.TabIndex = 4;
			this.lblUseRegex.Text = "Yes";
			// 
			// lblTagUseRegex
			// 
			this.lblTagUseRegex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTagUseRegex.Location = new System.Drawing.Point(52, 73);
			this.lblTagUseRegex.Name = "lblTagUseRegex";
			this.lblTagUseRegex.Size = new System.Drawing.Size(70, 14);
			this.lblTagUseRegex.TabIndex = 3;
			this.lblTagUseRegex.Text = "Use Regex:";
			this.lblTagUseRegex.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblMatchString
			// 
			this.lblMatchString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblMatchString.AutoEllipsis = true;
			this.lblMatchString.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMatchString.Location = new System.Drawing.Point(121, 56);
			this.lblMatchString.Name = "lblMatchString";
			this.lblMatchString.Size = new System.Drawing.Size(234, 15);
			this.lblMatchString.TabIndex = 4;
			this.lblMatchString.Text = "MozillaUIWindow";
			// 
			// lblTagMatchString
			// 
			this.lblTagMatchString.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTagMatchString.Location = new System.Drawing.Point(52, 56);
			this.lblTagMatchString.Name = "lblTagMatchString";
			this.lblTagMatchString.Size = new System.Drawing.Size(70, 17);
			this.lblTagMatchString.TabIndex = 3;
			this.lblTagMatchString.Text = "Match String:";
			// 
			// lblTagApplicationName
			// 
			this.lblTagApplicationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTagApplicationName.Location = new System.Drawing.Point(52, 22);
			this.lblTagApplicationName.Name = "lblTagApplicationName";
			this.lblTagApplicationName.Size = new System.Drawing.Size(70, 17);
			this.lblTagApplicationName.TabIndex = 1;
			this.lblTagApplicationName.Text = "Name:";
			this.lblTagApplicationName.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblApplicationName
			// 
			this.lblApplicationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblApplicationName.AutoEllipsis = true;
			this.lblApplicationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblApplicationName.Location = new System.Drawing.Point(121, 22);
			this.lblApplicationName.Name = "lblApplicationName";
			this.lblApplicationName.Size = new System.Drawing.Size(234, 14);
			this.lblApplicationName.TabIndex = 2;
			this.lblApplicationName.Text = "Mozilla Firefox";
			// 
			// lblMatchUsing
			// 
			this.lblMatchUsing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblMatchUsing.AutoEllipsis = true;
			this.lblMatchUsing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMatchUsing.Location = new System.Drawing.Point(121, 39);
			this.lblMatchUsing.Name = "lblMatchUsing";
			this.lblMatchUsing.Size = new System.Drawing.Size(234, 14);
			this.lblMatchUsing.TabIndex = 2;
			this.lblMatchUsing.Text = "Window Class";
			// 
			// lblTagMatchUsing
			// 
			this.lblTagMatchUsing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTagMatchUsing.Location = new System.Drawing.Point(52, 39);
			this.lblTagMatchUsing.Name = "lblTagMatchUsing";
			this.lblTagMatchUsing.Size = new System.Drawing.Size(70, 17);
			this.lblTagMatchUsing.TabIndex = 1;
			this.lblTagMatchUsing.Text = "Match Using:";
			// 
			// pbApplicationIcon
			// 
			this.pbApplicationIcon.Image = global::HighSign.Properties.Resources.NewApplication;
			this.pbApplicationIcon.Location = new System.Drawing.Point(10, 22);
			this.pbApplicationIcon.Name = "pbApplicationIcon";
			this.pbApplicationIcon.Size = new System.Drawing.Size(32, 32);
			this.pbApplicationIcon.TabIndex = 0;
			this.pbApplicationIcon.TabStop = false;
			// 
			// grpConfigureActions
			// 
			this.grpConfigureActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpConfigureActions.Controls.Add(this.cmdDeleteAction);
			this.grpConfigureActions.Controls.Add(this.cmdEditAction);
			this.grpConfigureActions.Controls.Add(this.cmdAddAction);
			this.grpConfigureActions.Controls.Add(this.lstActions);
			this.grpConfigureActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpConfigureActions.Location = new System.Drawing.Point(12, 153);
			this.grpConfigureActions.Name = "grpConfigureActions";
			this.grpConfigureActions.Size = new System.Drawing.Size(464, 224);
			this.grpConfigureActions.TabIndex = 2;
			this.grpConfigureActions.TabStop = false;
			this.grpConfigureActions.Text = "Configure Actions";
			// 
			// cmdDeleteAction
			// 
			this.cmdDeleteAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdDeleteAction.Image = global::HighSign.Properties.Resources.DeleteIcon;
			this.cmdDeleteAction.Location = new System.Drawing.Point(428, 84);
			this.cmdDeleteAction.Name = "cmdDeleteAction";
			this.cmdDeleteAction.Size = new System.Drawing.Size(28, 28);
			this.cmdDeleteAction.TabIndex = 2;
			this.cmdDeleteAction.UseVisualStyleBackColor = true;
			// 
			// cmdEditAction
			// 
			this.cmdEditAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdEditAction.Image = global::HighSign.Properties.Resources.Edit;
			this.cmdEditAction.Location = new System.Drawing.Point(428, 53);
			this.cmdEditAction.Name = "cmdEditAction";
			this.cmdEditAction.Size = new System.Drawing.Size(28, 28);
			this.cmdEditAction.TabIndex = 2;
			this.cmdEditAction.UseVisualStyleBackColor = true;
			// 
			// cmdAddAction
			// 
			this.cmdAddAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdAddAction.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddAction.Image")));
			this.cmdAddAction.Location = new System.Drawing.Point(428, 22);
			this.cmdAddAction.Name = "cmdAddAction";
			this.cmdAddAction.Size = new System.Drawing.Size(28, 28);
			this.cmdAddAction.TabIndex = 1;
			this.cmdAddAction.UseVisualStyleBackColor = true;
			// 
			// lstActions
			// 
			this.lstActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lstActions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.lstActions.GridLines = true;
			this.lstActions.Location = new System.Drawing.Point(10, 22);
			this.lstActions.Name = "lstActions";
			this.lstActions.Size = new System.Drawing.Size(412, 191);
			this.lstActions.TabIndex = 0;
			this.lstActions.UseCompatibleStateImageBehavior = false;
			this.lstActions.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Action Name";
			this.columnHeader1.Width = 128;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Action Description";
			this.columnHeader2.Width = 278;
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.Location = new System.Drawing.Point(12, 383);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 9;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// cmdSave
			// 
			this.cmdSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdSave.Location = new System.Drawing.Point(401, 383);
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.Size = new System.Drawing.Size(75, 23);
			this.cmdSave.TabIndex = 8;
			this.cmdSave.Text = "Save";
			this.cmdSave.UseVisualStyleBackColor = true;
			// 
			// ActionConfiguration
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(488, 418);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdSave);
			this.Controls.Add(this.grpConfigureActions);
			this.Controls.Add(this.grpSelectApplication);
			this.Controls.Add(this.grpGesture);
			this.Name = "ActionConfiguration";
			this.Text = "Action Configuration";
			this.grpGesture.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gpbGesture)).EndInit();
			this.grpSelectApplication.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbApplicationIcon)).EndInit();
			this.grpConfigureActions.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpGesture;
		private System.Windows.Forms.GroupBox grpSelectApplication;
		private System.Windows.Forms.Label lblTagMatchUsing;
		private System.Windows.Forms.PictureBox pbApplicationIcon;
		private System.Windows.Forms.Label lblMatchString;
		private System.Windows.Forms.Label lblTagMatchString;
		private System.Windows.Forms.Label lblMatchUsing;
		private System.Windows.Forms.Label lblUseRegex;
		private System.Windows.Forms.Label lblTagUseRegex;
		private System.Windows.Forms.Button cmdChangeGesture;
		private System.Windows.Forms.GroupBox grpConfigureActions;
		private System.Windows.Forms.ListView lstActions;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button cmdDeleteAction;
		private System.Windows.Forms.Button cmdEditAction;
		private System.Windows.Forms.Button cmdAddAction;
		private System.Windows.Forms.Label lblTagApplicationName;
		private System.Windows.Forms.Button cmdChangeApplication;
		private System.Windows.Forms.Label lblApplicationName;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdSave;
		private HighSign.Common.UI.Forms.Controls.GesturePictureBox gpbGesture;
	}
}