using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighSign.Common.Gestures
{
	public class RecognitionEventArgs : EventArgs
	{
		#region Constructors

		public RecognitionEventArgs(PointF[] Points, PointF CapturePoint)
		{
			this.Points = Points;
			this.CapturePoint = CapturePoint;
		}

		public RecognitionEventArgs(string GestureName, PointF[] Points, PointF CapturePoint)
		{
			this.GestureName = GestureName;
			this.Points = Points;
			this.CapturePoint = CapturePoint;
		}

		#endregion

		#region Public Instance Properties

		public string GestureName { get; set; }
		public PointF[] Points { get; set; }
		public PointF CapturePoint { get; set; }

		#endregion
	}
}
