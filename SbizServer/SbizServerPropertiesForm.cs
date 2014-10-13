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
            object[] p = GetInvokerParameters(sender, args);

            BeginInvoke(new UpdateViewDelegate(UpdateView), p);
        }

        public void UpdateView(object sender, ModelChanged_EventArgs args)
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

        private object[] GetInvokerParameters(object sender, ModelChanged_EventArgs args)
        {
            // We have to create and object array as this is the only way our UpdateLabelText method can receive the parameters
            object[] delegateParameter = new object[2];

            delegateParameter[0] = sender;
            delegateParameter[1] = args;

            return delegateParameter;
        }

        private void SbizServerConnectionStatusLabel_Paint(object sender, PaintEventArgs e)
        {
            SbizServerController.Start();
        }
    }
}
