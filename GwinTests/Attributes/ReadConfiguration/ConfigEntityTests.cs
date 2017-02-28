using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Gwin.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Gwin.Entities.Security;
using App.Gwin.ModelData;

namespace App.Gwin.Attributes.Tests
{
    [TestClass()]
    public class ConfigEntityTests
    {
        [TestMethod()]
        public void ConfigEntityConstructorTest()
        {
            List<Type> ls = new ModelConfiguration().GetAll_Entities_Type();
            foreach (Type item in ls)
            {
                ConfigEntity configEntity = new ConfigEntity(item);
            }
           
             
        }

        [TestMethod()]
        public void CreateConfigEntityTest()
        {
            List<Type> ls = new ModelConfiguration().GetAll_Entities_Type();
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