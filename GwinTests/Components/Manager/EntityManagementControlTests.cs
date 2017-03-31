using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Gwin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericWinForm.Demo.BAL;
using App.Gwin.Application.Presentation.MainForm;
using App.Gwin.Application.Presentation;
using App.Gwin.Application.Presentation.EntityManagement;
using System.Windows.Forms;
using App.Gwin.DataModel.ModelInfo;
using GenericWinForm.Demo.DAL;

namespace App.Gwin.Tests
{
    [TestClass()]
    public class EntityManagementControlTests
    {


        [TestInitialize]
        public void initBaseEntityBAOTests()
        {
            GwinApp.Start(typeof(ModelContext), typeof(BaseBLO<>), new FormApplication(), null);
        }

        /// <summary>
        ///  Test la generation de tous les formilaire de l'application
        /// </summary>
        [TestMethod()]
        public void GenerateFormTest()
        {
            BaseForm MdiForm = new BaseForm();
            MdiForm.IsMdiContainer = true;

            // Tester tous les bouttons ajouter 
            using (ModelContext db = new ModelContext())
            {
                foreach (var item in new GwinEntitiesManager().GetAll_Entities_Type())
                {
                    CreateAndShowManagerFormHelper AfficherFormulaire = new CreateAndShowManagerFormHelper(typeof(ModelContext), MdiForm);
                    ManagerForm emform = AfficherFormulaire.ShowManagerForm(item);
                    emform.managerFormControl.AddEntity_Click(new Button(), null);
                }
            }
        }
 
    }
}