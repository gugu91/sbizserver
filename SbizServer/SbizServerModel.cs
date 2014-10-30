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
        public static SbizListenerSocket sbiz_socket;
        public static Thread background_thread;
        private static Int32 _stop;
        

        public static void Init(){
            sbiz_socket = new SbizListenerSocket();
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
                while (_stop == 0) if (sbiz_socket.AcceptConnection() > 0) break;
                
                SbizServerController.OnModelChanged(sbiz_socket, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.CONNECTED));
                
                while (_stop == 0)
                {
                    byte[] dataBuff = new byte[256];

                    int n = sbiz_socket.ReceiveData(ref dataBuff);
                    if (n > 0)
                    {
                        SbizMessage m = new SbizMessage(dataBuff);
                        StreamWriter sw = new StreamWriter("tmp.txt", true);
                        string tmp = Encoding.UTF8.GetString(m.Data, 0, m.Data.Length);
                        sw.Write(tmp);
                        sw.Close();
                        //System.Windows.Forms.SendKeys.SendWait(tmp);
                    }
                    else if (n == 0)//timeout expired
                    {
                    }
                    else if (n == -1)//connection closed
                    {
                        SbizServerController.OnModelChanged(sbiz_socket, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.ERROR));
                        break;
                    }
                }
            }

            SbizServerController.OnModelChanged(sbiz_socket, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.NOT_CONNECTED));
            sbiz_socket.ShutdownConnection();
            Interlocked.Exchange(ref _stop, 0);
        }

        public static void Stop()
        {
            Interlocked.Exchange(ref _stop, 1);
            background_thread.Join();
            SbizModelChanged_EventArgs args = new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.NOT_CONNECTED);
            SbizServerController.OnModelChanged(sbiz_socket, args);
        }
    }
}
