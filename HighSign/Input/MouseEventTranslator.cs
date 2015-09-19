using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using ManagedWinapi.Hooks;
using HighSign.Common.Input;

namespace HighSign.Input
{
	public class MouseEventTranslator
	{
		#region Public Properties

		public MouseEvents MouseEvent { get; set; }
		public bool Handled { get; set; }

		#endregion

		#region Custom Events

		public event EventHandler<MouseMessageEventArgs> MouseDown;

		protected virtual void OnMouseDown(MouseMessageEventArgs args)
		{
			if (MouseDown != null) MouseDown(this, args);
		}

		public event EventHandler<MouseMessageEventArgs> MouseUp;

		protected virtual void OnMouseUp(MouseMessageEventArgs args)
		{
			if (MouseUp != null) MouseUp(this, args);
		}

		public event EventHandler<MouseMessageEventArgs> MouseMove;

		protected virtual void OnMouseMove(MouseMessageEventArgs args)
		{
			if (MouseMove != null) MouseMove(this, args);
		}

		#endregion

		#region Public Enumerations

		public enum MouseEvents
		{
			LeftButtonDown = 513,
			LeftButtonUp = 514,
			RightButtonDown = 516,
			RightButtonUp = 517,
			MiddleButtonDown = 520,
			MiddleButtonUp = 519,
			Move = 512
		}

		#endregion

		#region Public Methods

		public void TranslateMouseEvent(LowLevelMouseMessage Message)
		{
			// Store which mouse event occured
			MouseEvent = (MouseEvents)Message.Message;

			// Define new MouseMessageEventArgs to get handled state
			MouseMessageEventArgs args = null;

			switch (MouseEvent)
			{
				case MouseEvents.LeftButtonDown:
					args = new MouseMessageEventArgs(MouseButtons.Left, 1, Message.Point.X, Message.Point.Y, 0, Message);
					OnMouseDown(args);

					break;
				case MouseEvents.LeftButtonUp:
					args = new MouseMessageEventArgs(MouseButtons.Left, 1, Message.Point.X, Message.Point.Y, 0, Message);
					OnMouseUp(args);

					break;
				case MouseEvents.RightButtonDown:
					args = new MouseMessageEventArgs(MouseButtons.Right, 1, Message.Point.X, Message.Point.Y, 0, Message);
					OnMouseDown(args);

					break;
				case MouseEvents.RightButtonUp:
					args = new MouseMessageEventArgs(MouseButtons.Right, 1, Message.Point.X, Message.Point.Y, 0, Message);
					OnMouseUp(args);

					break;
				case MouseEvents.MiddleButtonDown:
					args = new MouseMessageEventArgs(MouseButtons.Middle, 1, Message.Point.X, Message.Point.Y, 0, Message);
					OnMouseDown(args);

					break;
				case MouseEvents.MiddleButtonUp:
					args = new MouseMessageEventArgs(MouseButtons.Middle, 1, Message.Point.X, Message.Point.Y, 0, Message);
					OnMouseUp(args);

					break;
				case MouseEvents.Move:
					args = new MouseMessageEventArgs(MouseButtons.None, 0, Message.Point.X, Message.Point.Y, 0, Message);
					OnMouseMove(args);

					break;
				default:
					args = new MouseMessageEventArgs(MouseButtons.None, 0, 0, 0, 0, Message);	// Catch additional buttons

					break;
			}

			// Set handled property of class to MouseMessageEventArgs handled flag to notify the main mouse intercept that one of the events handled it
			this.Handled = args.Handled;
		}

		#endregion
	}
}
