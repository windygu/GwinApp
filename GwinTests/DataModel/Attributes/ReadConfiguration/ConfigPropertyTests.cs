using Microsoft.VisualStudio.TestTools.UnitTesting;
using GApp.Shared.AttributesManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GApp.GwinApp.Attributes;
using GenericWinForm.Demo.Entities;
using System.Reflection;
using GApp.GwinApp.Application.BAL.GwinApplication;
using GApp.GwinApp.Application.Presentation.MainForm;
using GApp.GwinApp;
using GenericWinForm.Demo.BAL;
using GenericWinForm.Demo.DAL;
using GenericWinForm.Demo.Entities.ProjectManager;

namespace GApp.Shared.AttributesManager.Tests
{
    [TestClass()]
    public class ConfigPropertyTests
    {

        /// <summary>
        /// Create GwinApp
        /// </summary>
        [TestInitialize]
        public void initBaseEntityBAOTests()
        {
            GwinAppInstance.Start(typeof(ModelContext), typeof(BaseBLO<>), new FormApplication(), null);
        }

        /// <summary>
        /// Create ConfigProperty instance of Minimum Configuration Entity
        /// </summary>
        [TestMethod()]
        public void ConfigProperty_of_AllField_Test()
        {
            ConfigEntity ConfigEntity = ConfigEntity.CreateConfigEntity(typeof(TaskProject));

            foreach (PropertyInfo PropertyInfoName in typeof(TaskProject).GetProperties())
            {
                ConfigProperty ConfigProperty = new ConfigProperty(PropertyInfoName, ConfigEntity);
                Assert.IsNotNull(ConfigProperty.DisplayProperty.Title);
                Assert.AreNotEqual(ConfigProperty.DisplayProperty.Title, String.Empty);
            }
           

        }
 
    }
}