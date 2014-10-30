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

namespace Sbiz.Library
{
    class SbizListenerSocket
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
        public SbizListenerSocket()
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
                    s_conn.ReceiveTimeout/*ms*/ = SbizConf.SbizSocketTimeout_ms;
                    _connected = true;

                    return 1;
                }

                return -1;
            }

            return 1;
        }

        ///<summary>
        /// Receive data from client, returns number of byte read, 0 if timedout, -1 if connection was closed for any reason
        /// </summary>
        public int ReceiveData(ref byte[] dataBuff)
        {
            int byteRead;

            try
            {
                byteRead = s_conn.Receive(dataBuff);//timeout was set in acceptconnection
            }
            catch (SocketException se)
            {
                if (se.SocketErrorCode == SocketError.TimedOut)
                {
                    return 0;
                }
                else
                {
                    s_conn.Shutdown(SocketShutdown.Both);
                    s_conn.Close();
                    return -1;
                }
            }
            return byteRead;
        }

        public void ShutdownConnection()
        {
            if (_connected)
            {
                s_conn.Shutdown(SocketShutdown.Both);
                s_conn.Close();
                s_conn = null;

                _connected = false;
            }
        }
        #endregion
    }
}
