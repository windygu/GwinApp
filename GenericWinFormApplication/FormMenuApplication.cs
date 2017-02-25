using App;
using App.WinForm.Application.BAL.GwinApplication;
using App.WinForm.Application.Presentation.EntityManagement;
using App.WinForm.Application.Presentation.MainForm;
using App.WinForm.Entities;
using App.WinForm.Entities.Application;
using App.WinForm.Entities.Authentication;
using System;

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
            // Application User
            User user = new User();
            user.Language = Gwin.Languages.fr;

            // Start Gwin Application
            Gwin.Start(typeof(ModelContext), typeof(BaseBAO<>),this, user);
        }

        /// <summary>
        /// Reload the form after language change
        /// </summary>
        public override void Reload()
        {
            this.Controls.Clear();
            base.InitializeForm();
            InitializeComponent();
        }


    }
}
