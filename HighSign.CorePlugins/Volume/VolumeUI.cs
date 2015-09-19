using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HighSign.Common.Plugins;

namespace HighSign.CorePlugins.Volume
{
    public partial class VolumeUI : Form
    {
        #region Private Variables

        VolumeSettings _Settings = null;
        //Keys _KeyCode;
        IHostControl _HostControl = null;

        #endregion

        #region Constructors

        public VolumeUI()
        {
            InitializeComponent();

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.AutoScroll = true;
            this.Dock = DockStyle.Fill;

            //this.txtKey.KeyDown += new KeyEventHandler(txtKey_KeyDown);
            //this.txtKey.GotFocus += new EventHandler(txtKey_GotFocus);
            //this.txtKey.LostFocus += new EventHandler(txtKey_LostFocus);
        }

        public VolumeUI(VolumeSettings KeySettings)
            : this()
        {
            Settings = KeySettings;
        }

        #endregion

        #region Events


        #endregion

        #region Public Properties

        public VolumeSettings Settings
        {
            get
            {
                _Settings = new VolumeSettings();
                _Settings.Method = cboMethod.SelectedIndex;
                //Using simple calculation based off selected index instead of building
                //a wrapper or arrayList just to make it more readable
                _Settings.Percent = ((cboPercent.SelectedIndex+1)*10); 

                return _Settings;
            }
            set
            {
                _Settings = value;

                if (_Settings == null)
                    _Settings = new VolumeSettings();

                cboMethod.SelectedIndex = _Settings.Method;
                //Using simple calculation based off selected index instead of building
                //a wrapper or arrayList just to make it more readable
                if(_Settings.Percent != 0)  //If no setting exists, don't try to derive selected index (results in -1, nothing selected)
                    cboPercent.SelectedIndex = ((_Settings.Percent/10)-1);
            }
        }

        public IHostControl HostControl
        {
            get { return _HostControl; }
            set { _HostControl = value; }
        }

        #endregion

        private void cboMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex == 2)
            {   //2 = Toggle mute, set cboPercent to nothing selected and disable it
                cboPercent.SelectedIndex = -1;
                cboPercent.Enabled = false;
            }
            else
            {   //If volume adjustment, set cboPercent to show first item (10%) if nothing is selected
                // and enable percent dropdown
                if(cboPercent.SelectedIndex == -1)
                    cboPercent.SelectedIndex = 0;
                cboPercent.Enabled = true;
            }
        }

        private void cboPercent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
