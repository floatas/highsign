using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HighSign.Common.Plugins;
using HighSign.Common.Applications;
using HighSign.Common.Gestures;
using HighSign.Common.Input;
using HighSign.Common.UI;

namespace HighSign.Plugins
{
	public class HostControl : IHostControl
	{
		#region Internal Manager Setters

		internal IApplicationManager _ApplicationManager;
		internal IGestureManager _GestureManager;
		internal IMouseCapture _MouseCapture;
		internal IPluginManager _PluginManager;
		internal IFormManager _FormManager;
		internal ITrayManager _TrayManager;

		#endregion

		public bool AllowEscapeKey
		{
			get	{ return true; } // Forms.InstanceManager.ActionDefinition.AllowEscapeKey; }
            set { } //Forms.InstanceManager.ActionDefinition.AllowEscapeKey = value; }
		}

		#region IHostControl Members

		public IApplicationManager ApplicationManager
		{
			get { return _ApplicationManager; }
		}

		public IGestureManager GestureManager
		{
			get { return _GestureManager; }
		}

		public IMouseCapture MouseCapture
		{
			get { return _MouseCapture; }
		}

		public IPluginManager PluginManager
		{
			get { return _PluginManager; }
		}

		public IFormManager FormManager
		{
			get { return _FormManager; }
		}

		public ITrayManager TrayManager
		{
			get { return _TrayManager; }
		}

		#endregion
	}
}
