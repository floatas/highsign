using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HighSign.Common;
using HighSign.Common.Input;
using HighSign.PointPatterns;
using ManagedWinapi.Hooks;
using System.Diagnostics;

namespace HighSign.Input
{
	public class MouseCapture : ILoadable, IMouseCapture
	{
		#region Private Variables

		// Create new mouse hook control to capture global input from mouse, and create an event translator to get formal events
		ManagedWinapi.Hooks.LowLevelMouseHook MouseHook = new ManagedWinapi.Hooks.LowLevelMouseHook();
		MouseEventTranslator MouseEventTranslator = new MouseEventTranslator();

		// Create variable to hold points in current gesture
		List<PointF> _PointsCaptured = new List<PointF>();

		// Create variable to hold the only allowed instance of this class
		static readonly MouseCapture _Instance = new MouseCapture();

		// Create enumeration to identify mouse buttons
		private enum MouseEventFlagValues
		{
			LEFTDOWN = 0x00000002,
			LEFTUP = 0x00000004,
			MIDDLEDOWN = 0x00000020,
			MIDDLEUP = 0x00000040,
			MOVE = 0x00000001,
			RIGHTDOWN = 0x00000008,
			RIGHTUP = 0x00000010,
			WHEEL = 0x00000800,
			HWHEEL = 0x00001000
		}

		// Store original mouse message
		LowLevelMouseMessage _OriginalMessage = null;

		#endregion

		#region Public Instance Properties

		public PointF CapturePoint
		{
			get { return _PointsCaptured.FirstOrDefault(); }
		}

		public PointF[] InputPoints
		{
			get { return _PointsCaptured.ToArray(); }
		}

		public CaptureState State { get; private set; }

		#endregion

		#region Custom Events

		// Create an event to notify subscribers that CaptureState has been changed
		public event StateChangedEventHandler StateChanged;

		protected virtual void OnStateChanged(StateChangedEventArgs e)
		{
			StateChanged(this, e);
		}

		// Create event to notify subscribers that the capture process has started
		public event PointsCapturedEventHandler CaptureStarted;

		protected virtual void OnCaptureStarted(PointsCapturedEventArgs e)
		{
			if (CaptureStarted != null) CaptureStarted(this, e);
		}

		// Create event to notify subscribers that a point set has been captured
		public event PointsCapturedEventHandler AfterPointsCaptured;
		public event PointsCapturedEventHandler BeforePointsCaptured;

		protected virtual void OnAfterPointsCaptured(PointsCapturedEventArgs e)
		{
			if (AfterPointsCaptured != null) AfterPointsCaptured(this, e);
		}

		protected virtual void OnBeforePointsCaptured(PointsCapturedEventArgs e)
		{
			if (BeforePointsCaptured != null) BeforePointsCaptured(this, e);
		}

        // Create event to notify subscribers that a single point has been captured
        public event PointsCapturedEventHandler PointCaptured;

        protected virtual void OnPointCaptured(PointsCapturedEventArgs e)
        {
            if (PointCaptured != null) PointCaptured(this, e);
        }

		// Create event to notify subscribers that the capture process has ended
		public event PointsCapturedEventHandler CaptureEnded;

		protected virtual void OnCaptureEnded(PointsCapturedEventArgs e)
		{
			if (CaptureEnded != null) CaptureEnded(this, e);
		}

		// Create event to notify subscribers that the capture has been canceled
		public event PointsCapturedEventHandler CaptureCanceled;

		protected virtual void OnCaptureCanceled(PointsCapturedEventArgs e)
		{
			if (CaptureCanceled != null) CaptureCanceled(this, e);
		}

		#endregion

		#region Public Properties

		public static MouseCapture Instance
		{
			get { return _Instance; }
		}

		#endregion

		#region Constructors

		protected MouseCapture()
		{
			MouseHook.MouseIntercepted += new ManagedWinapi.Hooks.LowLevelMouseHook.MouseCallback(MouseHook_MouseIntercepted);
			MouseEventTranslator.MouseDown += new EventHandler<MouseMessageEventArgs>(MouseEventTranslator_MouseDown);
			MouseEventTranslator.MouseUp += new EventHandler<MouseMessageEventArgs>(MouseEventTranslator_MouseUp);
			MouseEventTranslator.MouseMove += new EventHandler<MouseMessageEventArgs>(MouseEventTranslator_MouseMove);

			// Enable mouse capture on instance load
			//EnableMouseCapture();
		}

