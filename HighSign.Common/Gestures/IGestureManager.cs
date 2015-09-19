using System;

namespace HighSign.Common.Gestures
{
	public interface IGestureManager
	{
		void DeleteGesture(string GestureName);
		event GestureEventHandler GestureDeleted;
		bool GestureExists(string GestureName);
		string GestureName { get; set; }
		event RecognitionEventHandler GestureNotRecognized;
		event RecognitionEventHandler GestureRecognized;
		IGesture[] Gestures { get; }
		string[] GetAvailableGestures();
		string GetGestureName(System.Drawing.PointF[] Points);
		string GetGestureSetNameMatch(System.Drawing.PointF[] Points);
		IGesture GetNewestGestureSample(string GestureName);
		void AddGesture(IGesture Gesture);
		bool LoadGestures();
		bool SaveGestures();
	}
}
