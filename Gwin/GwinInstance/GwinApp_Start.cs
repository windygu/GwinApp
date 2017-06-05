using GApp.GwinApp.Application.BAL;
using GApp.GwinApp.Application.BAL.Authentication;
using GApp.GwinApp.Application.Presentation;
using GApp.GwinApp.Application.Presentation.MainForm;
using GApp.GwinApp.Attributes;
using GApp.GwinApp.Entities.Application;
using GApp.GwinApp.Entities.Secrurity.Authentication;
using GApp.GwinApp.Exceptions.Gwin;
using GApp.GwinApp.Exceptions.Helpers;
using GApp.GwinApp.GwinApplication.IoC;
using GApp.GwinApp.GwinApplication.Presentation.Authentication;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GApp.GwinApp
{
    public partial class GwinAppInstance
    {
       

        #region GwinApp Instance
        private static GwinAppInstance instance = null;
       

        /// <summary>
        /// Get or Set Gwin Instance
        /// </summary>
        public static GwinAppInstance Instance
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

        /// <summary>
        /// Close Application
        /// </summary>
        public static void CloseApplication()
        {
            Environment.Exit(0);
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

            // User must not be null
            CheckPramIsNull.CheckParam_is_NotNull(user, nameof(GwinAppInstance), nameof(user));

            // Lunch Loading Interface
            GwinAppInstance.Loading_Start();
            GwinAppInstance.Loading_Status("Start Gwin Applicaton ...");

            // Create GwinInstance to Authenticate
            GwinAppInstance.Instance = new GwinAppInstance(TypeDbContext, TypeBaseBLO, AppMenu, user);

            //Layer configuration : Initialize the dependency resolver
            DependencyResolver.Initialize();

 
          
            //
            // Update Menu
            //
            // Change User Culture and Tread to do Update with User Language
            GwinAppInstance.instance.CultureInfo = new CultureInfo(user.Language.ToString());
            Thread.CurrentThread.CurrentCulture = GwinAppInstance.instance.CultureInfo;
            Thread.CurrentThread.CurrentUICulture = GwinAppInstance.instance.CultureInfo;
            // Update GwinApplicatio, after  ModelConfiguration changes
            //[Update]
            // Must be befor Language Change, because SetLanguge Use MenuTable
            InstallApplicationGwinBLO installApplication = new InstallApplicationGwinBLO(TypeDbContext);
            installApplication.Update();



            // Change Gwin Language 
            if (AppMenu != null && user != null)
            {
                GwinAppInstance.SetLanguage(GwinAppInstance.Instance.CultureInfo);
            }



            // Load ApplicationName Instance
            IGwinBaseBLO ApplicationNameBLO = new GwinBaseBLO<ApplicationName>((DbContext)Activator.CreateInstance(instance.TypeDBContext));
            List<object> ls_apps = ApplicationNameBLO.GetAll();
            if (ls_apps != null && ls_apps.Count > 0)
                GwinAppInstance.instance.ApplicationName = (ApplicationName)ls_apps.First();
            else
            {
                ApplicationName applicationName = new ApplicationName();
                applicationName.Name = new Entities.MultiLanguage.LocalizedString();
                applicationName.Name.Current = "Gwin Application";
                GwinAppInstance.instance.ApplicationName = applicationName;
            }

            // Set Name Applicatoin in ApplicationMenu
            if (AppMenu != null)
            {
                AppMenu.Text = instance.ApplicationName.Name.Current;
            }

            // Close Loading Interface
            GwinAppInstance.Loading_Close();

            // Authentification
            Login();




        }

        /// <summary>
        /// Authentification
        /// </summary>
        private static void Login()
        {
            // Authentication fo Guest User
            // Change GuestUser by Current User
            if (GwinAppInstance.Instance.user.Reference == nameof(User.Users.Guest))
            {
                do
                {
                    // Authentification
                    LoginForm loginForm = new LoginForm();
                 
                    loginForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    loginForm.ShowDialog();
                } while (GwinAppInstance.Instance.user.Reference == nameof(User.Users.Guest));
                GwinAppInstance.Restart();
            }

            
        }
        /// <summary>
        /// Test id the Gwin Application is Started
        /// </summary>
        private static void TestIf_Gwin_isStart()
        {
            if (GwinAppInstance.instance == null) throw new GwinException("The Gwin Application Must be started befor use Gwin.Instance");
        }
        #endregion

        #region Restart
        /// <summary>
        /// Restart Gwin Application
        /// </summary>
        public static void Restart()
        {

            GwinAppInstance old_instance = GwinAppInstance.instance;
            GwinAppInstance.End();
            GwinAppInstance.Start(old_instance.TypeDBContext, old_instance.TypeBaseBLO, old_instance.FormApplication, old_instance.user);
        }
        #endregion

        #region End Application
        /// <summary>
        /// End GwinApp
        /// </summary>
        public static void End()
        {
            GwinAppInstance.instance = null;
            // Despose All Calculated Configuration
            ConfigEntity.Despose();
        }
        #endregion
    }
}
