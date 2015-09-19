using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighSign.Common.Gestures
{
	public class GestureEventArgs : EventArgs
	{
		#region Public Instance Properties

		public string GestureName { get; set; }

		#endregion

		#region Constructors

		public GestureEventArgs(string GestureName)
		{
			this.GestureName = GestureName;
		}

		#endregion
	}
}