		#endregion

		#region Hook Events

		protected void MouseHook_MouseIntercepted(int msg, ManagedWinapi.Windows.POINT pt, int mouseData, int flags, int time, IntPtr dwExtraInfo, ref bool handled)
		{
			// Translate raw mouse event into individiual events (MouseDown, MouseUp, and MouseMove) and stop the mouse event chain if
			// one of the individual events handled it.
			MouseEventTranslator.TranslateMouseEvent(new LowLevelMouseMessage(msg, pt, mouseData, flags, time, dwExtraInfo));
			handled = MouseEventTranslator.Handled;
		}

		protected void MouseEventTranslator_MouseDown(object sender, MouseMessageEventArgs e)
		{
			// Disregard all but capture button events
			if (e.Button != MouseButtons.Right)
				return;

			// Can we begin a new gesture capture
			if (State == CaptureState.Ready)
			{
				Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

				// Store original mouse message
				_OriginalMessage = e.MouseMessage;

				// Try to begin capture process, if capture started then don't notify other applications of a mouse event, otherwise do
				e.Handled = TryBeginCapture(e.Location);

				if (!e.Handled)
					Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal;
			}
		}

		protected void MouseEventTranslator_MouseMove(object sender, MouseMessageEventArgs e)
		{
			// Only add point if we're capturing
			if (State == CaptureState.Capturing || State == CaptureState.CapturingInvalid)
				AddPoint(e.Location);
		}

		protected void MouseEventTranslator_MouseUp(object sender, MouseMessageEventArgs e)
		{
			// Disregard all but right MouseUp events
			if (e.Button != MouseButtons.Right)
				return;

			// Replay original event if capturing was invalid, otherwise
			// successfully end the capture process and handle this MouseUp event

			switch (State)
			{
				case CaptureState.CapturingInvalid:
					ReplyOriginalEvent();
					Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal;
					break;
				case CaptureState.Capturing:
					EndCapture();
					Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal;
					e.Handled = true;
					break;
			}
		}

		#endregion

		#region Private Methods

		private bool TryBeginCapture(PointF FirstPoint)
		{
			// Create capture args so we can notify subscribers that capture has started and allow them to cancel if they want.
			PointsCapturedEventArgs captureStartedArgs = new PointsCapturedEventArgs(new PointF[] { FirstPoint });
			OnCaptureStarted(captureStartedArgs);
			if (captureStartedArgs.Cancel)
				return false;

			// Beginning of new gesture, set to CapturingInvalid state because the capture isn't official yet,
			// if the user chooses to release the mouse button during the CapturingInvalid state, then we'll
			// simulate the original mouse event
			State = CaptureState.CapturingInvalid;

			// Clear old gesture from point list so we can start adding the new captures points to the list
			_PointsCaptured.Clear();

			// Add the first point to the newly emptied list
			AddPoint(FirstPoint);

			return true;
		}

		private void EndCapture()
		{
			// Create points capture event args, to be used to send off to event subscribers or to simulate original mouse event
			PointsCapturedEventArgs pointsInformation = new PointsCapturedEventArgs(InputPoints, State);

			// We've completed a successful capture, set state back to ready
			State = CaptureState.Ready;

			// Notify subscribers that capture has ended
			OnCaptureEnded(pointsInformation);

			// Notify PointsCaptured event subscribers that points have been captured.
			OnBeforePointsCaptured(pointsInformation);

			if (!pointsInformation.Cancel)
				OnAfterPointsCaptured(pointsInformation);
		}

		private void CancelCapture()
		{
			// Notify subscribers that gesture capture has been canceled
			OnCaptureCanceled(new PointsCapturedEventArgs(InputPoints, State));

			// Reply original user created event
			ReplyOriginalEvent();
		}

		private void AddPoint(PointF Point)
		{
			// Don't accept point if it's within specified distance of last point unless it's the first point
			if (_PointsCaptured.Count() > 0 && PointPatterns.PointPatternMath.GetDistance(_PointsCaptured.Last(), Point) < Properties.Settings.Default.MinimumPointDistance)
				return;

			// Add point to captured points list
			_PointsCaptured.Add(Point);

			// If gesture capturing is not official yet, check it's length and if it's longer than threshold, make capturing official
			if (State == CaptureState.CapturingInvalid && PointPatterns.PointPatternMath.GetDistance(_PointsCaptured.First(), _PointsCaptured.Last()) >= Properties.Settings.Default.ActivationDistance)
				State = CaptureState.Capturing;

            // Notify subscribers that point has been captured
			OnPointCaptured(new PointsCapturedEventArgs(_PointsCaptured.ToArray(), Point, State));

			// Check if the user is trying to cancel gesture
			CheckCancel();	// This will end the gesture capture process if a capture "shake" is found
		}

