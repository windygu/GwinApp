using App.WinForm.Application.Presentation;
using App.WinForm.Application.Presentation.MainForm;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm.Application.BAL.GwinApplication
{
    public class GwinLanguageBLO
    {
        /// <summary>
        /// Change the cultue of Application
        /// </summary>
        /// <param name="cultureInfo"></param>
        public void ChangeLanguage(CultureInfo cultureInfo, FormApplication formApplication)
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            formApplication.Reload();

            if (cultureInfo.ThreeLetterISOLanguageName == "fr" || cultureInfo.ThreeLetterISOLanguageName == "en")
            {
                formApplication.RightToLeftLayout = false;
                formApplication.RightToLeft = RightToLeft.No;
            }else
            {
                formApplication.RightToLeftLayout = true;
                formApplication.RightToLeft = RightToLeft.Yes;
            }

        }
    }
}
