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
            InstallApplication InstallApplication = new InstallApplication(typeof(TestModelContext));
        }

        [TestMethod()]
        public void InstallTest()
        {
            InstallApplication InstallApplication = new InstallApplication(typeof(TestModelContext));
            InstallApplication.Install();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            InstallApplication InstallApplication = new InstallApplication(typeof(TestModelContext));
            InstallApplication.Update();
        }
    }
}