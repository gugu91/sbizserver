﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace SbizServer
{
    static class SbizServerModel
    {
        public static SbizServerSocket sbiz_socket;
        public static Thread background_thread;
        private static Int32 _stop;

        public static void Init(){
            sbiz_socket = new SbizServerSocket(SbizServerConf.SbizSocketPort);
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
            ModelChanged_EventArgs args = new ModelChanged_EventArgs();
            SbizServerController.OnModelChanged(sbiz_socket, args);

            while (_stop == 0)
            {
                sbiz_socket.ReceiveData();
            }

            sbiz_socket.ShutdownConnection();
            Interlocked.Exchange(ref _stop, 0);
        }

        public static void Stop()
        {
            Interlocked.Exchange(ref _stop, 1);
            background_thread.Join();
        }
    }
}
