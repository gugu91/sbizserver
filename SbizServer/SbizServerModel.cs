using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Sbiz.Library;
using WindowsInput;


namespace SbizServer
{
    static class SbizServerModel
    {
        private static SbizServerListener _listener;
        private static InputSimulator _simulator = new InputSimulator();
        private static SbizServerAnnouncer _announcer = new SbizServerAnnouncer();


        public static void Init()
        {
            _listener = new SbizServerListener();
            _simulator = new InputSimulator();
        }

        public static void Start(int TCPPort, int UDPPort, string servername)
        {
            _listener = new SbizServerListener();
            _announcer = new SbizServerAnnouncer();
                _listener.Listen(TCPPort);
                _listener.Start();
                _announcer.Start(TCPPort, UDPPort, servername);
        }

        public static void Stop()
        {
            _listener.Stop();
            _announcer.Stop();
        }
        public static void MessageHandle(SbizMessage m)
        {
            if (m.Code == SbizMessageConst.KEY_PRESS)
            {
                string tmp = Encoding.UTF8.GetString(m.Data, 0, m.Data.Length);
                System.Windows.Forms.SendKeys.SendWait(tmp);
            }

            if (m.Code == SbizMessageConst.MOUSE_MOVE || m.Code == SbizMessageConst.MOUSE_UP || 
                m.Code == SbizMessageConst.MOUSE_DOWN || m.Code == SbizMessageConst.MOUSE_WHEEL)
            {
                SbizMouseEventArgs smea = new SbizMouseEventArgs(m.Data);
                SimulateMouseEvent(m.Code, smea);
            }

            //Add other events...
        }

        public static void SimulateMouseEvent(int code, SbizMouseEventArgs smea)
        {
            Cursor.Position = smea.Location;
            switch (code)
            {
                case SbizMessageConst.MOUSE_MOVE:
                    break;
                case SbizMessageConst.MOUSE_DOWN:
                    switch (smea.Button)
                    {
                        case MouseButtons.Left:
                            _simulator.Mouse.LeftButtonDown();
                            break;
                        case MouseButtons.Middle:
                            _simulator.Mouse.MiddleButtonDown();
                            break;
                        case MouseButtons.Right:
                            _simulator.Mouse.RightButtonDown();
                            break;
                        default:
                            break;
                    }
                    break;
                case SbizMessageConst.MOUSE_UP:
                    switch (smea.Button)
                    {
                        case MouseButtons.Left:
                            _simulator.Mouse.LeftButtonUp();
                            break;
                        case MouseButtons.Middle:
                            _simulator.Mouse.MiddleButtonUp();
                            break;
                        case MouseButtons.Right:
                            _simulator.Mouse.RightButtonUp();
                            break;
                        default:
                            break;
                    }
                    break;
                case SbizMessageConst.MOUSE_WHEEL:
                    _simulator.Mouse.VerticalScroll(smea.Delta);
                    break;
                default:
                    break;

            }
        }
    }

}
