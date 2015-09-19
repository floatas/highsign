using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HighSign.Common.Plugins;

namespace HighSign.Common.Plugins
{
	public interface IPlugin
	{
		#region Properties

		string Name { get; }
		string Category { get; }
		string Description { get; }
		bool IsAction { get; }
		Form GUI { get; }

		#endregion

		#region Methods

		void Initialize();
		bool Gestured(PointInfo ActionPoint);
		void Deserialize(string SerializedData);
		string Serialize();

		#endregion

		#region Host Controls

		IHostControl HostControl { get; set; }

		#endregion
	}
}
