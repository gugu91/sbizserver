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
                Hide();
        }

        private void SbizServerNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }



        public void UpdateViewOnModelChanged(object sender, SbizModelChanged_EventArgs args)
        {
            BeginInvoke(new SbizUpdateView_Delegate(UpdateView), new object[] {sender, args});
        }

        public void UpdateView(object sender, SbizModelChanged_EventArgs args)
        {
            if (sender is SbizListenerSocket)
            {
                if (args.Status == SbizModelChanged_EventArgs.CONNECTED)
                {
                    SbizServerConnectionStatusLabel.Text = "Connesso";
                    SbizServerConnectionStatusLabel.ForeColor = Color.Green;
                    SbizServerStopConnectionButton.Enabled = true;
                    SbizServerSetPortButton.Enabled = false;
                    SbizServerSetPortNumericUpDown.Enabled = false;
                    SbizServerNotifyIcon.ShowBalloonTip(1000, "Client connected", " ", ToolTipIcon.Info);
                    Hide();
                }
                else
                {
                    SbizServerConnectionStatusLabel.Text = "Non Connesso";
                    SbizServerConnectionStatusLabel.ForeColor = Color.Red;
                    SbizServerStopConnectionButton.Enabled = false;
                    SbizServerSetPortButton.Enabled = true;
                    SbizServerSetPortNumericUpDown.Enabled = true;
                    Show();
                }
            }
        }

        private void SbizServerSetPortButton_Click(object sender, EventArgs e)
        {
            if (SbizConf.SbizSocketPort != Convert.ToInt32(SbizServerSetPortNumericUpDown.Value))
            {
                SbizConf.SbizSocketPort = Convert.ToInt32(SbizServerSetPortNumericUpDown.Value);
                SbizServerController.Stop();
                SbizServerController.Init();
                SbizServerController.Start();
            }
        }

        private void SbizServerSetPortNumericUpDown_Paint(object sender, PaintEventArgs e)
        {
            SbizServerSetPortNumericUpDown.Value = SbizConf.SbizSocketPort;
        }

        private void SbizServerStopConnectionButton_Click(object sender, EventArgs e)
        {
            //SbizServerController.Stop();
            this.SbizServerCleanup();
        }

        private void SbizServerFormClosing(object sender, FormClosingEventArgs e)
        {
            this.SbizServerCleanup();
        }

        private void SbizServerCleanup()
        {
            SbizServerController.Stop();
        }
    }
}
