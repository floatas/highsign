using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HighSign.CorePlugins.SendKeystrokes
{
	public partial class SendKeystrokesUI : Form
	{
		#region Constructors

		public SendKeystrokesUI()
		{
			InitializeComponent();

			this.TopLevel = false;
			this.FormBorderStyle = FormBorderStyle.None;
			this.AutoScroll = true;
			this.Dock = DockStyle.Fill;
		}

		#endregion

		#region Events

		private void escapeTextToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Escape existing text in textbox
			txtSendKeys.Text = ManagedWinapi.SendKeysEscaper.Instance.escape(txtSendKeys.Text, false);
		}

		#endregion
	}
}
