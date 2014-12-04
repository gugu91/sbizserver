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
            SbizServerController.Init();
            SbizServerController.RegisterView(this);
            SbizServerController.Start(this.sbizServerPropertiesUC1.Handle);
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
            if (sender is SbizMessager)
            {
                if (args.Status == SbizModelChanged_EventArgs.CONNECTED)
                {
                    SbizServerNotifyIcon.ShowBalloonTip(500, "SbizServer", "Client connected", ToolTipIcon.Info);
                    this.Icon = SbizServerIconGreen;
                    SbizServerNotifyIcon.Visible = true;
                    SbizServerNotifyIcon.Icon = SbizServerIconGreen;
                    Hide();
                }
                else if (args.Status == SbizModelChanged_EventArgs.TARGET)
                {
                    this.Icon = SbizServerIconGreen;
                    SbizServerNotifyIcon.Icon = SbizServerIconGreen;
                }
                else if (args.Status == SbizModelChanged_EventArgs.NOT_TARGET)
                {
                    this.Icon = SbizServerIconYellow;
                    SbizServerNotifyIcon.Icon = SbizServerIconYellow;
                }
                else if (args.Status <= 0) //ERRORS or NOT_CONNECTED
                {
                    SbizServerNotifyIcon.Icon = SbizServerIconRed;
                    this.Icon = SbizServerIconRed;
                    SbizServerNotifyIcon.Visible = false;
                    Show();
                }
            }
        }

        private void SbizServerFormClosing(object sender, FormClosingEventArgs e)
        {
            this.SbizServerCleanup();
        }

        private void SbizServerCleanup()
        {
            SbizServerController.Stop(this.sbizServerPropertiesUC1.Handle);
            SbizServerNotifyIcon.Visible = false;
            SbizServerNotifyIcon.Icon = null;
            SbizServerNotifyIcon.Dispose();
        }
    }
}
