using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HighSign.Common.Applications
{
	public class IgnoredApplication : ApplicationBase
	{
		#region Contructors

		protected IgnoredApplication()
		{

		}

		public IgnoredApplication(string Name, MatchUsing MatchUsing, string MatchString, bool IsRegEx)
		{
			this.Name = Name;
			this.MatchUsing = MatchUsing;
			this.MatchString = MatchString;
			this.IsRegEx = IsRegEx;
		}

		#endregion

		#region IApplication Properties

		public override IAction[] Actions
		{
			get { return null; }
			set { /* Only exists for serialization purposes */ }
		}

		#endregion

		#region IApplication Methods

		public override void AddAction(IAction Action)
		{
			throw new NotSupportedException();
		}

		public override void RemoveAction(IAction Action)
		{
			throw new NotSupportedException();
		}

		public override void RemoveAllActions(Predicate<IAction> Match)
		{
			throw new NotSupportedException();
		}

		#endregion	
	}
}
