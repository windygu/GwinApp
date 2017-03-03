using App.Gwin.Application.BAL;
using App.Gwin.Application.BAL.Authentication;
using App.Gwin.Application.BAL.GwinApplication;
using App.Gwin.Application.Presentation.MainForm;
using App.Gwin.Attributes;
using App.Gwin.Entities.Application;
using App.Gwin.Entities.Authentication;
using App.Gwin.Exceptions.Gwin;
using SplashScreen;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Windows.Forms;

namespace App.Gwin
{
    /// <summary>
    /// GenericWinFrom Application instance
    /// Sengleton classes
    /// </summary>
    public partial class GwinApp
    {

        #region Public  Properties
        /// <summary>
        /// Type of EntityFramework DbContext
        /// id used to create instance of GwinApp EntityBAO object
        /// </summary>
        public Type TypeDBContext { set; get; }

        /// <summary>
        /// BaseBLO Type
        /// </summary>
        public Type TypeBaseBLO { set; get; }

        /// <summary>
        /// ApplicationName Instance
        /// </summary>
        public ApplicationName ApplicationName { get; set; }

        /// <summary>
        ///  Form application menu instance
        /// </summary>
        public FormApplication ApplicationMenu { set; get; }
        /// <summary>
        /// Connected user
        /// </summary>
        public User user { set; get; }
        #endregion

     

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="applicationMenuInstance">
        /// Main Form Application
        /// it contrain Menu Application
        /// is is MdiForm
        /// </param>
        /// <param name="user">Connected user</param>
        public GwinApp(Type TypeDbContext, Type TypeBaseBLO, FormApplication applicationMenuInstance, User user)
        {
            this.TypeDBContext = TypeDbContext;
            this.TypeBaseBLO = TypeBaseBLO;
            this.ApplicationMenu = applicationMenuInstance;
            this.user = user;
            this.CultureInfo = new CultureInfo(user.Language.ToString());
        }
        #endregion
    }
}
