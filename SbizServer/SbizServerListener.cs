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
    class SbizServerListener
    {
        #region Attributes
        private Socket s_listen;
        private Socket s_conn;
        #endregion

        public SbizServerListener()
        {
            s_listen = null;
            s_conn = null;
        }

        #region InstanceMethods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="port_p">TCP port on which listen</param>
        public void Listen(int port_p)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, port_p);
            s_listen = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                s_listen.Bind(ipe);
                s_listen.Listen(100);
            }
            catch (Exception e)//TODO handle bind exception
            {
                throw e;
            }
        }
        /// <summary>
        /// Starts accepting and serving connections
        /// </summary>
        public void Start()
        {
            s_listen.BeginAccept(AcceptCallback, s_listen);
        }
        /// <summary>
        /// Stops accepting and serving connections
        /// </summary>
        public void Stop()
        {
            if (s_conn != null)
            {
                s_conn.Shutdown(SocketShutdown.Both);
                s_conn.Close();
                s_conn = null;
            }
            if (s_listen != null)
            {
                s_listen.Close();
            }
            SbizServerController.OnModelChanged(this, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.NOT_LISTENING));
        }

        #region AsyncCallbacks
        private void AcceptCallback(IAsyncResult ar)
        {
            if (SbizServerController.Listening)
            {
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = null;
                try
                {
                    handler = listener.EndAccept(ar);
                }
                catch (ObjectDisposedException ode) //user changed port
                {
                    SbizLogger.Logger = "User changed port";
                    return;
                }
                
                s_conn = handler;

                SbizServerController.OnModelChanged(this, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.CONNECTED));

                // Create the state object.
                StateObject state = new StateObject();
                state.s_conn = handler;
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
            }
        }

        private void ReadCallback(IAsyncResult ar)
        {
            if (SbizServerController.Listening)
            {
                // Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;

                Socket handler = state.s_conn;

                // Read data from the client socket. 
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    /* NB there was previously a protocol error as size of the data buffer was not sent, causing
                     * some data to not be processed by server.
                     */
                    int seek=0;
                    while(seek < bytesRead){
                        //First four bytes are the size of the subsequent databuffer
                        byte[] datasize_byte = new byte[sizeof(Int32)];
                        Array.Copy(state.buffer, seek, datasize_byte, 0, sizeof(Int32));
                        seek += sizeof(Int32);
                        Int32 datasize = BitConverter.ToInt32(datasize_byte, 0);

                        //Databuffer handled here
                        byte[] data = new byte[datasize];
                        Array.Copy(state.buffer, seek, data, 0, datasize);
                        seek += datasize;
                        SbizServerModel.TCPBufferQueue.Enqueue(data);
                        SbizServerModel.ModelSyncEvent.Set();
                    }
                    //Get new data
                    StateObject state_out = new StateObject();
                    state_out.s_conn = handler;
                    handler.BeginReceive(state_out.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state_out);
                }
                else//clientshutdown
                {
                    SbizServerController.OnModelChanged(this, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.NOT_CONNECTED));
                    Start();
                }
            }
        }
        #endregion
        #endregion

        private class StateObject
        {
            public Socket s_conn;
            // Size of receive buffer.
            public const int BufferSize = 1024;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
        }
    }
}
