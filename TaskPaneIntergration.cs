using System;
using System.IO;
using System.Runtime.InteropServices;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;

namespace DeleteProperties
{
    /// <summary>
    /// SW Add-in for deleting properties in taskpane
    /// </summary>
    public class TaskPaneIntergration : ISwAddin
    {
        #region Private Members
        
        //The cookies to the current instance of Sw
        private int _swCookies;
        //The taskpane view for the add-in
        private TaskpaneView _swTaskpaneView;

        //The UI that is going to be displayed on the taskpane
        private DeletePropertiesUI _deletePropertiesUI;

        //Instance of SW
        private SldWorks _swApp;

        //Get SW command manager
        private CommandManager _cmdMgr;
        #endregion

        #region Public Members

        //The unique id in the taskpane for registration
        public const string _SWTASKPANE_PROGID = "ILT.SolidWorks.DeleteProperties";

        #endregion

        #region SWAdd-in Interface
        /// <summary>
        /// Called when SW has loaded the add-in and works to do our connection logic
        /// </summary>
        /// <param name="ThisSW">The current SW instance</param>
        /// <param name="Cookie">The current SW cookie id</param>
        /// <returns></returns>
        public bool ConnectToSW(object ThisSW, int Cookie)
        {
            //Store a referece to SW
            _swApp = (SldWorks)ThisSW;

            //Store the cookies
            _swCookies = Cookie;

            //Setup callback info
            var ok = _swApp.SetAddinCallbackInfo2(0, this, _swCookies);

            //Setup the SW command manager
            _cmdMgr = (CommandManager)_swApp.GetCommandManager(Cookie);

            LoadUi();

            return true;
        }

        /// <summary>
        /// Called when SW has about to unload the add-in and works to do our disconnection logic
        /// </summary>
        /// <returns></returns>
        public bool DisconnectFromSW()
        {
            //Clean up our UI
            UnloadUi();
            return true;
        }

        #endregion

        #region Load UI
        /// <summary>
        /// Create our Taskpane and inject our host UI
        /// </summary>
        private void LoadUi()
        {
            //Path to the image located in the add-in folder
            string imagePath = Path.Combine(Path.GetDirectoryName(typeof(TaskPaneIntergration).Assembly.CodeBase).Replace(@"file:\", ""), "ILT.png");

            //Create the taskpane itself
           _swTaskpaneView =  _swApp.CreateTaskpaneView2(imagePath, "Deletes Properties");

            //load the UI into the taskpane
            _deletePropertiesUI = (DeletePropertiesUI)_swTaskpaneView.AddControl(TaskPaneIntergration._SWTASKPANE_PROGID, string.Empty);
        }

        /// <summary>
        /// Cleanup the taskpane when we disconnect
        /// </summary>
        private void UnloadUi()
        {
            _deletePropertiesUI = null;

            //Remove taskpane view
            _swTaskpaneView.DeleteView();

            //Release COm reference and cleanup memory
            Marshal.ReleaseComObject(_swTaskpaneView);

            _swTaskpaneView = null;
        }

        #endregion

        #region COM Registration

        /// <summary>
        /// The COM registration call to add our add-in registry to the SW registry
        /// </summary>
        /// <param name="t"></param>
        [ComRegisterFunction()]
        private static void ComRegister(Type t)
        {
            var keyPath = string.Format(@"SOFTWARE\Solidworks\Addins\{0:b}", t.GUID);

            //Create our registry entry
            using (var rk = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(keyPath))
            {
                //Load add-in on startup of SW
                rk.SetValue(null, 1);

                //Set the add-in title
                rk.SetValue("Title", "Delete Properties");

                //Set the add-in description
                rk.SetValue("Description", "Delete all the properties that contain a phrase");
            }

            keyPath = string.Format(@"SOFTWARE\Solidworks\AddinsStartup\{0:b}", t.GUID);

            using (var curk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(keyPath))
            {
                //Load add-in on startup of SW
                curk.SetValue(null, 1);
            }
        }

        /// <summary>
        /// The COM unregister call to remoce our custom entries we added in the COM register function
        /// </summary>
        /// <param name="t"></param>
        [ComUnregisterFunction()]
        private static void ComUnregister(Type t)
        {
            var keyPath = string.Format(@"SOFTWARE\Solidworks\Addins\{0:b}", t.GUID);

            //Remove our registry entry
            Microsoft.Win32.Registry.LocalMachine.DeleteSubKeyTree(keyPath);

            keyPath = string.Format(@"SOFTWARE\Solidworks\AddinsStartup\{0:b}", t.GUID);

            //Remove the registry entry for current user
            Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree(keyPath);
        }

        #endregion
    }
}
