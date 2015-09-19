using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using HighSign.Common;
using HighSign.Common.Gestures;
using HighSign.Common.Plugins;
using System.Drawing;
using HighSign.PointPatterns;
using HighSign.Common.Input;

namespace HighSign.Gestures
{
	public class GestureManager : ILoadable, IGestureManager
	{
		#region Private Variables

		// Create variable to hold the only allowed instance of this class
		static readonly GestureManager _Instance = new GestureManager();

		// Create read/write list of IGestures to hold system gestures
		List<IGesture> _Gestures = new List<IGesture>();

		// Create PointPatternAnalyzer to process gestures when received
		PointPatternAnalyzer gestureAnalyzer = null;

		#endregion

		#region Public Instance Properties

		public string GestureName { get; set; }
		public IGesture[] Gestures
		{
			get
			{
				if (_Gestures == null)
					_Gestures = new List<IGesture>();

				return _Gestures.ToArray();
			}
		}

		#endregion

		#region Constructors

		protected GestureManager()
		{
			if (!LoadGestures())
				_Gestures = new List<IGesture>();

			// Instantiate gesture analyzer using gestures loaded from file
			gestureAnalyzer = new PointPatternAnalyzer(Gestures);

			// Wireup event to mouse capture class to catch points captured
			Input.MouseCapture.Instance.BeforePointsCaptured += new PointsCapturedEventHandler(MouseCapture_BeforePointsCaptured);
			Input.MouseCapture.Instance.AfterPointsCaptured += new PointsCapturedEventHandler(MouseCapture_AfterPointsCaptured);

			// Reload gestures if options were saved
			HighSign.UI.FormManager.Instance.InstanceRequested += (o, e) =>
			{
				if (e.Instance is HighSign.UI.Forms.Options)
					(e.Instance as HighSign.UI.Forms.Options).OptionsSaved += (so, se) => { LoadGestures(); };
			};
		}

		#endregion

		#region Public Type Properties

		public static GestureManager Instance
		{
			get { return _Instance; }
		}

		#endregion

		#region Events

		protected void MouseCapture_BeforePointsCaptured(object sender, PointsCapturedEventArgs e)
		{
			this.GestureName = GetGestureName(e.Points);
		}

		protected void MouseCapture_AfterPointsCaptured(object sender, PointsCapturedEventArgs e)
		{
			RecognizeGesture(e.Points, e.CapturePoint);
		}

		#endregion

		#region Custom Events

		// Define events to allow other classes to subscribe to
		public event RecognitionEventHandler GestureRecognized;
		public event RecognitionEventHandler GestureNotRecognized;

		// Define events to notify subscribers that a gesture has been deleted
		public event GestureEventHandler GestureDeleted;

		// Define protected method to notifiy subscribers of events
		protected virtual void OnGestureRecognized(RecognitionEventArgs e)
		{
			if (GestureRecognized != null) GestureRecognized(this, e);
		}

		protected virtual void OnGestureNotRecognized(RecognitionEventArgs e)
		{
			if (GestureNotRecognized != null) GestureNotRecognized(this, e);
		}

		protected virtual void OnGestureDeleted(GestureEventArgs e)
		{
			if (GestureDeleted != null) GestureDeleted(this, e);
		}

		#endregion

		#region Private Methods

		private void RecognizeGesture(PointF[] Points, PointF CapturePoint)
		{
			// Fire recognized event if we found a gesture match, otherwise throw not recognized event
			if (GestureName != null)
				OnGestureRecognized(new RecognitionEventArgs(GestureName, Points, CapturePoint));
			else
				OnGestureNotRecognized(new RecognitionEventArgs(Points, CapturePoint));
		}

		#endregion

		#region Public Methods

		public void Load()
		{
			// Shortcut method to control singleton instantiation
		}

		public void AddGesture(IGesture Gesture)
		{
			_Gestures.Add(Gesture);
		}

		public bool LoadGestures()
		{
			try
			{
				// Load gestures from file, create empty list if load failed
				_Gestures = Configuration.IO.FileManager.LoadObject<List<IGesture>>("Gestures.json", new Type[] { typeof(Gesture) });

				if (Gestures == null)
					return false;
				else
					return true;
			}
			catch
			{
				return false;
			}
		}

		public bool SaveGestures()
		{
			try
			{
				// Save gestures to file
				Configuration.IO.FileManager.SaveObject<List<IGesture>>(Gestures, "Gestures.json");

				return true;
			}
			catch
			{
				return false;
			}
		}

		public string GetGestureName(PointF[] Points)
		{
			// Get closest match, if no match, exit method
			return GetGestureSetNameMatch(Points);
		}

		public string GetGestureSetNameMatch(PointF[] Points)
		{
			// Update gesture analyzer with latest gestures and get gesture match from current points array
			// Comparison results are sorted descending from highest to lowest probability
			gestureAnalyzer.PointPatternSet = Gestures.ToArray();
			PointPatternMatchResult[] comparisonResults = gestureAnalyzer.GetPointPatternMatchResults(Points);

			// Exit if we didn't find a high probability match
			if (comparisonResults == null || comparisonResults.Where(ppmr => ppmr.Probability >= 75).Count() <= 0)
				return null;		// No close enough match. Do nothing with drawn gesture

			// Grab top result from gesture comparison
			return comparisonResults.First().Name;
		}

		public string[] GetAvailableGestures()
		{
			return Gestures.OrderBy(g => g.Name).GroupBy(g => g.Name).Select(g => g.Key).ToArray();
		}

		public bool GestureExists(string GestureName)
		{
			return _Gestures.Exists(g => g.Name.ToLower() == GestureName.Trim().ToLower());
		}

		public IGesture GetNewestGestureSample(string GestureName)
		{
			return Gestures.LastOrDefault(g => g.Name.ToLower() == GestureName.Trim().ToLower());
		}

		public void DeleteGesture(string GestureName)
		{
			_Gestures.RemoveAll(g => g.Name.ToLower().Trim() == GestureName.Trim().ToLower());
			SaveGestures();

			OnGestureDeleted(new GestureEventArgs(GestureName));
		}

		#endregion
	}
}
