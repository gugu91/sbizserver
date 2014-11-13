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
            SbizServerController.RegisterView(this);
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
                    Hide();
                }
                else
                {
                    SbizServerConnectionStatusLabel.Text = "Not Connected";
                    SbizServerConnectionStatusLabel.ForeColor = Color.Red;
                    SbizServerStopConnectionButton.Enabled = false;
                    SbizServerApplySettingsButton.Enabled = true;
                    SbizServerSetTCPPortNumericUpDown.Enabled = true;
                    SbizServerSetUDPPortNumericUpDown.Enabled = true;
                    SbizServerServerNameTextbox.Enabled = true;
                    Show();
                }
            }
        }
        private void SbizServerApplySettingsButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TCPPort != Convert.ToInt32(SbizServerSetTCPPortNumericUpDown.Value) ||
                Properties.Settings.Default.UDPPort != Convert.ToInt32(SbizServerSetUDPPortNumericUpDown.Value) ||
                Properties.Settings.Default.ServerName != SbizServerServerNameTextbox.Text)
            {
                SbizServerController.Stop();
                Properties.Settings.Default.TCPPort = Convert.ToInt32(SbizServerSetTCPPortNumericUpDown.Value);
                Properties.Settings.Default.UDPPort = Convert.ToInt32(SbizServerSetUDPPortNumericUpDown.Value);
                Properties.Settings.Default.ServerName = SbizServerServerNameTextbox.Text;
                Properties.Settings.Default.Save();
                SbizServerController.Start();
            }
        }
        private void SbizServerStopConnectionButton_Click(object sender, EventArgs e)
        {
            SbizServerController.Stop();
            SbizServerController.Start();
        }
    }
}
