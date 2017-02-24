using App.WinForm.Application.BAL;
using App.WinForm.Application.Security;
using App.WinForm.Entities;
using App.WinForm.Entities.Authentication;
using App.WinForm.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm.Application
{
    /// <summary>
    /// GenericWinFrom Application instance
    /// </summary>
    public class  GWinApp
    { 

        private static Session session;
        public static Session Session {
            set { session = value; }
            get {
                // si la session est null, on initialise l'application
                if (session == null) initApplication();
                return session;
            }
        }

        public static void Start(Session session)
        {
            Session = session;

        }

        static GWinApp()
        {
     


        }

        /// <summary>
        /// Run default Session application
        /// </summary>
        public static void initApplication()
        {
            User user = new User();
            user.Name = "ES-SARRAJ";
            user.FirstName = "Fouad";

            BaseForm MdiForm = new BaseForm();
            MdiForm.IsMdiContainer = true;

            GWinApp.Session = new Session(MdiForm, user, Thread.CurrentThread.CurrentCulture);
        }
    }
}
