using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SbizServer
{
    class SbizServerSocket
    {
        private Socket s_listen;
        private Socket s_conn;
        public int  port;
        private static bool _connected;

        public bool Connected{
            get
            {
                return _connected;
            }
        }

        public SbizServerSocket()
        {
            port = 15001;
            _connected = false;
        }

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

            _connected = false;
        }

        public int AcceptConnection()
        {
            if (!_connected)
            {
                ArrayList listenList = new ArrayList();
                listenList.Add(s_listen);
                Socket.Select(listenList, null, null, 10 ^ 5);
                for (int i = 0; i < listenList.Count; i++)
                {
                    s_conn = s_listen.Accept();
                    _connected = true;

                    return 1;
                }

                return -1;
            }

            return 1;
        }

        public void ReceiveData()
        {
            
        }

        public void ShutdownConnection()
        {
            if (_connected)
            {
                s_conn.Close();
                s_conn = null;

                _connected = false;
            }
        }
    }
}
