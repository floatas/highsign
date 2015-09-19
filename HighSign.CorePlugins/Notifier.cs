using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HighSign.Common.Plugins;

namespace HighSign.CorePlugins
{
	public class Notifier : IPlugin
	{
		#region IPlugin Members

		public string Name
		{
			get { return "Notifier"; }
		}

		public string Description
		{
			get { return "Notifies user of performed actions"; }
		}

		public Form GUI
		{
			get { return null; }
		}

		public string Category
		{
			get { return "Common"; }
		}

		public bool IsAction
		{
			get { return false; }
		}

		public void Initialize()
		{
			HostControl.GestureManager.GestureRecognized += (o, e) =>
				{
					//MessageBox.Show(String.Format("You drew a '{0}'", e.GestureName));
				};
		}

		public bool Gestured(PointInfo ActionPoint)
		{
			return true;
		}

		public void Deserialize(string SerializedData)
		{
			
		}

		public string Serialize()
		{
			return String.Empty;
		}

		public IHostControl HostControl { get; set; }

		#endregion
	}
}
