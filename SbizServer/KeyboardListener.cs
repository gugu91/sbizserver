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
    class KeyboardListenerServer
    {
        private volatile bool _stop;

        public KeyboardListenerServer()
        {
            _stop = false;
        }

        public Thread StartThread(int port, System.Windows.Forms.Label connectionStatusLabel)
        {
            var t = new Thread(() => Task(port, connectionStatusLabel));
            t.Start();
            return t;
        }

        public void Task(int port, System.Windows.Forms.Label connectionStatusLabel)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, port);
            Socket s = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            while (true)
            {
                try
                {
                    s.Bind(ipe);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Winsock error: " + e.ToString());
                }

                s.Listen(100);

                Socket s1 = s.Accept();

                connectionStatusLabel.Text = "Connesso";

                
                while (!_stop)
                {
                    /*byte[] bytes = new byte[20];
                    int i = s1.Receive(bytes);
                    Console.Write(Encoding.UTF8.GetString(bytes, 0, i));*/
                }

                s1.Close();
            }

            s.Close();
        }

        public void Stop()
        {
            _stop = true;
        }
    }
}
