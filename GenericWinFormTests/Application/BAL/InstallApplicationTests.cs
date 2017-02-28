using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.WinForm.Application.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.Application.BAL.Tests
{
    [TestClass()]
    public class InstallApplicationTests
    {
        [TestMethod()]
        public void InstallApplicationConstructorTest()
        {
            InstallApplicationGwinBLO InstallApplication = new InstallApplicationGwinBLO(typeof(ModelContext));
        }

        [TestMethod()]
        public void InstallTest()
        {
            InstallApplicationGwinBLO InstallApplication = new InstallApplicationGwinBLO(typeof(ModelContext));
            InstallApplication.Install();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            InstallApplicationGwinBLO InstallApplication = new InstallApplicationGwinBLO(typeof(ModelContext));
            InstallApplication.Update();
        }
    }
}