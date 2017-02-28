using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using App.WinForm.Entities;
using App.WinForm.Application.BAL;
using App.WinForm.Application.Presentation;
using App.WinForm.Application.Presentation.EntityManagement;

namespace App.WinForm.Tests
{
    [TestClass()]
    public class EntityManagementFormTests
    {

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