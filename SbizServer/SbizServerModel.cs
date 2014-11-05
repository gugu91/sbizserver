using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Sbiz.Library;
using WindowsInput;


namespace SbizServer
{
    static class SbizServerModel
    {
        //public static Thread background_thread;
        //private static SbizQueue<byte[]> _tcp_buffer_queue;
        //private static AutoResetEvent _model_sync_event;
        private static SbizServerListener _listener;
        private static InputSimulator _simulator = new InputSimulator();
        /*
        public static AutoResetEvent ModelSyncEvent
        {
            get
            {
                return _model_sync_event;
            }
        }
        
        public static SbizQueue<byte[]> TCPBufferQueue
        {
            get
            {
                return _tcp_buffer_queue;
            }
        }
        */
        public static void Init()
        {
            _listener = new SbizServerListener();
            _simulator = new InputSimulator();
            //background_thread = null;
            //_tcp_buffer_queue = new SbizQueue<byte[]>();
            //_model_sync_event = new AutoResetEvent(false);
        }

        public static void Start()
        {
            //if (background_thread == null)
            //{
            _listener = new SbizServerListener();
                _listener.Listen(SbizConf.SbizSocketPort);
                _listener.Start();
              //  background_thread = new Thread(() => Task());
              //  background_thread.Start();
           // }
        }

        public static void Stop()
        {
           // SbizServerModel.ModelSyncEvent.Set();
            //background_thread.Join();
            //background_thread = null;
            _listener.Stop();
        }
        /*
        private static void Task()
        {
            _listener.Start();
            while (SbizServerController.Listening)
            {
                ModelSyncEvent.WaitOne();
                
                byte[] buffer = null;
                if (SbizServerModel.TCPBufferQueue.Dequeue(ref buffer)) MessageHandle(new SbizMessage(buffer));
                
            }

            _listener.Stop();
        }*/

        public static void MessageHandle(SbizMessage m)
        {
            if (m.Code == SbizMessageConst.KEY_PRESS)
            {
                string tmp = Encoding.UTF8.GetString(m.Data, 0, m.Data.Length);
                System.Windows.Forms.SendKeys.SendWait(tmp);
            }

            if (m.Code == SbizMessageConst.MOUSE_MOVE)
            {
                SbizMouseEventArgs smea = new SbizMouseEventArgs(m.Data);
                SimulateMouseEvent(smea);
            }

            //Add other events...
        }

        public static void SimulateMouseEvent(SbizMouseEventArgs smea)
        {
            Cursor.Position = smea.Location;
            if (smea.Button == MouseButtons.Left)
            {
                for (int i = 0; i < smea.Clicks; i++) _simulator.Mouse.LeftButtonClick();
            }
            else if(smea.Button == MouseButtons.Middle)
            {
                for (int i = 0; i < smea.Clicks; i++) _simulator.Mouse.MiddleButtonClick();
            }
            else if(smea.Button == MouseButtons.Right)
            {
                for (int i = 0; i < smea.Clicks; i++) _simulator.Mouse.RightButtonClick();
            }

            _simulator.Mouse.VerticalScroll(smea.Delta);
        }
    }

}
