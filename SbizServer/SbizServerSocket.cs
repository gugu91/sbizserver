using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sbiz.Library;

namespace SbizServer
{
    class SbizServerSocket
    {
        #region Attributes
        private Socket s_listen;
        public int  port;
        private bool _listening;
        public ManualResetEvent allDone = new ManualResetEvent(false);
        #endregion

        #region Constructors
        public SbizServerSocket()
        {
            port = 15001;
            _connected = false;
        }
        #endregion

        #region InstanceMethods
        public void SbizServerListenOnPort(int port_p)
        {
            port = port_p;
            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, port);
            s_listen = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                s_listen.Bind(ipe);
            }
            catch (Exception e)
            {
                Console.WriteLine("Winsock error: " + e.ToString());
            }

            s_listen.Listen(100);

            _listening = true;
        }

        public void BeginAcceptConnection(AsyncCallback callback)
        {
            s_listen.BeginAccept(AcceptCallback, this);
        }

 

        public void ShutdownConnection()
        {
            if (_connected)
            {
                s_listen.Shutdown(SocketShutdown.Both);
                s_conn.Close();
                s_conn = null;

                _connected = false;
            }
        }
        #endregion
    }


}
