using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HighSign.Common.Input;

namespace HighSign.Common.Input
{
	public class StateChangedEventArgs
	{
		#region Constructors

		public StateChangedEventArgs(CaptureState State)
		{
			this.State = State;
		}

		#endregion

		#region Public Properties

		public CaptureState State { get; set; }

		#endregion
	}
}