		private void CheckCancel()
		{
			int reversalCount = 0;
			double previousAngle = 0;
			double nextAngle = 0;
			PointF previousPoint = default(PointF);
			PointF currentPoint = default(PointF);
			PointF nextPoint = default(PointF);

			// Loop through all points captured so far except for the first and last point.
			// We skip the first and last point because we need that one point margin to allow us to
			// compare the next and previous points (relative to current point index) so that we can check
			// for hard reversals (quick back and forth)
			for (int currentIndex = 1; currentIndex < _PointsCaptured.Count() - 1; currentIndex ++)
			{
				// Get points based on current index
				previousPoint = _PointsCaptured[currentIndex - 1];
				currentPoint = _PointsCaptured[currentIndex];
				nextPoint = _PointsCaptured[currentIndex + 1];

				// Get angular change between previous and next point
				previousAngle = PointPatternMath.GetAngularGradient(previousPoint, currentPoint);
				nextAngle = PointPatternMath.GetAngularGradient(currentPoint, nextPoint);

				// Check if we have a reversal, do this by getting the angular change (delta) between the previous angle and the 
				// next angle (in radians), then convert the delta from radians to degrees so that we have an easy way to see if our 
				// delta is within the threshold (between ReversalAngleThreshold and 180) to be considered a reversal
				double angularDelta = PointPatternMath.GetDegreeFromRadian(PointPatternMath.GetAngularDelta(previousAngle, nextAngle));
				if (angularDelta > Properties.Settings.Default.ReversalAngleThreshold)
					reversalCount++;

				// If we have enough reversals to cancel then cancel the capture process
				if (reversalCount > Properties.Settings.Default.ReversalCountCancel)
				{
					CancelCapture();
					return;
				}
			}
		}

		private void ReplyOriginalEvent()
		{
			// Temporarily disable mouse capture (so our injected event doesn't start a new chain of recording)
			State = CaptureState.Disabled;

			// Reply original mouse message
			if (_OriginalMessage != null)
				_OriginalMessage.ReplayEvent();

			// Enable mouse capture
			State = CaptureState.Ready;
		}

		#endregion

		#region Public Methods

		public void Load()
		{
			// Shortcut method to control singleton instantiation
		}

		public void EnableMouseCapture()
		{
			// Install mouse hook if it hasn't been installed or is uninstalled
			if (!MouseHook.Hooked)
				MouseHook.StartHook();

			// Ensure that the mouse hook is enabled, unless the user has selected to disable gestures
			if (State != CaptureState.UserDisabled)
				State = CaptureState.Ready;
		}

		public void DisableMouseCapture()
		{
			// Disable mouse hook without uninstalling the hook, if state is UserDisabled, take no action
			// Had to add this logic to Enable/Disable to avoid reseting of state from existing program logic
			// See ToggleUserDisableMouseCapture()...
			if (State != CaptureState.UserDisabled)
				State = CaptureState.Disabled;
		}

		public void ToggleUserDisableMouseCapture()
		{
			// Toggle User selected Gesture Disabling
			// Added UserDisabled to CaptureState enum since Ready and Disabled can't be used
			// due to the existing logic of Enabling/Disabling for UI/menu popup/etc.
			// The reason I had to set state to Ready if !UserDisabled was due to the sequence of the tray events.
			// I originally had to set to Disable since if you're in the popup it's disabled, however, the popup onclose
			// fires before the menu item's code, so it was back to Ready before this block was executed.  Although, it probably 
			// makes more sense to set it to Ready in the event this is called from another location.
			State = State == CaptureState.UserDisabled ? CaptureState.Ready : CaptureState.UserDisabled;
			StateChanged(this, new StateChangedEventArgs(State));
			
		}
		
		public void DestroyMouseHook()
		{
			// Uninstall mouse hook completely
			MouseHook.Unhook();
		}

		#endregion
	}
}
