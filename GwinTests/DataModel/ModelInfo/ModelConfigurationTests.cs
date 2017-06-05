using Microsoft.VisualStudio.TestTools.UnitTesting;
using GApp.GwinApp.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using GApp.GwinApp.Application.BAL.GwinApplication;
using GApp.GwinApp.Application.BAL;
using GApp.GwinApp.Application.Presentation.MainForm;
using GenericWinForm.Demo.DAL;

namespace GApp.GwinApp.ModelData.Tests
{
    [TestClass()]
    public class ModelConfigurationTests
    {
        [TestMethod()]
        public void GetAll_Assembly_Contains_EntitiesTest()
        {
            GwinAppInstance.Start(typeof(ModelContext), typeof(GwinBaseBLO<>), new FormApplication(), null);
            List<Assembly> ls_assembly = new ModelConfiguration().GetAll_Assembly_Contains_Entities();
        }
    }
}