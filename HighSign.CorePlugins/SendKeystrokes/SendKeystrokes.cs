using System;
using System.Windows.Forms;
using HighSign.Common.Plugins;

namespace HighSign.CorePlugins.SendKeystrokes
{
	public class SendKeystrokes : IPlugin
	{
		#region IPlugin Instance Fields

		private SendKeystrokesUI _GUI = null;

		#endregion

		#region IPlugin Instance Properties

		public string Name
		{
			get { return "Send Keystrokes"; }
		}

		public string Category
		{
			get { return "Keyboard"; }
		}

		public string Description
		{
			get { return "Send keystrokes to application"; }
		}

		public bool IsAction
		{
			get { return true; }
		}

		public Form GUI
		{
			get
			{
				if (_GUI == null || _GUI.IsDisposed)
					_GUI = CreateGUI();

				return _GUI;
			}
		}

		public SendKeystrokesUI TypedGUI
		{
			get { return (SendKeystrokesUI)GUI; }
		}

		public IHostControl HostControl { get; set; }

		#endregion

		#region IPlugin Instance Methods

		public void Initialize()
		{
			
		}

		public bool Gestured(PointInfo ActionPoint)
		{
			try
			{
				if (ActionPoint.WindowHandle.ToInt64() != ManagedWinapi.Windows.SystemWindow.ForegroundWindow.HWnd.ToInt64())
					ManagedWinapi.Windows.SystemWindow.ForegroundWindow = ActionPoint.Window;

				SendKeys.Send(TypedGUI.txtSendKeys.Text);

				return true;
			}
			catch
			{
				return false;
			}
		}

		public void Deserialize(string SerializedData)
		{
			TypedGUI.txtSendKeys.Text = SerializedData;
		}

		public string Serialize()
		{
			return TypedGUI.txtSendKeys.Text;
		}

		#endregion

		#region Private Instance Methods

		private SendKeystrokesUI CreateGUI()
		{
			return new SendKeystrokesUI();
		}

		#endregion
	}
}
