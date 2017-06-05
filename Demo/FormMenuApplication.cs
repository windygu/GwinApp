using GApp;
using GApp.GwinApp;
using GApp.GwinApp.Application.BAL;
using GApp.GwinApp.Application.Presentation.EntityManagement;
using GApp.GwinApp.Application.Presentation.MainForm;
using GApp.GwinApp.Entities;
using GApp.GwinApp.Entities.Application;
using GApp.GwinApp.Entities.Secrurity.Authentication;
using GenericWinForm.Demo.BAL;
using GenericWinForm.Demo.DAL;
using GenericWinForm.Demo.Entities;
using GenericWinForm.Demo.Entities.ProjectManager;
using SplashScreen;
using System;
using System.Windows.Forms;

namespace GenericWinForm.Demo
{
    public partial class FormMenuApplication : FormApplication
    {
        public FormMenuApplication()
        {
            InitializeComponent();
        }

        private void FormMenuApplication_Load(object sender, EventArgs e)
        {
            User user = null;
        //    user = User.CreateAdminUser(new ModelContext());
            user = User.CreateGuestUser(new ModelContext());
          //  user = User.CreateRootUser(new ModelContext());
            user.Language = GwinAppInstance.Languages.fr;

            // Start Gwin Application with Authentification
            GwinAppInstance.Start(typeof(ModelContext), typeof(BaseBLO<>), this, user);


        }

        /// <summary>
        /// Reload the form after language change
        /// </summary>
        public override void Reload()
        {
            base.Reload();
            InitializeComponent();
        }

        private void btProjectManager_Click(object sender, EventArgs e)
        {
            CreateAndShowManagerFormHelper ShowManagementFormHelper = new CreateAndShowManagerFormHelper(GwinAppInstance.Instance.TypeDBContext, this);
            ShowManagementFormHelper.ShowManagerForm(typeof(Project));
        }

        private void btTaskManager_Click(object sender, EventArgs e)
        {
            CreateAndShowManagerFormHelper ShowManagementFormHelper = new CreateAndShowManagerFormHelper(GwinAppInstance.Instance.TypeDBContext, this);
            ShowManagementFormHelper.ShowManagerForm(typeof(TaskProject));
        }
    }
}
