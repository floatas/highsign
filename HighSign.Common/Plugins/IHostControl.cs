using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HighSign.Common.Applications;
using HighSign.Common.Gestures;
using HighSign.Common.Input;
using HighSign.Common.Plugins;
using HighSign.Common.UI;

namespace HighSign.Common.Plugins
{
	public interface IHostControl
	{
		IApplicationManager ApplicationManager { get; }
		IGestureManager GestureManager { get; }
		IMouseCapture MouseCapture { get; }
		IPluginManager PluginManager { get; }
		IFormManager FormManager { get; }
		ITrayManager TrayManager { get; }

		#region Methods

		bool AllowEscapeKey { get; set; }

		#endregion
	}
}
