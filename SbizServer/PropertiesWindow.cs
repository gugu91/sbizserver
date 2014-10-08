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
    public partial class PropertiesWindow : Form
    {

        private Thread keyboard_thread;

        public PropertiesWindow()
        {
            InitializeComponent();

            KeyboardListenerServer keyboard_listener = new KeyboardListenerServer();

            this.keyboard_thread = keyboard_listener.StartThread(15001, this.ConnectionStatusLabel);

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void PropertiesWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.keyboard_thread.Join();
        }
    }
}
