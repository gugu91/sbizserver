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

namespace SbizServer
{
    static class SbizServerModel
    {
        public static SbizServerSocket sbiz_socket;
        public static Thread background_thread;
        private static Int32 _stop;
        private static Socket s_listen;
        private static bool _listening;
        private static Queue<byte[]> message_queue;
        

        public static void Init(){
            background_thread = null;
            Interlocked.Exchange(ref _stop, 0);
            messages = new Queue<byte[]>;
            _listening = false;
        }

        public static void Start()
        {
            if (background_thread == null)
            {
                IPEndPoint ipe = new IPEndPoint(IPAddress.Any, SbizConf.SbizSocketPort);
                s_listen = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    s_listen.Bind(ipe);
                    s_listen.Listen(100);

                    _listening = false;
                    background_thread = new Thread(() => Task());
                    background_thread.Start();
                }
                catch //TODO handle bind exception
                {

                }
                
            }
            
        }

        public static void Stop()
        {
            Interlocked.Exchange(ref _stop, 1);
            background_thread.Join();
            ModelChanged_EventArgs args = new ModelChanged_EventArgs();
            SbizServerController.OnModelChanged(sbiz_socket, args);
        }

        private static void Task()
        {
            s_listen.BeginAccept(AcceptCallback, s_listen);

            sbiz_socket.ShutdownConnection();
            Interlocked.Exchange(ref _stop, 0);
        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            if (_listening)
            {
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);
                ModelChanged_EventArgs args = new ModelChanged_EventArgs();
                SbizServerController.OnModelChanged(handler, args);

                // Create the state object.
                StateObject state = new StateObject();
                state.s_conn = handler;
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
            }
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            if (_listening)
            {
                // Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;

                Socket handler = state.s_conn;

                // Read data from the client socket. 
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                   /* lock (message_queue)
                    {
                        message_queue.Enqueue(state.buffer);
                    }*/
                    SbizMessage m = new SbizMessage(state.buffer);


                    if (m.Code == SbizMessageConst.KEY_PRESS)
                    {
                        string tmp = Encoding.UTF8.GetString(m.Data, 0, m.Data.Length);
                        System.Windows.Forms.SendKeys.SendWait(tmp);
                    }

                    //Add other events...

                    //Get new data
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
                else//clientshutdown
                {

                }
            }
        }
    }

    public class StateObject
    {
        public Socket s_conn;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
    }

}
