using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Gwin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Gwin.Attributes;
using GenericWinForm.Demo.Entities;
using App.Gwin.Application.BAL;
using GenericWinForm.Demo.BAL;
using App.Gwin.Application.Presentation.MainForm;
using App.Gwin.Entities;
using App.Gwin.Exceptions.Gwin;

namespace App.Gwin.Tests
{
    [TestClass()]
    public class BaseEntryFormTests
    {
        ConfigEntity configEntity = null;
        TaskProject Entity = null;
        IBaseBLO entityMiniConfigBLO = null;
        [TestInitialize]
        public void GwinAppStart()
        {
            GwinApp.Start(typeof(ModelContext), typeof(BaseBLO<>), new FormApplication(), null);
            configEntity = ConfigEntity.CreateConfigEntity(typeof(TaskProject));
            Entity = new TaskProject();
            entityMiniConfigBLO = BaseEntityBLO<BaseEntity>.CreateBLO_Instance(typeof(TaskProject), typeof(BaseBLO<>));
        }

        [TestMethod()]
        [ExpectedException(typeof(GwinUsageModeException))]
        public void DefaultConstructor_BaseEntryFormTest()
        {
            BaseEntryForm BaseEntryForm = new BaseEntryForm();
        }

        [TestMethod()]
        [ExpectedException(typeof(GwinNullParameterException))]
        public void Create_BaseEntryForm_with_null_parameterTest()
        {
            BaseEntryForm BaseEntryForm = new BaseEntryForm(null);

        }

        [TestMethod()]
        public void Create_With_EntityBLO_Instance_BaseEntryFormTest()
        {
            BaseEntryForm BaseEntryForm = new BaseEntryForm(this.entityMiniConfigBLO);
        }

        [TestMethod()]
        public void Create_With_FilterValues_Instance_BaseEntryFormTest()
        {
           // [ToDo]
        }

        [TestMethod()]
        public void Add_BaseEntryFormTest()
        {
            // [ToDo]
        }

        [TestMethod()]
        public void Cancel_BaseEntryFormTest()
        {
            // [ToDo]
        }
 
    }
}