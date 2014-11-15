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
        private static SbizMessager _listener;
        private static InputSimulator _simulator = new InputSimulator();
        private static SbizServerAnnouncer _announcer = new SbizServerAnnouncer();

        public static void Init()
        {
            _listener = new SbizMessager();
            _simulator = new InputSimulator();
        }

        public static void Start(int TCPPort, int UDPPort, string servername, IntPtr view_handle)
        {
            KeyboardCleanup();
            _listener = new SbizMessager();
            _listener.RegisterMessageHandle(MessageHandle);
            _announcer = new SbizServerAnnouncer();
            _listener.Listen(TCPPort);
            _listener.StartServer(SbizServerController.OnModelChanged, view_handle, "password");
            _announcer.Start(TCPPort, UDPPort, servername);
        }
        public static void Stop()
        {
            _listener.UnregisterMessageHandle(MessageHandle);
            _listener.StopServer(SbizServerController.OnModelChanged);
            _announcer.Stop();
            KeyboardCleanup();
        }
        public static void MessageHandle(SbizMessage m)
        {

            if (SbizMessageConst.IsKeyConst(m.Code))
            {
                SimulateKeyboardEvent(m.Code, m.Data);
            }

            else if (SbizMessageConst.IsMouseConst(m.Code))
            {
                SbizMouseEventArgs smea = new SbizMouseEventArgs(m.Data);
                SimulateMouseEvent(m.Code, smea);
            }
            else if (m.Code == SbizMessageConst.TARGET)
            {
                SbizServerController.OnModelChanged(_listener, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.TARGET));
            }
            else if (m.Code == SbizMessageConst.NOT_TARGET)
            {
                SbizServerController.OnModelChanged(_listener, new SbizModelChanged_EventArgs(SbizModelChanged_EventArgs.NOT_TARGET));
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

        public static void SimulateKeyboardEvent(int message_code, byte[] data)
        {
            //string tmp = Encoding.UTF8.GetString(data, 0, data.Length);
            //System.Windows.Forms.SendKeys.SendWait(tmp);

            var key = SbizNetUtils.DecapsulateInt16FromByteArray(ref data);
            if (message_code == SbizMessageConst.KEY_DOWN) _simulator.Keyboard.KeyDown((WindowsInput.Native.VirtualKeyCode)key);


            //if (key_code == SbizMessageConst.KEY_PRESS) _simulator.Keyboard.KeyPress();
            if (message_code == SbizMessageConst.KEY_UP) _simulator.Keyboard.KeyUp((WindowsInput.Native.VirtualKeyCode)key);
        }
        private static void KeyboardCleanup()
        {
            _simulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.CONTROL);
            _simulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.MENU);
        }
    }

}
