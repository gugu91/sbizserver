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
            if (sender is SbizServerSocket)
            {
                if (((SbizServerSocket)sender).Connected)
                {
                    SbizServerConnectionStatusLabel.Text = "Connesso";
                    SbizServerConnectionStatusLabel.ForeColor = Color.Green;
                }
                else
                {
                    SbizServerConnectionStatusLabel.Text = "Non Connesso";
                    SbizServerConnectionStatusLabel.ForeColor = Color.Red;
                }
            }
        }
    }
}
