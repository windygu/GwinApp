using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Gwin.Application.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Gwin.Application.BAL.Security;
using System.Data.Entity.Validation;
using App.Gwin.Application.BAL.GwinApplication;
using App;
using GenericWinForm.Demo.BAL;
using App.Gwin.Entities.Secrurity.Autorizations;

namespace App.Gwin.Application.BAL.Tests
{
    [TestClass()]
    public class BaseEntityBAOTests
    {
        ModelContext context = null;
        IGwinBaseBLO roleBAO = null;
        [TestInitialize]
        public void initBaseEntityBAOTests()
        {
            GwinApp.Start(typeof(ModelContext), typeof(BaseBLO<>), new Presentation.MainForm.FormApplication(), null);
            context = new ModelContext();
            roleBAO = new BaseBLO<Role>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        [TestMethod()]
        public void BaseEntityBAOTest()
        {
            IGwinBaseBLO bao_without_parameters = new BaseBLO<Role>();
            IGwinBaseBLO bao_withe_context_parameter = new BaseBLO<Role>(context);
        }

        [TestMethod()]
        public void InsertTest()
        {
            int Expected = 1;
            Role role = new Role();
            role.Name = new Entities.MultiLanguage.LocalizedString() { French = "Role1" };
            IGwinBaseBLO service = new BaseBLO<Role>();
            int Actuel = service.Save(role);
            Assert.AreEqual(Expected, Actuel);
        }

        [TestMethod()]
        public void ApplyBusinessRolesAfterValuesChangedTest()
        {
            string Expected = "ROLE1";

            Role role = new Role();
            role.Name = new Entities.MultiLanguage.LocalizedString() { Current = "Role1"};
            GwinBaseBLO<Role> roleBAO = new RoleBAO();
            // Polymorphism not working for a call from a generic class in C#
             roleBAO.ApplyBusinessRolesAfterValuesChanged(nameof(role.Name), role);

            string Actuel = role.Name.Current;
            Assert.AreEqual(Expected, Actuel);
        }

        [TestMethod()]
        public void SaveTest()
        {
            int Expected = 1;
            Role role = new Role();
            role.Name = new Entities.MultiLanguage.LocalizedString() { Current = "Role1" };
            IGwinBaseBLO service = new BaseBLO<Role>();
            int Actuel = service.Save(role);
            Assert.AreEqual(Expected, Actuel);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            int Expected = 1;
            Role role = new Role();
            role.Name = new Entities.MultiLanguage.LocalizedString() { Current = "Role1" };
            IGwinBaseBLO service = new BaseBLO<Role>();
            service.Save(role);
            int Actuel = service.Delete(role);
            Assert.AreEqual(Expected, Actuel);
        }


        [TestMethod()]
        public void GetAllTest()
        {
            roleBAO.GetAll();
        }



        [TestMethod()]
        public void GetByIDTest()
        {
            Role role = new Role();
            role.Name = new Entities.MultiLanguage.LocalizedString() { Current = "Role1" };
            GwinBaseBLO<Role> service = new BaseBLO<Role>();
            service.Save(role);
            Role Actuel = service.GetByID(role.Id)  ;
            Role Expected = role;
            Assert.AreEqual(Expected.Id, Actuel.Id);
        }

        [TestMethod()]
        public void GetBaseEntityByIDTest()
        {
            Role role = new Role();
            role.Name = new Entities.MultiLanguage.LocalizedString() { Current = "Role1" };
            IGwinBaseBLO service = new BaseBLO<Role>();
            service.Save(role);
            Role Actuel = service.GetBaseEntityByID(role.Id) as Role;
            Role Expected = role;
            Assert.AreEqual(Expected.Id, Actuel.Id);
           
        }

        [TestMethod()]
        public void DbEntityValidationExceptionTreatmentTest()
        {
           Role role = new Role();
           Assert.AreEqual( roleBAO.Save(role), -1);
        }

        [TestMethod()]
        public void SQLExceptionTreatmentTest()
        {
         
        }

        [TestMethod()]
        public void DbUpdateExceptionTreatmentTest()
        {
          
        }

        [TestMethod()]
        public void CreateEntityInstanceTest()
        {
          
        }

        [TestMethod()]
        public void CreateEntityInstanceByTypeTest()
        {
          
        }

        [TestMethod()]
        public void CreateEntityInstanceByTypeAndContextTest()
        {
          
        }

        [TestMethod()]
        public void DisposeTest()
        {
           
        }
    }
}