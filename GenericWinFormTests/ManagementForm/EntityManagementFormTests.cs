using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.WinFrom.Menu;
using System.Windows.Forms;
using App.WinForm.Entities;
using App.WinForm.Forms;
using App.WinForm.Application.BAL;

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
            using (TestModelContext db = new TestModelContext())
            {
                foreach (var item in db.GetTypesSets())
                {
                    IBaseBAO service = new BaseEntityBAO<BaseEntity>().CreateEntityInstanceByType(item);
                    ShowEntityManagementForm AfficherFormulaire = new ShowEntityManagementForm(service,MdiForm);
                    EntityManagementForm emform = AfficherFormulaire.AfficherUneGestion(item);
                    emform.EntityManagementControl.bt_Ajouter_Click(new Button(), null);
                }
            }
        }
    }
}