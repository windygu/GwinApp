using Microsoft.VisualStudio.TestTools.UnitTesting;
using GApp.GwinApp.Application.Presentation.MainForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericWinForm.Demo.BAL;
using GenericWinForm.Demo.DAL;

namespace GApp.GwinApp.Application.Presentation.MainForm.Tests
{
    [TestClass()]
    public class CreateApplicationMenuTests
    {
        [TestInitialize]
        public void GwinAppStart()
        {
            GwinAppInstance.Start(typeof(ModelContext), typeof(BaseBLO<>), new FormApplication(), null);
            
        }

        [TestMethod()]
        public void CreateApplicationMenuTest()
        {
            CreateApplicationMenu CreateApplicationMenu = new CreateApplicationMenu(GwinAppInstance.Instance.FormApplication);
        }
    }
}