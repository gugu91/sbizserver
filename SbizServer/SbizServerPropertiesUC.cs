using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sbiz.Library;

namespace SbizServer
{
    public partial class SbizServerPropertiesUC : UserControl, SbizForm
    {
        public SbizServerPropertiesUC()
        {
            InitializeComponent();
            SbizServerSetUDPPortNumericUpDown.Value = Properties.Settings.Default.UDPPort;
            SbizServerSetTCPPortNumericUpDown.Value = Properties.Settings.Default.TCPPort;
            SbizServerServerNameTextbox.Text = Properties.Settings.Default.ServerName;
            SbizServerPasswordBox.Text = Properties.Settings.Default.Password;
            SbizServerController.RegisterView(this);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            SbizServerController.WndProcOverride(m, this.Handle);
        }

        public void UpdateViewOnModelChanged(object sender, SbizModelChanged_EventArgs args)
        {
            BeginInvoke(new SbizUpdateView_Delegate(UpdateView), new object[] { sender, args });
        }
        public void UpdateView(object sender, SbizModelChanged_EventArgs args)
        {
            if (sender is SbizMessager)
            {
                if (args.Status == SbizModelChanged_EventArgs.CONNECTED)
                {
                    SbizServerConnectionStatusLabel.Text = "Connected";
                    SbizServerConnectionStatusLabel.ForeColor = Color.Green;
                    SbizServerStopConnectionButton.Enabled = true;
                    SbizServerApplySettingsButton.Enabled = false;
                    SbizServerSetTCPPortNumericUpDown.Enabled = false;
                    SbizServerSetUDPPortNumericUpDown.Enabled = false;
                    SbizServerServerNameTextbox.Enabled = false;
                }
                else if (args.Status <= 0) //ERRORS or NOT_CONNECTED
                {
                    SbizServerConnectionStatusLabel.Text = "Not Connected";
                    SbizServerConnectionStatusLabel.ForeColor = Color.Red;
                    SbizServerStopConnectionButton.Enabled = false;
                    SbizServerApplySettingsButton.Enabled = true;
                    SbizServerSetTCPPortNumericUpDown.Enabled = true;
                    SbizServerSetUDPPortNumericUpDown.Enabled = true;
                    SbizServerServerNameTextbox.Enabled = true;
                }
            }
        }
        private void SbizServerApplySettingsButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TCPPort != Convert.ToInt32(SbizServerSetTCPPortNumericUpDown.Value) ||
                Properties.Settings.Default.UDPPort != Convert.ToInt32(SbizServerSetUDPPortNumericUpDown.Value) ||
                Properties.Settings.Default.ServerName != SbizServerServerNameTextbox.Text||
                Properties.Settings.Default.Password != SbizServerPasswordBox.Text)
            {
                SbizServerController.Stop(this.Handle);
                Properties.Settings.Default.TCPPort = Convert.ToInt32(SbizServerSetTCPPortNumericUpDown.Value);
                Properties.Settings.Default.UDPPort = Convert.ToInt32(SbizServerSetUDPPortNumericUpDown.Value);
                Properties.Settings.Default.ServerName = SbizServerServerNameTextbox.Text;
                Properties.Settings.Default.Password = SbizServerPasswordBox.Text;
                Properties.Settings.Default.Save();
                SbizServerController.Start(this.Handle);
            }
        }
        private void SbizServerStopConnectionButton_Click(object sender, EventArgs e)
        {
            SbizServerController.Stop(this.Handle);
            SbizServerController.Start(this.Handle);
        }

        private void SbizServerPropertiesUC_Paint(object sender, PaintEventArgs e)
        {
            SbizMyIPLabel.Text = "Your IP Address is: " + SbizConf.MyIP;
        }
    }
}
