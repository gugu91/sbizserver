using System;
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
        public const int  port = 15001;
        private static bool _connected;

        public bool Connected{
            get
            {
                return _connected;
            }
        }

        public SbizServerSocket()
        {
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

        public void AcceptConnection()
        {
            if (!_connected)
            {
                s_conn = s_listen.Accept();

                _connected = true;
            }
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
                ModelChanged_EventArgs args = new ModelChanged_EventArgs();
                SbizServerController.OnModelChanged(this, args);
            }
        }
    }
}
