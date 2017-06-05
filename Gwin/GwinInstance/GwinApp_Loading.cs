using SplashScreen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApp.GwinApp
{
    /// <summary>
    /// Loading Form Manager
    /// </summary>
    public partial class GwinAppInstance
    {
        /// <summary>
        /// Start Loading Interfae
        /// </summary>
        public static void Loading_Start()
        {
            // Run Loadind Interface if the programme is not en debug Mode
            if (!Debugger.IsAttached)
                Splasher.Show(typeof(GwinLoader));
        }

        /// <summary>
        /// Change Loading Status
        /// </summary>
        /// <param name="status"></param>
        public static void Loading_Status(string status)
        {
            if (!Debugger.IsAttached)
                Splasher.Status = status;
        }

        /// <summary>
        /// Close Loading interface
        /// </summary>
        public static void Loading_Close()
        {
            if (!Debugger.IsAttached)
                Splasher.Close();
        }

    }
}
