using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManagedWinapi.Windows;
using System.Text.RegularExpressions;

namespace HighSign.Common.Applications
{
	public abstract class ApplicationBase : IApplication
	{
		#region Private Instance Fields

		List<IAction> _Actions = new List<IAction>();

		#endregion

		#region IApplication Instance Properties

		public virtual string Name { get; set; }
		public virtual MatchUsing MatchUsing { get; set; }
		public virtual string MatchString { get; set; }
		public virtual bool IsRegEx { get; set; }
		public virtual IAction[] Actions
		{
			get { return _Actions.ToArray(); }
			set { _Actions = value.ToList(); }
		}

		#endregion

		#region IApplication Instance Methods

		public virtual void AddAction(IAction Action)
		{
			_Actions.Add(Action);
		}

		public virtual void RemoveAction(IAction Action)
		{
			_Actions.Remove(Action);
		}

		public virtual void RemoveAllActions(Predicate<IAction> Match)
		{
			_Actions.RemoveAll(Match);
		}

		public bool IsSystemWindowMatch(SystemWindow Window)
		{
			string compareMatchString = MatchString ?? String.Empty;
			string windowMatchString = String.Empty;

			switch (MatchUsing)
			{
				case MatchUsing.WindowClass:
					windowMatchString = Window.ClassName;

					break;
				case MatchUsing.WindowTitle:
					windowMatchString = Window.Title;

					break;
				case MatchUsing.ExecutableFilename:
					windowMatchString = Window.Process.MainModule.FileName;

					break;
				case MatchUsing.All:
					return true;
			}

			return IsRegEx ? Regex.IsMatch(windowMatchString, compareMatchString, RegexOptions.Singleline | RegexOptions.IgnoreCase) : windowMatchString.Trim().ToLower() == compareMatchString.Trim().ToLower();
		}

		#endregion
	}
}
