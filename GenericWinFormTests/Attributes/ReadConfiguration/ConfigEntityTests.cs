using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.WinForm.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.WinForm.Entities.Security;
using App.WinForm.ModelData;

namespace App.WinForm.Attributes.Tests
{
    [TestClass()]
    public class ConfigEntityTests
    {
        [TestMethod()]
        public void ConfigEntityConstructorTest()
        {
            List<Type> ls = new EntitiesModel().GetAll_Entities_Type();
            foreach (Type item in ls)
            {
                ConfigEntity configEntity = new ConfigEntity(item);
            }
           
             
        }

        [TestMethod()]
        public void CreateConfigEntityTest()
        {
            List<Type> ls = new EntitiesModel().GetAll_Entities_Type();
            foreach (Type item in ls)
            {
                ConfigEntity configEntity = ConfigEntity.CreateConfigEntity(item);
            }
        }

        [TestMethod()]
        public void DisposeTest()
        {
            ConfigEntity configEntity = ConfigEntity.CreateConfigEntity(typeof(Role));
            Assert.AreEqual(configEntity.Dispose(), true);
        }
    }
}