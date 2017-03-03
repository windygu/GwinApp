using SplashScreen;
using System;
using System.Collections.Generic;
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
            Splasher.Show(typeof(GwinLoader));
        }

        /// <summary>
        /// Change Loading Status
        /// </summary>
        /// <param name="status"></param>
        public static void Loading_Status(string status)
        {
            Splasher.Status = status;
        }

        /// <summary>
        /// Close Loading interface
        /// </summary>
        public static void Loading_Close()
        {
            Splasher.Close();
        }

    }
}
