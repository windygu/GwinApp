using App.Gwin.Application.Presentation;
using App.Gwin.Application.Presentation.MainForm;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Gwin.Application.BAL.GwinApplication
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

            if (cultureInfo.TwoLetterISOLanguageName == "fr" || cultureInfo.TwoLetterISOLanguageName == "en")
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
