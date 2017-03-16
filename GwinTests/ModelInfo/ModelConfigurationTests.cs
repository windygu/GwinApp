using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Gwin.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using App.Gwin.Application.BAL.GwinApplication;
using App.Gwin.Application.BAL;
using App.Gwin.Application.Presentation.MainForm;

namespace App.Gwin.ModelData.Tests
{
    [TestClass()]
    public class ModelConfigurationTests
    {
        [TestMethod()]
        public void GetAll_Assembly_Contains_EntitiesTest()
        {
            GwinApp.Start(typeof(ModelContext), typeof(GwinBaseBLO<>), new FormApplication(), null);
            List<Assembly> ls_assembly = new ModelConfiguration().GetAll_Assembly_Contains_Entities();
        }
    }
}