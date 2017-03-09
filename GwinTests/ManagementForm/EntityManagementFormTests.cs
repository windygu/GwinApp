using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using App.Gwin.Entities;
using App.Gwin.Application.BAL;
using App.Gwin.Application.Presentation;
using App.Gwin.Application.Presentation.EntityManagement;
using GenericWinForm.Demo.BAL;

namespace App.Gwin.Tests
{
    [TestClass()]
    public class EntityManagementFormTests
    {

        [TestInitialize]
        public void initBaseEntityBAOTests()
        {
            GwinApp.Start(typeof(ModelContext), typeof(BaseBLO<>), new Application.Presentation.MainForm.FormApplication(), null);
          
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
                foreach (var item in db.GetTypesSets())
                {
                    EntityManagementCreator AfficherFormulaire = new EntityManagementCreator(typeof(ModelContext),MdiForm);
                    EntityManagementForm emform = AfficherFormulaire.ShowManagementForm(item);
                    emform.EntityManagementControl.bt_Ajouter_Click(new Button(), null);
                }
            }
        }
    }
}