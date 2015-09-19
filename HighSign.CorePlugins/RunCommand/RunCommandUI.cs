using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HighSign.CorePlugins.RunCommand
{
	public partial class RunCommandUI : Form
	{
		#region Private Variables

		private RunCommandSettings _Settings = null;

		#endregion

		#region Constructors

		public RunCommandUI()
		{
			InitializeComponent();

			this.TopLevel = false;
			this.FormBorderStyle = FormBorderStyle.None;
			this.AutoScroll = true;
			this.Dock = DockStyle.Fill;

			this.cmdSelectFile.Click += new EventHandler(cmdSelectFile_Click);
		}

		public RunCommandUI(RunCommandSettings CommandSettings) : this()
		{
			Settings = CommandSettings;
		}

		#endregion

		#region Public Properties

		public RunCommandSettings Settings
		{
			get
			{
				_Settings = new RunCommandSettings();
				_Settings.Command = txtCommand.Text.Trim();
				_Settings.Arguments = txtArguments.Text.Trim();

				return _Settings;
			}
			set
			{
				_Settings = value;
				txtCommand.Text = _Settings.Command;
				txtArguments.Text = _Settings.Arguments;
			}
		}

		#endregion

		#region Events

		public void cmdSelectFile_Click(object sender, EventArgs e)
		{
			// Create open file dialog to let user select file to open
			using (OpenFileDialog ofDialog = new OpenFileDialog())
			{
				// Set initial directory if path is valid
				if (IsValidPath(txtCommand.Text.Trim()))
					ofDialog.InitialDirectory = Path.GetDirectoryName(txtCommand.Text.Trim());

				if (ofDialog.ShowDialog() == DialogResult.OK)
					txtCommand.Text = ofDialog.FileName;
			}
		}

		#endregion

		#region Private Instance Methods

		private bool IsValidPath(string path)
		{
			return !Path.GetInvalidPathChars().Any(fnc => path.Contains(fnc)) && path != String.Empty;
		}

		#endregion
	}
}
