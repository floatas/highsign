using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HighSign.Common;
using HighSign.Common.UI;

namespace HighSign.UI
{
	public class FormManager : ILoadable, IFormManager
	{
		#region Private Variables

		static Dictionary<Type, Form> _AvailableForms = new Dictionary<Type, Form>();

		// Create variable to hold the only allowed instance of this class
		static readonly FormManager _Instance = new FormManager();

		#endregion

		#region Constructors

		protected FormManager()
		{
			
		}

		#endregion

		#region Public Properties

		public static FormManager Instance
		{
			get { return _Instance; }
		}

		#endregion

		#region Custom Events

		// Create event to notify subscribers that an instance was requested
		public event InstanceEventHandler InstanceRequested;

		protected virtual void OnInstanceRequested(InstanceEventArgs e)
		{
			if (InstanceRequested != null) InstanceRequested(this, e);
		}

		#endregion

		#region Strongly Typed Form Variables

		public Forms.ActionDefinition ActionDefinition
		{
			get { return GetInstance<Forms.ActionDefinition>(); }
		}

		public Forms.ApplicationDefinition ApplicationDefinition
		{
			get { return GetInstance<Forms.ApplicationDefinition>(); }
		}

		public Forms.AvailableActions AvailableActions
		{
			get { return GetInstance<Forms.AvailableActions>(); }
		}

		public Forms.GestureDefinition GestureDefinition
		{
			get { return GetInstance<Forms.GestureDefinition>(); }
		}

		public Forms.Options Options
		{
			get { return GetInstance<Forms.Options>(); }
		}

		public Forms.Surface Surface
		{
			get { return GetInstance<Forms.Surface>(); }
		}

		public Forms.AvailableGestures AvailableGestures
		{
			get { return GetInstance<Forms.AvailableGestures>(); }
		}

		public Forms.IgnoredApplications IgnoredApplications
		{
			get { return GetInstance<Forms.IgnoredApplications>(); }
		}

		#endregion

		#region Private Methods

		private T GetInstance<T>() where T : Form, new()
		{
			if (!_AvailableForms.ContainsKey(typeof(T)))
			{
				T newInstance = new T();
				newInstance.FormClosed += new FormClosedEventHandler(
					delegate(object sender, FormClosedEventArgs e)
					{
						_AvailableForms.Remove(sender.GetType());
					});

				_AvailableForms.Add(typeof(T), newInstance);

				// Fire instance requested event
				OnInstanceRequested(new InstanceEventArgs(newInstance));
			}

			return (T)_AvailableForms[typeof(T)];
		}

		private void SetInstance<T>(T formInstance) where T : Form, new()
		{
			if (!_AvailableForms.Contains(new KeyValuePair<Type, Form>(typeof(T), formInstance)))
			{
				formInstance.FormClosed += new FormClosedEventHandler(
					delegate(object sender, FormClosedEventArgs e)
					{
						_AvailableForms.Remove(sender.GetType());
					});

				_AvailableForms.Add(typeof(T), formInstance);
			}
		}

		#endregion

		#region Public Methods

		public void Load()
		{
			// Preinstantiate surface and gesture definition form
			SetInstance<Forms.Surface>(new Forms.Surface());
			SetInstance<Forms.GestureDefinition>(new Forms.GestureDefinition());
		}

		#endregion

		#region IFormManager Form Instances

		// We have to use the Form base class to represent our
		// form instances because of inteface limitations

		Form IFormManager.ActionDefinition
		{
			get { throw new NotImplementedException(); }
		}

		Form IFormManager.ApplicationDefinition
		{
			get { throw new NotImplementedException(); }
		}

		Form IFormManager.AvailableActions
		{
			get { throw new NotImplementedException(); }
		}

		Form IFormManager.AvailableGestures
		{
			get { throw new NotImplementedException(); }
		}

		Form IFormManager.GestureDefinition
		{
			get { throw new NotImplementedException(); }
		}

		Form IFormManager.Options
		{
			get { throw new NotImplementedException(); }
		}

		Form IFormManager.Surface
		{
			get { throw new NotImplementedException(); }
		}

		Form IFormManager.IgnoredApplications
		{
			get { throw new NotImplementedException(); }
		}

		#endregion
	}
}
