using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SbizServer
{
    public class ModelChanged_EventArgs : EventArgs
    {
        private int _status;
        public ModelChanged_EventArgs()
        {
        }
    }
    static class SbizServerModel
    {
        public static SbizServerSocket sbiz_socket;
        public static Thread background_thread;
        private static Int32 _stop;

        public delegate void ModelChanged_EventHandler(object sender, ModelChanged_EventArgs args);
        public static event ModelChanged_EventHandler ModelChanged;
        public static virtual void OnModelChanged(object sender, ModelChanged_EventArgs args)
        {
            if (ModelChanged != null)
            {
                ModelChanged(sender, args); //raise the event
            }
        }

        public static void Init(){
            sbiz_socket = new SbizServerSocket();
            background_thread = null;
            Interlocked.Exchange(ref _stop, 0);
        }

        public static void Start()
        {
            if (background_thread == null)
            {
                background_thread = new Thread(() => Task());
                background_thread.Start();
            }
        }

        private static void Task()
        {
            sbiz_socket.AcceptConnection();

            while (_stop == 0)
            {
                sbiz_socket.ReceiveData();
            }

            sbiz_socket.ShutdownConnection();
            Interlocked.Exchange(ref _stop, 0);
        }

        public void Stop()
        {
            Interlocked.Exchange(ref _stop, 1);
            background_thread.Join();
        }
    }
}
