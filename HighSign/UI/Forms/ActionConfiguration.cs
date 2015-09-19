using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HighSign.UI.Forms
{
	public partial class ActionConfiguration : Form
	{
		#region Constructors

		public ActionConfiguration()
		{
			InitializeComponent();

			this.Load += new EventHandler(ActionConfiguration_Load);
			this.cmdChangeApplication.Click += new EventHandler(cmdChangeApplication_Click);
		}

		#endregion

		#region Events

		protected void ActionConfiguration_Load(object sender, EventArgs e)
		{
			//gpbGesture.Gesture = Gestures.GestureManager.Instance.Gestures.First();
		}

		protected void cmdChangeApplication_Click(object sender, EventArgs e)
		{
			// Create new action selection dialog
			Common.UI.Dialogs.ApplicationDialog appDialog = new Common.UI.Dialogs.ApplicationDialog(Applications.ApplicationManager.Instance);

			// Make sure the user wants to commit his changes
			if (appDialog.ShowDialog() == DialogResult.OK)
			{
				//// Get configured information from dialog
				//lblApplicationName.Text = appDialog.ApplicationName;
				//lblMatchUsing.Text = appDialog.MatchUsing.ToString();
				//lblMatchString.Text = appDialog.MatchString;
				//lblUseRegex.Text = appDialog.IsRegularExpression ? "Yes" : "No";
				//pbApplicationIcon.Image = appDialog.ApplicationIcon;
			}
		}

		#endregion
	}
}
