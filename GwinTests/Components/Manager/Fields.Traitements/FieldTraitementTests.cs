using Microsoft.VisualStudio.TestTools.UnitTesting;
using GApp.GwinApp.FieldsTraitements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericWinForm.Demo.Entities;
using System.Reflection;
using System.Drawing;
using GApp.Shared.AttributesManager;
using GApp.GwinApp.Attributes;
using System.Windows.Forms;
using GApp.GwinApp.Application.BAL;
using GApp.GwinApp.Entities;
using GApp.GwinApp.Fields;
using GenericWinForm.Demo.BAL;
using GApp.GwinApp.EntityManagement;
using GenericWinForm.Demo.DAL;
using GenericWinForm.Demo.Entities.ProjectManager;

namespace GApp.GwinApp.FieldsTraitements.Tests
{
    [TestClass()]
    public class FieldTraitementTests
    {
        ConfigEntity configEntity = null;
        TaskProject Entity = null;
        IGwinBaseBLO entityMiniConfigBLO = null;
        [TestInitialize]
        public void GwinAppStart()
        {
            GwinAppInstance.Start(typeof(ModelContext), typeof(BaseBLO<>), new Application.Presentation.MainForm.FormApplication(), null);
            configEntity = ConfigEntity.CreateConfigEntity(typeof(TaskProject));
            Entity = new TaskProject();
            entityMiniConfigBLO = GwinBaseBLO<BaseEntity>.CreateBLO_Instance(typeof(TaskProject), typeof(BaseBLO<>));

        }

        [TestMethod()]
        public void CreateField_In_EntryFormTest()
        {
            BaseEntryForm baseEntryForm = new BaseEntryForm(entityMiniConfigBLO, Entity, new Dictionary<string, object>(), true);
            baseEntryForm.BaseEntryForm_Load(baseEntryForm, null);
             // Load EntityMiniConfigBLO dynamicly
            
            Assert.AreEqual(typeof(TaskProjectBLO), entityMiniConfigBLO.GetUnProxyType());
         
        }

        [TestMethod()]
        public void WriteEntity_To_EntryFormTest()
        {
            BaseEntryForm baseEntryForm = new BaseEntryForm(entityMiniConfigBLO, Entity, new Dictionary<string, object>(), true);
            baseEntryForm.BaseEntryForm_Load(baseEntryForm, null);
            baseEntryForm.ShowEntity();
        }

        [TestMethod()]
        public void CreateField_In_Filter()
        {
            BaseFilterControl filter = new BaseFilterControl(entityMiniConfigBLO);
        }

        [TestMethod()]
        public void GetFieldValue_From_FilterTest()
        {
            BaseFilterControl filter = new BaseFilterControl(entityMiniConfigBLO);
            filter.GetFilterValues();
        }
    }
}