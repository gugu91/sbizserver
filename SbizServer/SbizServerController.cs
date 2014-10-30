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
            SbizServerModel.Init();
        }

        public static void Start()
        {
            SbizServerModel.Start();
        }

        public static void Stop()
        {
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


    }
}
