using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HighSign.Common.Applications;

namespace HighSign.Common.UI.Controls
{
	public class ApplicationListViewItem : ListViewItem
	{
		#region Public Properties

		// Add additional properties to the store window title, class, and filename
		public string WindowTitle { get; set; }
		public string WindowClass { get; set; }
		public string WindowFilename { get; set; }
		public string ApplicationName { get; set; }

		#endregion

		#region Public Instance Methods

		public IApplication ToUserApplication(MatchUsing MatchUsing)
		{
			UserApplication userApplication = new UserApplication();

			userApplication.Name = ApplicationName;
			userApplication.MatchUsing = MatchUsing;

			switch (MatchUsing)
			{
				case MatchUsing.WindowClass:
					userApplication.MatchString = WindowClass;
					break;
				case MatchUsing.WindowTitle:
					userApplication.MatchString = WindowTitle;
					break;
				case MatchUsing.ExecutableFilename:
					userApplication.MatchString = WindowFilename;
					break;
			}

			userApplication.IsRegEx = false;

			return userApplication;
		}

		#endregion
	}
}
