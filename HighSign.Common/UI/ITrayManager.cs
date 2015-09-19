using System;
namespace HighSign.Common.UI
{
	public interface ITrayManager
	{
		void EnterUserDefinedMode();
		void StartTeaching();
		void StopTeaching();
		void ToggleDisableGestures();
		void ToggleTeaching();
	}
}
