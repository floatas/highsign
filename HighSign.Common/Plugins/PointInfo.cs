using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace HighSign.Common.Plugins
{
	public class PointInfo
	{
		#region Private Variables

		private Point _MouseLocation;
		private IntPtr _WindowHandle;
		private ManagedWinapi.Windows.SystemWindow _Window;

		#endregion

		#region Constructors

		public PointInfo(PointF MouseLocation)
		{
			_MouseLocation = Point.Round(MouseLocation);
			_Window = ManagedWinapi.Windows.SystemWindow.FromPointEx(_MouseLocation.X, _MouseLocation.Y, true, false);
			_WindowHandle = _Window.HWnd;
		}

		#endregion

		#region Public Properties

		public Point MouseLocation
		{
			get { return _MouseLocation; }
			set
			{
				_MouseLocation = value;
				_Window = ManagedWinapi.Windows.SystemWindow.FromPointEx(value.X, value.Y, true, false);
				_WindowHandle = _Window.HWnd;
			}
		}

		public IntPtr WindowHandle
		{
			get { return _WindowHandle; }
		}

		public ManagedWinapi.Windows.SystemWindow Window
		{
			get { return _Window; }
		}

		#endregion
	}
}