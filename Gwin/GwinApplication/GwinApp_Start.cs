using App.Gwin.Application.BAL;
using App.Gwin.Application.BAL.Authentication;
using App.Gwin.Application.Presentation.MainForm;
using App.Gwin.Attributes;
using App.Gwin.Entities.Application;
using App.Gwin.Entities.Authentication;
using App.Gwin.Exceptions.Gwin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin
{
    public partial class GwinApp
    {
        #region GwinApp Instance
        private static GwinApp instance = null;
        /// <summary>
        /// Get or Set Gwin Instance
        /// </summary>
        public static GwinApp Instance
        {
            get
            {
                TestIf_Gwin_isStart();
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        #endregion

        #region Start Application
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppMenu">Main Form application, 
        /// it contrain the menu of application
        /// it is Mdi Form
        /// </param>
        /// <param name="user">Connected user, 
        /// it can be null if the user is not yet connected
        /// </param>
        /// <param name="TypeDbContext">
        /// Type of EntityFramework DbContext
        /// id used to create instance of GwinApp EntityBAO object
        /// </param>
        public static void Start(Type TypeDbContext, Type TypeBaseBLO, FormApplication AppMenu, User user)
        {
             
            GwinApp.Loading_Start();
            GwinApp.Loading_Status("Start Gwin Applicaton ...");
            
            // Create Gwin Instance
            if (GwinApp.instance == null)
            {
                if (user == null)
                {
                    user = new UserGwinBLO().CreateGuestUser();
                }
                GwinApp.Instance = new GwinApp(TypeDbContext, TypeBaseBLO, AppMenu, user);
            }

            // Update GwinApplicatio, after  ModelConfiguration changes
            //[Update]
            // Must be befor Language Change, because SetLanguge Use MenuTable
            InstallApplicationGwinBLO installApplication = new InstallApplicationGwinBLO(TypeDbContext);
            installApplication.Update();

            // Change Gwin Language 
            if (AppMenu != null && user != null)
            {
                GwinApp.SetLanguage(GwinApp.Instance.CultureInfo);
            }

            

            // Load ApplicationName Instance
            IBaseBLO ApplicationNameBLO = new BaseEntityBLO<ApplicationName>((DbContext)Activator.CreateInstance(instance.TypeDBContext));
            List<object> ls_apps = ApplicationNameBLO.GetAll();
            if (ls_apps != null && ls_apps.Count > 0)
                GwinApp.instance.ApplicationName = (ApplicationName)ls_apps.First();
            else
            {
                ApplicationName applicationName = new ApplicationName();
                applicationName.Name = new Entities.MultiLanguage.LocalizedString();
                applicationName.Name.Current = "Gwin Application";
                GwinApp.instance.ApplicationName = applicationName;
            }

            // Set Name Applicatoin in ApplicationMenu
            if (AppMenu != null)
            {
                AppMenu.Text = instance.ApplicationName.Name.Current;
            }

            // Close Loading Interface
            GwinApp.Loading_Close();

        }
        /// <summary>
        /// Test id the Gwin Application is Started
        /// </summary>
        private static void TestIf_Gwin_isStart()
        {
            if (GwinApp.instance == null) throw new GwinException("The Gwin Application Must be started befor use Gwin.Instance");
        }
        #endregion

        #region Restart
        /// <summary>
        /// Restart Gwin Application
        /// </summary>
        public static void Restart()
        {
           
            GwinApp old_instance = GwinApp.instance;
            GwinApp.End();
            GwinApp.Start(old_instance.TypeDBContext, old_instance.TypeBaseBLO, old_instance.FormApplication, old_instance.user);
        }
        #endregion

        #region End Application
        /// <summary>
        /// End GwinApp
        /// </summary>
        public static void End()
        {
            GwinApp.instance = null;
            // Despose All Calculated Configuration
            ConfigEntity.Despose();
        }
        #endregion
    }
}
