using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using HighSign.Common.Plugins;
using Microsoft.Win32;

namespace HighSign.CorePlugins
{
	public class DefaultBrowser : IPlugin
	{
		#region Private Variables

		IHostControl _HostControl = null;

		#endregion

		#region IAction Properties

		public string Name
		{
			get { return "Open Web Browser"; }
		}

		public string Description
		{
			get { return "Opens the default web browser configured for this machine"; }
		}

		public Form GUI
		{
			get { return null; }
		}

		public string Category
		{
			get { return "Internet"; }
		}

		public bool IsAction
		{
			get { return true; }
		}

		#endregion

		#region IAction Methods

		public void Initialize()
		{

		}

		public bool Gestured(PointInfo ActionPoint)
		{
			// Extract default browser path from registery
			string defaultBrowserPath = GetDefaultBrowserPath();

			// If path is incorrect or empty and exception will be thrown, catch it and return false
			try { Process.Start(defaultBrowserPath); }
			catch { return false; }

			return true;
		}

		public void Deserialize(string SerializedData)
		{
			// Nothing to deserialize
		}

		public string Serialize()
		{
			// Nothing to serialize, send empty string
			return "";
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Reads path of default browser from registry
		/// </summary>
		/// <returns>Rooted path to the browser</returns>
		private string GetDefaultBrowserPath()
		{
			string key = @"HTTP\shell\open\command";
			RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(key, false);

			// Ensure we found a registry key
			if (registryKey == null)
				return "";

			// Get default browser path
			string registryValue = (string)registryKey.GetValue(null, null) ?? "";
			
			// Make sure we got a value back
			if (String.IsNullOrEmpty(registryValue))
				return "";

			// We have a value, seperate parts
			string[] pathPieces = registryValue.Split('"');

			// Do we have the peice we need
			if (pathPieces.Count() >= 2)
				return pathPieces[1];
			else
				return "";
		}

		#endregion

		#region Host Control

		public IHostControl HostControl
		{
			get { return _HostControl; }
			set { _HostControl = value; }
		}

		#endregion
	}
}