using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sbiz.Library;

namespace SbizServer
{
    public interface SbizForm //Extend the interface of Form to support the event for any IView object
    {
        void UpdateViewOnModelChanged(object sender, SbizModelChanged_EventArgs args);
    }

    static class SbizServerController
    {
        #region ModelChangedRegion
        public static event SbizModelChanged_Delegate ModelChanged;
        public static void OnModelChanged(object sender, SbizModelChanged_EventArgs args)
        {
            if (ModelChanged != null)
            {
                ModelChanged(sender, args);
            }
        }
        #endregion

        public static void Init()
        {
            //SbizServerModel.Listening = true;
            //SbizServerModel.Init();
        }

        public static void Start(IntPtr _clipboard_listener_control_handle)
        {
            NativeImport.AddClipboardFormatListener(_clipboard_listener_control_handle);
            SbizServerModel.Start(Properties.Settings.Default.TCPPort, Properties.Settings.Default.UDPPort,
                Properties.Settings.Default.ServerName, _clipboard_listener_control_handle);
        }

        public static void Stop(IntPtr _clipboard_listener_control_handle)
        {
            NativeImport.RemoveClipboardFormatListener(_clipboard_listener_control_handle);
            SbizServerModel.Stop();
        }
        public static void RegisterView(SbizForm view) //Call this from a view to subscribe the event
        {
            ModelChanged += new SbizModelChanged_Delegate(view.UpdateViewOnModelChanged);
        }

        public static void UnregisterView(SbizForm view) //Call this from a view to unsubscribe events
        {
            ModelChanged -= new SbizModelChanged_Delegate(view.UpdateViewOnModelChanged);
        }

        public static void WndProcOverride(System.Windows.Forms.Message m, IntPtr view_handle)
        {
            if (m.Msg == NativeImport.WM_CLIPBOARDUPDATE) //Handling clipboard data
            {
                SbizClipboardHandler.SendClipboardData(System.Windows.Forms.Clipboard.GetDataObject(),
                    SbizServerController.OnModelChanged, view_handle);
            }
        }
    }
}
