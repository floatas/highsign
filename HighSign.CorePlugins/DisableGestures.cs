using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using HighSign.Common.Plugins;

namespace HighSign.CorePlugins
{
	public class DisableGestures : IPlugin
	{
		#region Private Variables

		IHostControl _HostControl = null;

		#endregion

		#region IAction Properties

		public string Name
		{
			get { return "Disable Gestures"; }
		}

		public string Description
		{
			get { return "Disables High Sign from capturing gestures."; }
		}

		public Form GUI
		{
			get { return null; }
		}

		public string Category
		{
			get { return "High Sign"; }
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
			_HostControl.TrayManager.ToggleDisableGestures();
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

		public void ShowGUI(bool IsNew)
		{
			// Nothing to do here
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