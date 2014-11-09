using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sbiz.Library;

namespace SbizServer
{
    public partial class SbizServerPropertiesForm : Form, SbizForm
    {
        private Icon SbizServerIconGreen = new Icon("ico\\SbizServerIconGreen.ico");
        private Icon SbizServerIconRed = new Icon("ico\\SbizServerIconRed.ico");
        private Icon SbizServerIconYellow = new Icon("ico\\SbizServerIconYellow.ico");
        public SbizServerPropertiesForm()
        {
            InitializeComponent();
            SbizServerSetUDPPortNumericUpDown.Value = Properties.Settings.Default.UDPPort;
            SbizServerSetTCPPortNumericUpDown.Value = Properties.Settings.Default.TCPPort;
            SbizServerServerNameTextbox.Text = Properties.Settings.Default.ServerName;
            SbizServerController.Init();
            SbizServerController.RegisterView(this);
            SbizServerController.Start();
        }

        private void SbizServerForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                SbizServerNotifyIcon.Visible = true;
                SbizServerNotifyIcon.ShowBalloonTip(500, "SbizServer", "\nMinimized to tray icon,\ndouble click to open\nproperties window", ToolTipIcon.Info);
                Hide();
            }
        }

        private void SbizServerNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            SbizServerNotifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }



        public void UpdateViewOnModelChanged(object sender, SbizModelChanged_EventArgs args)
        {
            BeginInvoke(new SbizUpdateView_Delegate(UpdateView), new object[] {sender, args});
        }

        public void UpdateView(object sender, SbizModelChanged_EventArgs args)
        {
            if (sender is SbizServerListener)
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
                    SbizServerNotifyIcon.ShowBalloonTip(500, "SbizServer", "\nClient connected", ToolTipIcon.Info);
                    SbizServerNotifyIcon.Visible = true;
                    SbizServerNotifyIcon.Icon = SbizServerIconGreen;
                    this.Icon = SbizServerIconGreen;
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
                    SbizServerNotifyIcon.Visible = false;
                    SbizServerNotifyIcon.Icon = SbizServerIconRed;
                    this.Icon = SbizServerIconRed;
                    Show();
                }
            }
        }
        private void SbizServerApplySettingsButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TCPPort != Convert.ToInt32(SbizServerSetTCPPortNumericUpDown.Value)||
                Properties.Settings.Default.UDPPort != Convert.ToInt32(SbizServerSetUDPPortNumericUpDown.Value)||
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

        private void SbizServerFormClosing(object sender, FormClosingEventArgs e)
        {
            this.SbizServerCleanup();
        }

        private void SbizServerCleanup()
        {
            SbizServerController.Stop();
            SbizServerNotifyIcon.Visible = false;
            SbizServerNotifyIcon.Icon = null;
            SbizServerNotifyIcon.Dispose();
        }

        private void SbizServerPropertiesForm_Paint(object sender, PaintEventArgs e)
        {
            SbizMyIPLabel.Text = "Your IP Address is: " + SbizConf.MyIP;
        }
    }
}
