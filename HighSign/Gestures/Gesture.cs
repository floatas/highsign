using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using HighSign.PointPatterns;
using HighSign.Common.Gestures;
using System.Runtime.Serialization;

namespace HighSign.Gestures
{
	[DataContract]
	[KnownType(typeof(Gesture))]
	public class Gesture : IGesture
	{
		#region Constructors

		public Gesture(string Name, PointF[] Points)
		{
			this.Name = Name;
			this.Points = Points;
		}

		#endregion

		#region IPointPattern Instance Properties

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public PointF[] Points { get; set; }

		#endregion
	}
}
