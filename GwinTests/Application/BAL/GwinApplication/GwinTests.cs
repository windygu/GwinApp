using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Gwin.Application.BAL.GwinApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.Application.BAL.GwinApplication.Tests
{
    [TestClass()]
    public class GwinTests
    {
        [TestInitialize]
        public void Init()
        {
            GwinApp.Start(typeof(ModelContext), typeof(BaseBLO<>), new Presentation.MainForm.FormApplication(), null);
        }

        [TestMethod()]
        public void Update_Gwin_TableTest()
        {
            GwinApp.Update();
        }
    }
}