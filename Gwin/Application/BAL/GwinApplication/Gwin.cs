using App.Gwin.Application.BAL;
using App.Gwin.Application.BAL.Authentication;
using App.Gwin.Application.BAL.GwinApplication;
using App.Gwin.Application.Presentation.MainForm;
using App.Gwin.Attributes;
using App.Gwin.Entities.Authentication;
using App.Gwin.Exceptions.Gwin;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace App.Gwin
{
    /// <summary>
    /// GenericWinFrom Application instance
    /// Sengleton classes
    /// </summary>
    public class GwinApp
    {
        #region private static Properties
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

        #region Enumerations
        /// <summary>
        /// Languages of the GwinApp
        /// </summary>
        public enum Languages
        {
            en,
            fr,
            ar
        }
        #endregion

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
        ///  Form application menu instance
        /// </summary>
        public FormApplication ApplicationMenu { set; get; }
        /// <summary>
        /// Connected user
        /// </summary>
        public User user { set; get; }
        #endregion

        #region Private  Properties
        /// <summary>
        /// Application Culutre Info 
        /// </summary>
        public CultureInfo CultureInfo { set; get; }
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
            InstallApplicationGwinBLO installApplication = new InstallApplicationGwinBLO(TypeDbContext);
            installApplication.Update();


            if (AppMenu != null && user != null)
            {
                // Change Gwin Language 
                new GwinLanguageBLO().ChangeLanguage(GwinApp.Instance.CultureInfo, GwinApp.Instance.ApplicationMenu);
            }


        }
        private static void TestIf_Gwin_isStart()
        {
            if (GwinApp.instance == null) throw new GwinException("The Gwin Application Must be started befor use Gwin.Instance");
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

        #region Langauage
        public static void ChangeLanguage(CultureInfo cultureInfo)
        {
            GwinApp.TestIf_Gwin_isStart();
            GwinApp.Instance.CultureInfo = cultureInfo;
            new GwinLanguageBLO().ChangeLanguage(GwinApp.Instance.CultureInfo, GwinApp.Instance.ApplicationMenu);
        }


        #endregion

        #region Install and Update
        /// <summary>
        /// Update Gwin Tables, it must be executed after Model configuration change
        /// It can be used befor Gwin Creation.
        /// </summary>
        public static void Update(Type Type_DbContext)
        {
            // Update GwinApplicatio, after  ModelConfiguration changes
            InstallApplicationGwinBLO installApplication = new InstallApplicationGwinBLO(Type_DbContext);
            installApplication.Update();
        }
        #endregion
    }


}
