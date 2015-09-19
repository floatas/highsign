namespace HighSign.CorePlugins.Volume
{
    partial class VolumeUI
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
			this.cboMethod = new System.Windows.Forms.ComboBox();
			this.cboPercent = new System.Windows.Forms.ComboBox();
			this.lblAction = new System.Windows.Forms.Label();
			this.lblPercent = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cboMethod
			// 
			this.cboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboMethod.FormattingEnabled = true;
			this.cboMethod.Items.AddRange(new object[] {
            "Increase Volume By",
            "Decrease Volume By",
            "Toggle Mute"});
			this.cboMethod.Location = new System.Drawing.Point(5, 26);
			this.cboMethod.Name = "cboMethod";
			this.cboMethod.Size = new System.Drawing.Size(246, 24);
			this.cboMethod.TabIndex = 2;
			this.cboMethod.SelectedIndexChanged += new System.EventHandler(this.cboMethod_SelectedIndexChanged);
			// 
			// cboPercent
			// 
			this.cboPercent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPercent.FormattingEnabled = true;
			this.cboPercent.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90"});
			this.cboPercent.Location = new System.Drawing.Point(259, 26);
			this.cboPercent.Name = "cboPercent";
			this.cboPercent.Size = new System.Drawing.Size(54, 24);
			this.cboPercent.TabIndex = 3;
			this.cboPercent.SelectedIndexChanged += new System.EventHandler(this.cboPercent_SelectedIndexChanged);
			// 
			// lblAction
			// 
			this.lblAction.AutoSize = true;
			this.lblAction.Location = new System.Drawing.Point(5, 3);
			this.lblAction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblAction.Name = "lblAction";
			this.lblAction.Size = new System.Drawing.Size(47, 17);
			this.lblAction.TabIndex = 6;
			this.lblAction.Text = "Action";
			// 
			// lblPercent
			// 
			this.lblPercent.AutoSize = true;
			this.lblPercent.Location = new System.Drawing.Point(257, 3);
			this.lblPercent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPercent.Name = "lblPercent";
			this.lblPercent.Size = new System.Drawing.Size(57, 17);
			this.lblPercent.TabIndex = 7;
			this.lblPercent.Text = "Percent";
			// 
			// VolumeUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(319, 56);
			this.Controls.Add(this.lblPercent);
			this.Controls.Add(this.lblAction);
			this.Controls.Add(this.cboPercent);
			this.Controls.Add(this.cboMethod);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "VolumeUI";
			this.Text = "Volume";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMethod;
        private System.Windows.Forms.ComboBox cboPercent;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lblPercent;

    }
}