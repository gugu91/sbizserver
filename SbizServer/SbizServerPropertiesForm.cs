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
        public SbizServerPropertiesForm()
        {
            InitializeComponent();
            SbizMyIPLabel.Text = "Your IP Address is: " + SbizConf.MyIP;
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
                    SbizServerSetPortButton.Enabled = false;
                    SbizServerSetPortNumericUpDown.Enabled = false;
                    SbizServerNotifyIcon.ShowBalloonTip(500, "SbizServer", "\nClient connected", ToolTipIcon.Info);
                    SbizServerNotifyIcon.Visible = true;
                    Hide();
                }
                else
                {
                    SbizServerConnectionStatusLabel.Text = "Not Connected";
                    SbizServerConnectionStatusLabel.ForeColor = Color.Red;
                    SbizServerStopConnectionButton.Enabled = false;
                    SbizServerSetPortButton.Enabled = true;
                    SbizServerSetPortNumericUpDown.Enabled = true;
                    SbizServerNotifyIcon.Visible = false;
                    Show();
                }
            }
        }

        private void SbizServerSetPortButton_Click(object sender, EventArgs e)
        {
            if (SbizConf.SbizSocketPort != Convert.ToInt32(SbizServerSetPortNumericUpDown.Value))
            {
                SbizConf.SbizSocketPort = Convert.ToInt32(SbizServerSetPortNumericUpDown.Value);
                SbizServerController.ModelRestart();
            }
        }

        private void SbizServerSetPortNumericUpDown_Paint(object sender, PaintEventArgs e)
        {
            SbizServerSetPortNumericUpDown.Value = SbizConf.SbizSocketPort;
        }

        private void SbizServerStopConnectionButton_Click(object sender, EventArgs e)
        {
            SbizServerController.ModelRestart();
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
    }
}
