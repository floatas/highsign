using System;
using ManagedWinapi.Windows;
using System.Drawing;

namespace HighSign.Common.Applications
{
	public interface IApplication
	{
		string Name { get; set; }
		IAction[] Actions { get; set; }
		MatchUsing MatchUsing { get; set; }
		string MatchString { get; set; }
		bool IsRegEx { get; set; }

		void AddAction(IAction Action);
		void RemoveAction(IAction Action);
		void RemoveAllActions(Predicate<IAction> Match);
		bool IsSystemWindowMatch(SystemWindow Window);
	}
}
