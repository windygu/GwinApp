﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericWinForm.Demo.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Gwin.Application.BAL;
using App.Gwin.Entities;
using GenericWinForm.Demo.Entities;
using App;
using App.Gwin;
using static System.Net.Mime.MediaTypeNames;
using App.Gwin.Application.Presentation.MainForm;

namespace GenericWinForm.Demo.BAL.Tests
{
    [TestClass()]
    public class Entity_MiniConfigBLOTests
    {
        [TestInitialize]
        public void GwinAppStart()
        {
            GwinApp.Start(typeof(ModelContext), typeof(BaseBLO<>), new FormApplication(), null);
           
        }

        [TestMethod()]
        public void ApplyBusinessRolesAfterValuesChangedTest()
        {
            TaskProject EntityMiniConfig = new TaskProject();
            EntityMiniConfig.Title = "Hello";
            // Create entityMinConfigBLO dynamicly
            IBaseBLO entityMinConfigBLO = BaseEntityBLO<BaseEntity>.CreateBLO_Instance(typeof(TaskProject), typeof(BaseBLO<>));
            entityMinConfigBLO.ApplyBusinessRolesAfterValuesChanged(nameof(TaskProject.Title), EntityMiniConfig);

            Assert.AreEqual(EntityMiniConfig.Title, "HELLO");

        }
    }
}