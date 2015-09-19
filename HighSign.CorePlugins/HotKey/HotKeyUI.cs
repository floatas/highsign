using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HighSign.Common.Plugins;

namespace HighSign.CorePlugins.HotKey
{
	public partial class HotKeyUI : Form
	{
		#region Private Variables

		HotKeySettings _Settings = null;
		IHostControl _HostControl = null;

		bool CtrlDown = false;
		bool AltDown = false;
		bool ShiftDown = false;
		bool WinDown = false;
		bool HotKeyCaptured = false;

		#endregion

		#region Constructors

		public HotKeyUI()
		{
			InitializeComponent();

			this.TopLevel = false;
			this.FormBorderStyle = FormBorderStyle.None;
			this.AutoScroll = true;
			this.Dock = DockStyle.Fill;

			this.txtKey.KeyDown += new KeyEventHandler(txtKey_KeyDown);
			this.txtKey.GotFocus += new EventHandler(txtKey_GotFocus);
			this.txtKey.LostFocus += new EventHandler(txtKey_LostFocus);
			this.LLKeyHook.KeyIntercepted += new ManagedWinapi.Hooks.LowLevelKeyboardHook.KeyCallback(LLKeyHook_KeyIntercepted);

			_Settings = new HotKeySettings();
		}

		public HotKeyUI(HotKeySettings KeySettings) : this()
		{
			Settings = KeySettings;
		}

		#endregion

		#region Events

		protected void LLKeyHook_KeyIntercepted(int msg, int vkCode, int scanCode, int flags, int time, IntPtr dwExtraInfo, ref bool handled)
		{
			handled = true;
			switch (msg)
			{
				case 256 :  // A key has been pressed down
				case 260 :  // ^

					if (!WinDown & !AltDown & !ShiftDown & !CtrlDown)
					{
						// If no modifiers are currently down, clear the text box and reset the HotKeyCaptured flag
						HotKeyCaptured = false;
						txtKey.Text = "";
					}

					switch (vkCode)
					{
						case 91 : // The key that's down is either LWin or RWin
						case 92 : // ^
							if (!WinDown & !HotKeyCaptured)
							{
								txtKey.Text = txtKey.Text.Length == 0 ? "Win + " : txtKey.Text += "Win + ";
								WinDown = true;
							}
							break;
						case 160 : // The key that's down is either LShift or RShift
						case 161 : // ^
							if (!ShiftDown & !HotKeyCaptured)
							{
								txtKey.Text = txtKey.Text.Length == 0 ? "Shift + " : txtKey.Text += "Shift + ";
								ShiftDown = true;
							}
							break;
						case 162 : // The key that's down is either LCtrl or RCtrl
						case 163 : // ^
							if (!CtrlDown & !HotKeyCaptured)
							{
								txtKey.Text = txtKey.Text.Length == 0 ? "Ctrl + " : txtKey.Text += "Ctrl + ";
								CtrlDown = true;
							}
							break;
						case 164 : // The key that's down is either LAlt or RAlt
						case 165 : // ^
							if (!AltDown & !HotKeyCaptured)
							{
								txtKey.Text = txtKey.Text.Length == 0 ? "Alt + " : txtKey.Text += "Alt + ";
								AltDown = true;
							}
							break;
						default : // A non-modifier key is currently down
							if (!HotKeyCaptured)
							{
								// Test if Ctrl+Alt+Delete is being pressed and inform the user to tap ctrl & alt to reset
								// I tried various ways to reset, but Windows incercepts and KeyUp hook message is never received
								if (CtrlDown & AltDown & !ShiftDown & !WinDown & (Keys)vkCode == Keys.Delete)
								{
									MessageBox.Show("Windows intercepts Ctrl + Alt + Delete immediately, you may need to tap your Ctrl and Alt keys once each to reset them.");
									CtrlDown = false;
									AltDown = false;
									break;
								}
								// Capture the hotkey combo for saving
								_Settings.Alt = AltDown;
								_Settings.Control = CtrlDown;
								_Settings.Shift = ShiftDown;
								_Settings.Windows = WinDown;
								_Settings.KeyCode = (Keys)vkCode;
								HotKeyCaptured = true;
								txtKey.Text += new ManagedWinapi.KeyboardKey((Keys)vkCode).KeyName;
							}
							break;
					}

					break;

				case 257 : // A key has been released
				case 261 : // ^
						switch (vkCode)
						{
							case 91: // The key that was released is LWin or RWin
							case 92: // ^
								if (WinDown)
								{
									if (!HotKeyCaptured) txtKey.Text = txtKey.Text.Replace("Win + ", "");
									WinDown = false;
								}
								break;
							case 160: // The key that was released is LShift or RShift 
							case 161: // ^
								if (ShiftDown)
								{
									if (!HotKeyCaptured) txtKey.Text = txtKey.Text.Replace("Shift + ", "");
									ShiftDown = false;
								}
								break;
							case 162: // The key that was released is LCtrl or RCtrl
							case 163: // ^
								if (CtrlDown)
								{
									if (!HotKeyCaptured) txtKey.Text = txtKey.Text.Replace("Ctrl + ", "");
									CtrlDown = false;
								}
								break;
							case 164: // The key that was released is LAlt or RAlt
							case 165: // ^
								if (AltDown)
								{
									if (!HotKeyCaptured) txtKey.Text = txtKey.Text.Replace("Alt + ", "");
									AltDown = false;
								}
								break;
						}
					break;
			}
		}

		protected void txtKey_GotFocus(object sender, EventArgs e)
		{
			//Hook keyboard when the user is in the Hotkey text box
			LLKeyHook.StartHook();
		}

		protected void txtKey_LostFocus(object sender, EventArgs e)
		{
			//Unhook keyboard when the leave the hotkey text box
			LLKeyHook.Unhook();
		}

		protected void txtKey_KeyDown(object sender, KeyEventArgs e)
		{
			//Instruct the control to ignore any keys pressed while in the hot key text box
			e.Handled = true;
			e.SuppressKeyPress = true;
		}

		#endregion

		#region Public Properties

		public HotKeySettings Settings
		{
			get
			{
				return _Settings;
			}
			set
			{
				_Settings = value;

				if (_Settings == null)
					_Settings = new HotKeySettings();

				string win = _Settings.Windows == true ? "Win + " : "";
				string alt = _Settings.Alt == true ? "Alt + " : "";
				string ctrl = _Settings.Control == true ? "Ctrl + " : "";
				string shift = _Settings.Shift == true ? "Shift + " : "";
				txtKey.Text = win + ctrl + shift + alt + (new ManagedWinapi.KeyboardKey(_Settings.KeyCode).KeyName);
			}
		}

		public IHostControl HostControl
		{
			get { return _HostControl; }
			set { _HostControl = value; }
		}

		#endregion
	}
}
