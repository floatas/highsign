using System;

namespace HighSign.Common.Applications
{
	public interface IApplicationManager
	{
		event ApplicationChangedEventHandler ApplicationChanged;
		bool ApplicationExists(string ApplicationName);
		IApplication[] Applications { get; }
		ManagedWinapi.Windows.SystemWindow CaptureWindow { get; }
		IApplication CurrentApplication { get; set; }
		void AddApplication(IApplication Application);
		IAction GetAnyDefinedAction(string GestureName);
		IApplication GetApplicationFromPoint(System.Drawing.PointF TestPoint);
		IApplication GetApplicationFromWindow(ManagedWinapi.Windows.SystemWindow Window);
		IApplication[] GetAvailableUserApplications();
		IAction GetDefinedAction(string GestureName, IApplication Application, bool UseGlobal);
		IAction GetDefinedAction(string GestureName);
		IApplication GetExistingUserApplication(string ApplicationName);
		IApplication GetGlobalApplication();
		ManagedWinapi.Windows.SystemWindow GetWindowFromPoint(System.Drawing.PointF Point);
		bool IsGlobalGesture(string GestureName);
		bool IsUserGesture(string GestureName);
		bool LoadApplications();
		void RemoveGlobalAction(string ActionName);
		void RemoveNonGlobalAction(string ActionName);
		bool SaveApplications();
	}
}
