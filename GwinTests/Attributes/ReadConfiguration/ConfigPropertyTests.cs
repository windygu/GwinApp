using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Shared.AttributesManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Gwin.Attributes;
using GenericWinForm.Demo.Entities;
using System.Reflection;
using App.Gwin.Application.BAL.GwinApplication;
using App.Gwin.Application.Presentation.MainForm;
using App.Gwin;

namespace App.Shared.AttributesManager.Tests
{
    [TestClass()]
    public class ConfigPropertyTests
    {

        [TestInitialize]
        public void initBaseEntityBAOTests()
        {
            GwinApp.Start(typeof(ModelContext), typeof(BaseBLO<>), new FormApplication(), null);
        }

        [TestMethod()]
        public void ConfigProperty_of_MinimumConfiguration_entity_Test()
        {
            ConfigEntity ConfigEntity = ConfigEntity.CreateConfigEntity(typeof(MinimumConfiguration_Loalizable_Entity));

            PropertyInfo PropertyInfoName = typeof(MinimumConfiguration_Loalizable_Entity).GetProperty("StingField");
            ConfigProperty ConfigProperty = new ConfigProperty(PropertyInfoName, ConfigEntity);
            Assert.IsNotNull(ConfigProperty.DisplayProperty.Titre);
            Assert.AreNotEqual(ConfigProperty.DisplayProperty.Titre,String.Empty);

        }
    }
}