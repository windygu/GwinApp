using App.Gwin.Application.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin
{
    public partial class GwinApp
    {
       
        /// <summary>
        /// Update Gwin Tables, it must be executed after Model configuration change
        /// It can be used befor Gwin Creation.
        /// </summary>
        public static void Update(Type Type_DbContext)
        {
            // Update GwinApplicatio, after  ModelConfiguration changes
            InstallApplicationGwinBLO installApplication = new InstallApplicationGwinBLO(Type_DbContext);
            installApplication.Update();
        }
     
    }
}
