using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace HighSign.Common.Input
{
	public class PointsCapturedEventArgs : EventArgs
	{
		#region Constructors

		public PointsCapturedEventArgs(PointF[] Points)
		{
			this.Points = Points;
			this.CapturePoint = Points.FirstOrDefault();
		}

		public PointsCapturedEventArgs(PointF[] Points, PointF CapturePoint) : this(Points)
		{
			this.CapturePoint = CapturePoint;
		}

		public PointsCapturedEventArgs(PointF[] Points, CaptureState State) : this(Points)
		{
			this.State = State;
		}

		public PointsCapturedEventArgs(PointF[] Points, PointF CapturePoint, CaptureState State) : this(Points, CapturePoint)
		{
			this.State = State;
		}

		#endregion

		#region Public Properties

		public PointF[] Points { get; set; }
		public PointF CapturePoint { get; set; }
		public bool Cancel { get; set; }
		public CaptureState State { get; set; }

		#endregion
	}
}
