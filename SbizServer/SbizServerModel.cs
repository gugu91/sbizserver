using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Collections.Concurrent;
using Sbiz.Library;
using System.Net;
using System.Net.Sockets;
using Sbiz.Library;

namespace SbizServer
{
    static class SbizServerModel
    {
        public static Thread background_thread;
        private static Int32 _stop;
        private static SbizQueue<byte[]> _tcp_buffer_queue;
        private static AutoResetEvent _model_sync_event;
        private static SbizServerListener _listener;

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

        public static void Init()
        {
            _listener = new SbizServerListener();
            background_thread = null;
            Interlocked.Exchange(ref _stop, 0);
            _tcp_buffer_queue = new SbizQueue<byte[]>();
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
            _listener.Stop();
            background_thread.Join();
        }

        private static void Task()
        {
            while (SbizServerController.Listening)
            {
                _listener.Start();
                ModelSyncEvent.WaitOne();

                byte[] buffer = null;
                if (SbizServerModel.TCPBufferQueue.Dequeue(ref buffer)) MessageHandle(new SbizMessage(buffer));
            }
        }


        public static void MessageHandle(SbizMessage m)
        {
            if (m.Code == SbizMessageConst.KEY_PRESS)
            {
                string tmp = Encoding.UTF8.GetString(m.Data, 0, m.Data.Length);
                System.Windows.Forms.SendKeys.SendWait(tmp);
            }

            //Add other events...
        }
    }

}
