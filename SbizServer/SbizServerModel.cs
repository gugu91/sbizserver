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

namespace SbizServer
{
    static class SbizServerModel
    {
        public static Thread background_thread;
        //private static SbizQueue<byte[]> _tcp_buffer_queue;
        private static AutoResetEvent _model_sync_event;
        private static SbizServerListener _listener;

        public static AutoResetEvent ModelSyncEvent
        {
            get
            {
                return _model_sync_event;
            }
        }
        /*
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
            background_thread = null;
            //_tcp_buffer_queue = new SbizQueue<byte[]>();
            _model_sync_event = new AutoResetEvent(false);
        }

        public static void Start()
        {
            if (background_thread == null)
            {
                _listener.Listen(SbizConf.SbizSocketPort);//called here beacause SbizConf is not thread safe
                background_thread = new Thread(() => Task());
                background_thread.Start();
            }
        }

        public static void Stop()
        {
            SbizServerModel.ModelSyncEvent.Set();
            background_thread.Join();
            background_thread = null;
        }

        private static void Task()
        {
            _listener.Start();
            while (SbizServerController.Listening)
            {
                ModelSyncEvent.WaitOne();
                /*
                byte[] buffer = null;
                if (SbizServerModel.TCPBufferQueue.Dequeue(ref buffer)) MessageHandle(new SbizMessage(buffer));
                 * */
            }

            _listener.Stop();
        }


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
                Cursor.Position = smea.Location;
            }

            //Add other events...
        }
    }

}
