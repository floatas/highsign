using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using HighSign.Common.Plugins;
using System.Threading;

namespace HighSign.CorePlugins.RunCommand
{
	public class RunCommandPlugin : IPlugin
	{
		#region Private Variables

		private RunCommandUI _GUI = null;
		private RunCommandSettings _Settings = null;

		#endregion

		#region Public Properties

		public string Name
		{
			get { return "Command or Program"; }
		}

		public string Description
		{
			get { return "Runs a user specified command or program"; }
		}

		public Form GUI
		{
			get
			{
				if (_GUI == null || _GUI.IsDisposed)
					_GUI = CreateGUI();

				return _GUI;
			}
		}

		public RunCommandUI TypedGUI
		{
			get { return (RunCommandUI)GUI; }
		}

		public string Category
		{
			get { return "Run"; }
		}

		public bool IsAction
		{
			get { return true; }
		}

		#endregion

		#region Public Methods

		public void Initialize()
		{

		}

		public bool Gestured(PointInfo ActionPoint)
		{
			Thread newThread = new Thread(new ParameterizedThreadStart(ExecuteCommand));
			newThread.Start(_Settings);

			return true;
		}

		public void Deserialize(string SerializedData)
		{
			// Clear existing settings if nothing was passed in
			if (String.IsNullOrEmpty(SerializedData))
			{
				_Settings = new RunCommandSettings();
				return;
			}

			// Create memory stream from serialized data string
			MemoryStream memStream = new MemoryStream(Encoding.Default.GetBytes(SerializedData));

			// Create json serializer to deserialize json file
			DataContractJsonSerializer jSerial = new DataContractJsonSerializer(typeof(RunCommandSettings));

			// Deserialize json file into actions list
			_Settings = jSerial.ReadObject(memStream) as RunCommandSettings;

			if (_Settings == null)
				_Settings = new RunCommandSettings();
		}

		public string Serialize()
		{
			_Settings = _GUI.Settings;

			if (_Settings == null)
				_Settings = new RunCommandSettings();

			// Create json serializer to serialize json file
			DataContractJsonSerializer jSerial = new DataContractJsonSerializer(typeof(RunCommandSettings));

			// Open json file
			MemoryStream mStream = new MemoryStream();
			StreamWriter sWrite = new StreamWriter(mStream);

			// Serialize actions into json file
			jSerial.WriteObject(mStream, _Settings);

			return Encoding.Default.GetString(mStream.ToArray());
		}

		#endregion

		#region Private Methods

		private RunCommandUI CreateGUI()
		{
			RunCommandUI newGUI = new RunCommandUI();
			newGUI.Shown += (o, e) => { TypedGUI.Settings = _Settings; };

			return newGUI;
		}

		private void ExecuteCommand(object Settings)
		{
			// Cast object parameter as RunCommandSettings object
			RunCommandSettings rcSettings = Settings as RunCommandSettings;
			if (rcSettings == null) return;

			// Catch any errors (i.e. bad command, bad filename, bad anything)
			try
			{
				
				Process Process = new Process();
				// Expand environment variable to support %SYSTEMROOT%, etc.
				Process.StartInfo.FileName = Environment.ExpandEnvironmentVariables(rcSettings.Command);
				Process.StartInfo.Arguments = Environment.ExpandEnvironmentVariables(rcSettings.Arguments);
				Process.StartInfo.UseShellExecute = true;
				Process.Start();
			}
			catch
			{
				// Errors are stupid
			}
		}

		#endregion

		#region Host Control

		public IHostControl HostControl { get; set; }

		#endregion
	}
}