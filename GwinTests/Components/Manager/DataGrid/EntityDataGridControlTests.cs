using Microsoft.VisualStudio.TestTools.UnitTesting;
using GApp.GwinApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericWinForm.Demo.BAL;
using GApp.GwinApp.Application.Presentation.MainForm;
using GApp.GwinApp.Attributes;
using GenericWinForm.Demo.Entities;
using GApp.GwinApp.Application.BAL;
using GApp.GwinApp.Entities;
using GApp.GwinApp.Exceptions.Gwin;
using System.Reflection;
using GenericWinForm.Demo.DAL;
using GenericWinForm.Demo.Entities.ProjectManager;

namespace GApp.GwinApp.Tests
{
    [TestClass()]
    public class EntityDataGridControlTests
    {
        ConfigEntity configEntity = null;
        TaskProject Entity = null;
        IGwinBaseBLO entityMiniConfigBLO = null;
        [TestInitialize]
        public void GwinAppStart()
        {
            GwinAppInstance.Start(typeof(ModelContext), typeof(BaseBLO<>), new FormApplication(), null);
            configEntity = ConfigEntity.CreateConfigEntity(typeof(TaskProject));
            Entity = new TaskProject();
            entityMiniConfigBLO = GwinBaseBLO<BaseEntity>.CreateBLO_Instance(typeof(TaskProject), typeof(BaseBLO<>));
        }


        //[TestMethod()]
        //[ExpectedException(typeof(GwinUsageModeException))]
        //public void Launch_GwinUsageModeException_When_Invok_EntityDataGridControl_Default_CostrucotorTest()
        //{
        //    EntityDataGridControl EntityDataGridControl = new EntityDataGridControl();
        //}

        //[TestMethod()]
        //[ExpectedException(typeof(GwinNullParameterException))]
        //public void Ctrate_Instance_With_NULL_Vlaues_EntityDataGridControlTest1()
        //{
        //    EntityDataGridControl EntityDataGridControl = new EntityDataGridControl(null,null);
        //}

        [TestMethod()]
       
        public void Ctrate_Instance_With_Null_FilterValues_Vlaues_EntityDataGridControlTest1()
        {
            GwinDataGridComponent entityDataGridControl = new GwinDataGridComponent(entityMiniConfigBLO, null);

            // Check Columns
            foreach (PropertyInfo propertyInfo in entityDataGridControl.ShownEntityProperties)
            {
                Assert.AreEqual(entityDataGridControl.GetDataGridViewInstance().Columns.Contains(propertyInfo.Name), true);
            }

            entityDataGridControl.RefreshEntities();
            entityDataGridControl.RefreshEntities(null);
        }

        [TestMethod()]
        public void Edit_Clikc_EntityDataGridControl()
        {
            // [ToDo]
         
        }

        [TestMethod()]
        public void Deete_Clik_EntityDataGridControl()
        {
            // [ToDo]
        }
    }
}