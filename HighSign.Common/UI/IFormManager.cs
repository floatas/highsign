using System;
using System.Windows.Forms;

namespace HighSign.Common.UI
{
	public interface IFormManager
	{
		Form ActionDefinition { get; }
		Form ApplicationDefinition { get; }
		Form AvailableActions { get; }
		Form AvailableGestures { get; }
		Form GestureDefinition { get; }
		Form Options { get; }
		Form Surface { get; }
		Form IgnoredApplications { get; }
		event InstanceEventHandler InstanceRequested;
	}
}
