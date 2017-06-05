using Microsoft.VisualStudio.TestTools.UnitTesting;
using GApp.GwinApp.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GApp.GwinApp.ModelData;
using GenericWinForm.Demo.BAL;
using GApp.GwinApp.Entities.Secrurity.Autorizations;
using GenericWinForm.Demo.DAL;

namespace GApp.GwinApp.Attributes.Tests
{
    [TestClass()]
    public class ConfigEntityTests
    {

        [TestInitialize]
        public void GwinAppStart()
        {
            GwinAppInstance.Start(typeof(ModelContext), typeof(BaseBLO<>), new Application.Presentation.MainForm.FormApplication(), null);
           

        }


        [TestMethod()]
        public void ConfigEntityConstructorTest()
        {
            List<Type> ls = new ModelConfiguration().GetAll_Entities_Type();
            foreach (Type item in ls)
            {
                ConfigEntity configEntity = ConfigEntity.CreateConfigEntity(item);
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