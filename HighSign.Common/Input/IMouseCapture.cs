using System;

namespace HighSign.Common.Input
{
	public interface IMouseCapture
	{
		event PointsCapturedEventHandler AfterPointsCaptured;
		event PointsCapturedEventHandler BeforePointsCaptured;
		event PointsCapturedEventHandler CaptureEnded;
		System.Drawing.PointF CapturePoint { get; }
		void DestroyMouseHook();
		void DisableMouseCapture();
		void EnableMouseCapture();
		System.Drawing.PointF[] InputPoints { get; }
		event PointsCapturedEventHandler PointCaptured;
	}
}
