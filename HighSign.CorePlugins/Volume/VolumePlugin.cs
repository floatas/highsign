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
using ManagedWinapi.Windows;
using ManagedWinapi.Audio.Mixer;
using CoreAudioApi;

namespace HighSign.CorePlugins.Volume
{
	public class VolumePlugin : IPlugin
	{
		#region Private Variables

		private VolumeUI _GUI = null;
		private VolumeSettings _Settings = null;

		private enum Method
		{
			VolumeUp = 0,
			VolumeDown = 1,
			Mute = 2
		}

		private enum CompatibilityMode
		{
			Compatible,
			Standard
		}

		#endregion

		#region Public Properties

		public string Name
		{
			get { return "Adjust Volume"; }
		}

		public string Description
		{
			get { return GetDescription(_Settings); }
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

		public VolumeUI TypedGUI
		{
			get { return (VolumeUI)GUI; }
		}

		public string Category
		{
			get { return "Multimedia"; }
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

		public bool Gestured(Common.Plugins.PointInfo ActionPoint)
		{
			return AdjustVolume(_Settings);
		}

		public void Deserialize(string SerializedData)
		{
			// Clear existing settings if nothing was passed in
			if (String.IsNullOrEmpty(SerializedData))
			{
				_Settings = new VolumeSettings();
				return;
			}

			// Create memory stream from serialized data string
			MemoryStream memStream = new MemoryStream(Encoding.Default.GetBytes(SerializedData));

			// Create json serializer to deserialize json file
			DataContractJsonSerializer jSerial = new DataContractJsonSerializer(typeof(VolumeSettings));

			// Deserialize json file into actions list
			_Settings = jSerial.ReadObject(memStream) as VolumeSettings;

			if (_Settings == null)
				_Settings = new VolumeSettings();
		}

		public string Serialize()
		{
			_Settings = _GUI.Settings;

			if (_Settings == null)
				_Settings = new VolumeSettings();

			// Create json serializer to serialize json file
			DataContractJsonSerializer jSerial = new DataContractJsonSerializer(typeof(VolumeSettings));

			// Open json file
			MemoryStream mStream = new MemoryStream();
			StreamWriter sWrite = new StreamWriter(mStream);

			// Serialize actions into json file
			jSerial.WriteObject(mStream, _Settings);

			return Encoding.Default.GetString(mStream.ToArray());
		}

		#endregion

		#region Private Methods

		private VolumeUI CreateGUI()
		{
			VolumeUI newGUI = new VolumeUI();

			newGUI.Shown += (o, e) =>
			{
				TypedGUI.Settings = _Settings;
				TypedGUI.HostControl = HostControl;
			};

			return newGUI;
		}

		private string GetDescription(VolumeSettings Settings)
		{
			if (Settings == null)
				return "Adjust the Windows volume";

			// Create string to store final output description
			string strOutput = "";

			// Build output string
			switch (Settings.Method)
			{
				case 0:
					strOutput = "Increase the system volume by " + Settings.Percent.ToString() + "%";
					break;
				case 1:
					strOutput = "Decrease the system volume by " + Settings.Percent.ToString() + "%";
					break;
				case 2:
					strOutput = "Toggle the system mute";
					break;
			}

			return strOutput;
		}

		private bool AdjustVolume(VolumeSettings Settings)
		{
			if (Settings == null)
				return false;

			OperatingSystem osInfo = Environment.OSVersion;

			if (osInfo.Platform != PlatformID.Win32NT)
				return false;

			CompatibilityMode Mode = osInfo.Version.Major <= 5 ? CompatibilityMode.Compatible : CompatibilityMode.Standard;

			try
			{
				switch ((Method)_Settings.Method)
				{
					case Method.VolumeUp:
						ChangeVolume(Mode, Method.VolumeUp);
						break;
					case Method.VolumeDown:
						ChangeVolume(Mode, Method.VolumeDown);
						break;
					case Method.Mute:
						SetMute(Mode);
						break;
				}

				return true;
			}
			catch
			{
				MessageBox.Show("Could not change volume settings.", "Volume Change Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		private void ChangeVolume(CompatibilityMode Mode, Method ChangeMethod)
		{
			if (Mode == CompatibilityMode.Compatible)
			{
				FaderMixerControl fmx = ((MixerLine)Mixer.OpenMixer(0).DestinationLines[0]).VolumeControl;
				int iPercent = (fmx.Maximum / 100) * _Settings.Percent;
				iPercent = ChangeMethod == Method.VolumeUp ? iPercent : -iPercent;
				fmx.Values = fmx.Values.Select(i => i = GetCompatibleVolumeRange(i + iPercent, fmx.Minimum, fmx.Maximum)).ToArray();
			}
			else
			{
				MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
				MMDevice defaultDevice = devEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
				
				float fPercent = (float)_Settings.Percent / 100F;
				fPercent = ChangeMethod == Method.VolumeUp ? fPercent : -fPercent;
				float newValue = defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar + fPercent;

				defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = GetCompatibleVolumeRange(newValue, 0F, 1F);
			}
		}

		private void SetMute(CompatibilityMode Mode)
		{
			if (Mode == CompatibilityMode.Compatible)
			{
				BooleanMixerControl bmx = ((MixerLine)Mixer.OpenMixer(0).DestinationLines[0]).MuteSwitch;
				bmx.SetMute(!bmx.IsMuted());
			}
			else
			{
				MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
				MMDevice defaultDevice = devEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
				defaultDevice.AudioEndpointVolume.Mute = !defaultDevice.AudioEndpointVolume.Mute;
			}
		}

		private float GetCompatibleVolumeRange(float Value, float Minimum, float Maximum)
		{
			return Value > Maximum ? Maximum : Value < Minimum ? Minimum : Value;
		}

		private int GetCompatibleVolumeRange(int Value, int Minimum, int Maximum)
		{
			return Value > Maximum ? Maximum : Value < Minimum ? Minimum : Value;
		}

		#endregion

		#region Host Control

		public IHostControl HostControl { get; set; }

		#endregion
	}
}
