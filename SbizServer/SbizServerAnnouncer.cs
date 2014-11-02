﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Sbiz.Library;
using System.Threading;
namespace SbizServer
{
    class SbizServerAnnouncer
    {
        private Socket s_announce;
        public SbizServerAnnouncer()
        {
            s_announce = null;
        }

        public void Start(int UDPPort, int TCPPort){
            var ipe = new IPEndPoint(IPAddress.Broadcast, UDPPort);
            s_announce = new Socket(ipe.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            byte[] buffer = (SbizMessage.AnnounceMessage(TCPPort));
            BeginSendToState state = new BeginSendToState(s_announce, buffer, ipe);
            s_announce.BeginSendTo(buffer, 0, buffer.Length, SocketFlags.Broadcast, ipe, BeginSendToCallback, state);
        }

        private void BeginSendToCallback(IAsyncResult ar)
        {
            if(SbizServerController.Listening){
                BeginSendToState state = (BeginSendToState)ar.AsyncState;
                state._s.EndSendTo(ar);
                Thread.Sleep(100);
                state._s.BeginSendTo(state._buffer, 0, state._buffer.Length, SocketFlags.Broadcast, state._ipe, BeginSendToCallback, state);
            }
        }

        private  class BeginSendToState
        {
            public Socket _s;
            public byte[] _buffer;
            public IPEndPoint _ipe;

            public BeginSendToState(Socket s, byte[] buffer, IPEndPoint ipe)
            {
                _s = s;
                _buffer = buffer;
                _ipe = ipe;
            }
        }
    }
}
