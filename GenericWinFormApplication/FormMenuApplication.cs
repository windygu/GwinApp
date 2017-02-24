using App;
using App.WinForm.Application;
using App.WinForm.Application.BAL;
using App.WinForm.Application.Presentation;
using App.WinForm.Application.Security;
using App.WinForm.Entities;
using App.WinForm.Entities.Application;
using App.WinForm.Entities.Authentication;
using App.WinForm.Forms.FormMenu;
using App.WinFrom.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
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
            // Default User 
            User user = new User();
            user.Name = "ES-SARRAJ";
            user.FirstName = "Fouad";

            // Start Application Session
            GWinApp.Start(new Session(this, user, CultureInfo.CreateSpecificCulture("fr")));

            // Update Menu Table from ModelConfiguation
            InstallApplication installApplication = new InstallApplication(typeof(ModelContext));
            installApplication.Update();

            // Reload : to apply language configuration
            Reload();
        }
        public override void Reload()
        {
            this.Controls.Clear();
            base.InitializeForm();
            InitializeComponent();
            
            showManagementForm = new ShowEntityManagementForm(new BaseBAO<BaseEntity>(), this);
            new ConfigMenuApplication(new BaseBAO<MenuItemApplication>(), this);
        }


    }
}
