using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace HighSign.PointPatterns
{
	public interface IPointPattern
	{
		#region Interface Properties

		string Name { get; set; }
		PointF[] Points { get; set; }

		#endregion
	}
}
