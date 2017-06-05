using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericWinForm.Demo.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GApp.GwinApp.Application.BAL;
using GApp.GwinApp.Entities;
using GenericWinForm.Demo.Entities;
using GApp;
using GApp.GwinApp;
using static System.Net.Mime.MediaTypeNames;
using GApp.GwinApp.Application.Presentation.MainForm;
using GenericWinForm.Demo.DAL;
using GenericWinForm.Demo.Entities.ProjectManager;

namespace GenericWinForm.Demo.BAL.Tests
{
    [TestClass()]
    public class Entity_MiniConfigBLOTests
    {
        [TestInitialize]
        public void GwinAppStart()
        {
            GwinAppInstance.Start(typeof(ModelContext), typeof(BaseBLO<>), new FormApplication(), null);
           
        }

        [TestMethod()]
        public void ApplyBusinessRolesAfterValuesChangedTest()
        {
            TaskProject EntityMiniConfig = new TaskProject();
            EntityMiniConfig.Title.Current = "Hello";
            // Create entityMinConfigBLO dynamicly
            IGwinBaseBLO entityMinConfigBLO = GwinBaseBLO<BaseEntity>.CreateBLO_Instance(typeof(TaskProject), typeof(BaseBLO<>));
            entityMinConfigBLO.ApplyBusinessRolesAfterValuesChanged(nameof(TaskProject.Title), EntityMiniConfig);

            Assert.AreEqual(EntityMiniConfig.Title.Current, "HELLO");

        }
    }
}