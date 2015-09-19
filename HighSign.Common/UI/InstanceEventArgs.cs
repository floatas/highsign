using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HighSign.Common.UI
{
	public class InstanceEventArgs : EventArgs
	{
		#region Public Instance Properties

		public Form Instance { get; set; }

		#endregion

		#region Constructors

		public InstanceEventArgs(Form Instance)
		{
			this.Instance = Instance;
		}

		#endregion
	}
}
