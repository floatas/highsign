using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManagedWinapi.Hooks;

namespace HighSign.Common.Input
{
	public class MouseMessageEventArgs : MouseEventArgs
	{
		#region Constructors

		public MouseMessageEventArgs(MouseButtons button, int clicks, int x, int y, int delta, LowLevelMouseMessage Message) : base(button, clicks, x, y, delta)
		{
			this.MouseMessage = Message;
		}

		#endregion

		#region Public Instance Properties

		// Store original mouse message
		public LowLevelMouseMessage MouseMessage { get; set; }

		// Flag to consume mouse event
		public bool Handled { get; set; }

		#endregion
	}
}
