using Gwin.Presentation.GwinLoader;
using SplashScreen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin
{
    /// <summary>
    /// Loading Form Manager
    /// </summary>
    public partial class GwinApp
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
        public static void Loading_Start(Type TypeOfFormLoader)
        {
            // Run Loadind Interface if the programme is not en debug Mode
            if (!Debugger.IsAttached)
                Splasher.Show(TypeOfFormLoader);
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
