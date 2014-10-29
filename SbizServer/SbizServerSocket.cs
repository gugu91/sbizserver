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
        private Socket s_conn;
        public int  port;
        private bool _connected;
        #endregion

        #region Properties
        public bool Connected{
            get
            {
                return _connected;
            }
        }
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

            _connected = false;
        }

        public int AcceptConnection()
        {
            if (!_connected)
            {
                ArrayList listenList = new ArrayList();
                listenList.Add(s_listen);
                Socket.Select(listenList, null, null, 10 ^ 5);
                if (listenList.Count > 0)
                {
                    s_conn = s_listen.Accept();
                    _connected = true;

                    return 1;
                }

                return -1;
            }

            return 1;
        }

        public int ReceiveData(ref byte[] dataBuff)
        {
            int byteRead = -1;
            ArrayList connList = new ArrayList();
            
            connList.Add(s_conn);
            Socket.Select(connList, null, null, 5*SbizConf.);

            for(int i=0; i< connList.Count; i++)
            {
                 byteRead = s_conn.Receive(dataBuff);
            }

            return byteRead;
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
        #endregion
    }
}
