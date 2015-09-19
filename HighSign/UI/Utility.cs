using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace HighSign.UI
{
	public static class Utility
	{
		#region Type Methods

		public static Point GetCenteredFormLocation(Form Form)
		{
			Screen desktop = Screen.FromPoint(Cursor.Position);
			Point p = new Point();
			Rectangle screenRect = desktop.WorkingArea;
			p.X = Math.Max(screenRect.X, screenRect.X + (screenRect.Width - Form.Width) / 2);
			p.Y = Math.Max(screenRect.Y, screenRect.Y + (screenRect.Height - Form.Height) / 2);
			return p;
		}

		#endregion
	}
}
