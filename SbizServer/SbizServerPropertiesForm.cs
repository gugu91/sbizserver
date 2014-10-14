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

namespace SbizServer
{
    public partial class SbizServerPropertiesForm : Form, SbizForm
    {
        private delegate void UpdateViewDelegate(object sender, ModelChanged_EventArgs args);

        public SbizServerPropertiesForm()
        {
            InitializeComponent();
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



        public void UpdateViewOnModelChanged(object sender, ModelChanged_EventArgs args)
        {
            BeginInvoke(new UpdateViewDelegate(UpdateView), new object[] {sender, args});
        }

        public void UpdateView(object sender, ModelChanged_EventArgs args)
        {
            if (sender is SbizServerSocket)
            {
                if (((SbizServerSocket)sender).Connected)
                {
                    SbizServerConnectionStatusLabel.Text = "Connesso";
                    SbizServerConnectionStatusLabel.ForeColor = Color.Green;
                    SbizServerStopConnectionButton.Enabled = true;
                    SbizServerSetPortButton.Enabled = false;
                    SbizServerSetPortNumericUpDown.Enabled = false;
                }
                else
                {
                    SbizServerConnectionStatusLabel.Text = "Non Connesso";
                    SbizServerConnectionStatusLabel.ForeColor = Color.Red;
                    SbizServerStopConnectionButton.Enabled = false;
                    SbizServerSetPortButton.Enabled = true;
                    SbizServerSetPortNumericUpDown.Enabled = true;
                }
            }
        }

        private void SbizServerSetPortButton_Click(object sender, EventArgs e)
        {
            if (SbizServerConf.SbizSocketPort != Convert.ToInt32(SbizServerSetPortNumericUpDown.Value))
            {
                SbizServerConf.SbizSocketPort = Convert.ToInt32(SbizServerSetPortNumericUpDown.Value);
                SbizServerController.Stop();
                SbizServerController.Init();
                SbizServerController.Start();
            }
        }

        private void SbizServerSetPortNumericUpDown_Paint(object sender, PaintEventArgs e)
        {
            SbizServerSetPortNumericUpDown.Value = SbizServerConf.SbizSocketPort;
        }

        private void SbizServerStopConnectionButton_Click(object sender, EventArgs e)
        {
            SbizServerController.Stop();
        }
    }
}
