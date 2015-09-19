using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Drawing;
using ManagedWinapi.Windows;
using HighSign.Common;
using HighSign.Common.Applications;
using HighSign.Common.Input;
using HighSign.Common.Gestures;
using System.Text.RegularExpressions;

namespace HighSign.Applications
{
	public class ApplicationManager : ILoadable, IApplicationManager
	{
		#region Private Variables

		// Create variable to hold the only allowed instance of this class
		static readonly ApplicationManager _Instance = new ApplicationManager();
		List<IApplication> _Applications = new List<IApplication>();
		IApplication _CurrentApplication = null;

		#endregion

		#region Public Instance Properties

		public SystemWindow CaptureWindow { get; private set; }
		public IApplication CurrentApplication
		{
			get { return _CurrentApplication; }
			set
			{
				_CurrentApplication = value;
				OnApplicationChanged(new ApplicationChangedEventArgs(value));
			}
		}

		public IApplication[] Applications { get { return _Applications.ToArray(); } }

		public static ApplicationManager Instance
		{
			get { return _Instance; }
		}

		#endregion

		#region Constructors

		protected ApplicationManager()
		{
			// Consume Mouse Capture events
			Input.MouseCapture.Instance.CaptureStarted += new PointsCapturedEventHandler(MouseCapture_CaptureStarted);
			Input.MouseCapture.Instance.BeforePointsCaptured += new PointsCapturedEventHandler(MouseCapture_BeforePointsCaptured);
			
			// Consume Gesture Deleted events
			Gestures.GestureManager.Instance.GestureDeleted += new GestureEventHandler(GestureManager_GestureDeleted);

			// Load applications from disk, if file couldn't be loaded, create an empty applications list
			if (!LoadApplications())
				_Applications = new List<IApplication>();

			// Reload applications if options were saved
			HighSign.UI.FormManager.Instance.InstanceRequested += (o, e) =>
			{
				if (e.Instance is HighSign.UI.Forms.Options)
					(e.Instance as HighSign.UI.Forms.Options).OptionsSaved += (so, se) =>
						{
							if (!LoadApplications())
								_Applications = new List<IApplication>();
						};
			};
		}

		#endregion

		#region Events

		protected void MouseCapture_CaptureStarted(object sender, PointsCapturedEventArgs e)
		{
			CaptureWindow = GetWindowFromPoint(e.CapturePoint);
			if (GetApplicationFromWindow(CaptureWindow) is IgnoredApplication)
				e.Cancel = true;
		}

		protected void MouseCapture_BeforePointsCaptured(object sender, PointsCapturedEventArgs e)
		{
			// Derive capture window from capture point
			CaptureWindow = GetWindowFromPoint(e.CapturePoint);
			CurrentApplication = GetApplicationFromWindow(CaptureWindow);
		}

		protected void GestureManager_GestureDeleted(object sender, GestureEventArgs e)
		{
			// Remove any global actions that use this gesture
			GetGlobalApplication().RemoveAllActions(a => a.GestureName == e.GestureName);

			// Remove any user application actions that use this gesture
			foreach (UserApplication uApp in Applications.OfType<UserApplication>())
				uApp.RemoveAllActions(a => a.GestureName == e.GestureName);
		}

		#endregion

		#region Custom Events

		public event ApplicationChangedEventHandler ApplicationChanged;

		protected virtual void OnApplicationChanged(ApplicationChangedEventArgs e)
		{
			if (ApplicationChanged != null) ApplicationChanged(this, e);
		}

		#endregion

		#region Public Methods

		public void Load()
		{
			// Shortcut method to control singleton instantiation
		}

		public void AddApplication(IApplication Application)
		{
			_Applications.Add(Application);
		}

		public void RemoveApplication(IApplication Application)
		{
			_Applications.Remove(Application);
		}

		public bool SaveApplications()
		{
			// Save application list
			return Configuration.IO.FileManager.SaveObject<List<IApplication>>(_Applications, "Applications.json", new Type[] { typeof(GlobalApplication), typeof(UserApplication), typeof(IgnoredApplication), typeof(Action) });
		}

		public bool LoadApplications()
		{
			// Load application list from file
			_Applications = Configuration.IO.FileManager.LoadObject<List<IApplication>>("Applications.json", new Type[] { typeof(GlobalApplication), typeof(UserApplication), typeof(IgnoredApplication), typeof(Action) });

			// Ensure we got an object back
			if (_Applications == null)
				return false;	// No object, failed

			return true;	// Success
		}

