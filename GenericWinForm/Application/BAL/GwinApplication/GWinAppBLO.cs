using App.WinForm.Application.BAL.Authentication;
using App.WinForm.Application.Presentation.MainForm;
using App.WinForm.Attributes;
using App.WinForm.Entities.Authentication;
using App.WinForm.Exceptions.Gwin;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace App.WinForm.Application.BAL.GwinApplication
{
    /// <summary>
    /// GenericWinFrom Application instance
    /// Sengleton classes
    /// </summary>
    public class Gwin
    {
        #region private static Properties
        private static Gwin instance = null;
        /// <summary>
        /// Get or Set Gwin Instance
        /// </summary>
        public static Gwin Instance {
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
        public Gwin(Type TypeDbContext, Type TypeBaseBLO, FormApplication applicationMenuInstance, User user)
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
            if (Gwin.instance == null)
            {
                if (user == null)
                {
                    user = new UserGwinBLO().CreateGuestUser();
                }
                Gwin.Instance = new Gwin(TypeDbContext, TypeBaseBLO,AppMenu, user);
            }

            // Update GwinApplicatio, after  ModelConfiguration changes
            InstallApplicationGwinBLO installApplication = new InstallApplicationGwinBLO(TypeDbContext);
            installApplication.Update();

            // Change Gwin Language 
            new GwinLanguageBLO().ChangeLanguage(Gwin.Instance.CultureInfo, Gwin.Instance.ApplicationMenu);


        }
        private static void TestIf_Gwin_isStart()
        {
            if (Gwin.instance == null) throw new GwinException("The Gwin Application Must be started befor use Gwin.Instance");
        }
        #endregion

        #region End Application
        /// <summary>
        /// End GwinApp
        /// </summary>
        public static void End()
        {
            // Despose All Calculated Configuration
            ConfigEntity.Despose();
        }
        #endregion

        #region Langauage
        public static void ChangeLanguage(CultureInfo cultureInfo)
        {
            Gwin.TestIf_Gwin_isStart();
            Gwin.Instance.CultureInfo = cultureInfo;
            new GwinLanguageBLO().ChangeLanguage(Gwin.Instance.CultureInfo, Gwin.Instance.ApplicationMenu);
        }

       
        #endregion
    }

    
}
