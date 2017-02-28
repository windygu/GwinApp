using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.WinForm.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using App.WinForm.Application.BAL.GwinApplication;
using App.WinForm.Application.BAL;
using App.WinForm.Application.Presentation.MainForm;

namespace App.WinForm.ModelData.Tests
{
    [TestClass()]
    public class ModelConfigurationTests
    {
        [TestMethod()]
        public void GetAll_Assembly_Contains_EntitiesTest()
        {
            Gwin.Start(typeof(ModelContext), typeof(BaseEntityBLO<>), new FormApplication(), null);
            List<Assembly> ls_assembly = new ModelConfiguration().GetAll_Assembly_Contains_Entities();
        }
    }
}