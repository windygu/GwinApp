using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Shared.AttributesManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.WinForm.Attributes;
using GenericWinForm.Demo.Entities;
using System.Reflection;
using App.WinForm.Application.BAL.GwinApplication;
using App.WinForm.Application.Presentation.MainForm;

namespace App.Shared.AttributesManager.Tests
{
    [TestClass()]
    public class ConfigPropertyTests
    {

        [TestInitialize]
        public void initBaseEntityBAOTests()
        {
            Gwin.Start(typeof(ModelContext), typeof(BaseBLO<>), new FormApplication(), null);
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