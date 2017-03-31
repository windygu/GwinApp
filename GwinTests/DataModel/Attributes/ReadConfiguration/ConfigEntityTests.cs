using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Gwin.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Gwin.ModelData;
using GenericWinForm.Demo.BAL;
using App.Gwin.Entities.Secrurity.Autorizations;
using GenericWinForm.Demo.DAL;

namespace App.Gwin.Attributes.Tests
{
    [TestClass()]
    public class ConfigEntityTests
    {

        [TestInitialize]
        public void GwinAppStart()
        {
            GwinApp.Start(typeof(ModelContext), typeof(BaseBLO<>), new Application.Presentation.MainForm.FormApplication(), null);
           

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