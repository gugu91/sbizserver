using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Collections.Concurrent;
using Sbiz.Library;

namespace SbizServer
{
    static class SbizServerModel
    {
        public static SbizServerSocket sbiz_socket;
        public static Thread background_thread;
        private static Int32 _stop;
        

        public static void Init(){
            sbiz_socket = new SbizServerSocket();
            background_thread = null;
            Interlocked.Exchange(ref _stop, 0);
        }

        public static void Start()
        {
            if (background_thread == null)
            {
                sbiz_socket.SbizServerListenOnPort(SbizConf.SbizSocketPort);
                background_thread = new Thread(() => Task());
                background_thread.Start();
            }
            
        }

        private static void Task()
        {
            while (_stop == 0)
            {
                if (sbiz_socket.AcceptConnection() > 0) break;
            }

            ModelChanged_EventArgs args = new ModelChanged_EventArgs();
            SbizServerController.OnModelChanged(sbiz_socket, args);

            byte[] dataBuff = new byte[256];

            while (_stop == 0)
            {
                int n = sbiz_socket.ReceiveData(ref dataBuff);
                if(n>0)
                {
                    SbizMessage m = new SbizMessage(dataBuff);
                    StreamWriter sw = new StreamWriter("tmp.txt",true);
                    string tmp = Encoding.UTF8.GetString(m.Data, 0, m.Data.Length);
                    sw.Write(tmp);
                    sw.Close();
                    System.Windows.Forms.SendKeys.SendWait(tmp);
                }
                else//timeout expired
                {
                    _stop = 1;
                }
            }

            sbiz_socket.ShutdownConnection();
            Interlocked.Exchange(ref _stop, 0);
        }

        public static void Stop()
        {
            Interlocked.Exchange(ref _stop, 1);
            background_thread.Join();
            ModelChanged_EventArgs args = new ModelChanged_EventArgs();
            SbizServerController.OnModelChanged(sbiz_socket, args);
        }
    }
}