		public SystemWindow GetWindowFromPoint(PointF Point)
		{
			return SystemWindow.FromPointEx((int)Math.Floor(Point.X), (int)Math.Floor(Point.Y), true, true);
		}

		public IApplication GetApplicationFromWindow()
		{
			return GetApplicationFromWindow(CaptureWindow);
		}

		public IApplication GetApplicationFromWindow(SystemWindow Window)
		{
			// Try to find any user or ignored applications that match the given system window
			foreach (IApplication definedApplication in Applications.Where(a => !(a is GlobalApplication)))
				if (definedApplication.IsSystemWindowMatch(Window))
					return definedApplication;

			// If not user or ignored application could be found, return the global application
			return GetGlobalApplication();
		}

		public IApplication GetApplicationFromPoint(PointF TestPoint)
		{
			return GetApplicationFromWindow(GetWindowFromPoint(TestPoint));
		}

		public IAction GetDefinedAction(string GestureName)
		{
			return GetDefinedAction(GestureName, this.CurrentApplication, false);
		}

		public IAction GetAnyDefinedAction(string GestureName)
		{
			return GetDefinedAction(GestureName, this.CurrentApplication, true);
		}

		public IAction GetDefinedAction(string GestureName, IApplication Application, bool UseGlobal)
		{
			// Attempt to retrieve an action on the application passed in
			IAction finalAction = Application.Actions.FirstOrDefault(a => a.GestureName == GestureName);

			// If there is was no action found on given application, try to get an action for global application
			if (finalAction == null && UseGlobal)
				finalAction = GetGlobalApplication().Actions.FirstOrDefault(a => a.GestureName == GestureName);

			// Return whatever the result was
			return finalAction;
		}

		public IApplication GetExistingUserApplication(string ApplicationName)
		{
			return Applications.FirstOrDefault(a => a is UserApplication && a.Name.ToLower() == ApplicationName.Trim().ToLower()) as UserApplication;
		}

		public bool IsGlobalGesture(string GestureName)
		{
			return _Applications.Exists(a => a is GlobalApplication && a.Actions.FirstOrDefault(ac => ac.GestureName.ToLower() == GestureName.Trim().ToLower()) != null);
		}

		public bool IsUserGesture(string GestureName)
		{
			return _Applications.Exists(a => a is UserApplication && a.Actions.FirstOrDefault(ac => ac.GestureName.ToLower() == GestureName.Trim().ToLower()) != null);
		}

		public bool IsGlobalAction(string ActionName)
		{
			return _Applications.Exists(a => a is GlobalApplication && a.Actions.Any(ac => ac.Name.ToLower() == ActionName.Trim().ToLower()));
		}

		public bool IsUserAction(string ActionName)
		{
			return _Applications.Exists(a => a is UserApplication && a.Actions.Any(ac => ac.Name.ToLower() == ActionName.Trim().ToLower()));
		}

		public bool ApplicationExists(string ApplicationName)
		{
			return _Applications.Exists(a => a.Name.ToLower() == ApplicationName.Trim().ToLower());
		}

		public IApplication[] GetAvailableUserApplications()
		{
			return Applications.Where(a => a is UserApplication).OrderBy(a => a.Name).Cast<UserApplication>().ToArray();
		}

		public IApplication[] GetIgnoredApplications()
		{
			return Applications.Where(a => a is IgnoredApplication).OrderBy(a => a.Name).Cast<IgnoredApplication>().ToArray();
		}

		public IApplication GetGlobalApplication()
		{
			if (!_Applications.Exists(a => a is GlobalApplication))
				_Applications.Add(new GlobalApplication());

			return _Applications.First(a => a is GlobalApplication) as GlobalApplication;
		}

		public void RemoveGlobalAction(string ActionName)
		{
			RemoveAction(ActionName, true);
		}

		public void RemoveNonGlobalAction(string ActionName)
		{
			RemoveAction(ActionName, false);
		}

		public bool IsGlobalApplication(IApplication Application)
		{
			return (Application == GetGlobalApplication());
		}

		#endregion

		#region Private Methods

		private void RemoveAction(string ActionName, bool Global)
		{
			if (Global)
				// Attempt to remove action from global actions
				GetGlobalApplication().RemoveAllActions(a => a.Name.ToLower().Trim() == ActionName.ToLower().Trim());
			else
				// Select applications where this action may exist and delete them
				foreach (IApplication app in Applications.Where(a => a.Actions.Any(ac => ac.Name == ActionName)))
					app.RemoveAllActions(a => a.Name.ToLower().Trim() == ActionName.ToLower().Trim());
		}

		#endregion
	}
}
