using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SbizServer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            KeyboardListenerServer keyboard_listener = new KeyboardListenerServer();

            Thread keyboard_thread = keyboard_listener.StartThread(15001);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PropertiesWindow());

            keyboard_thread.Join();
        }
    }
}
