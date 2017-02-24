using App.WinForm.Application.Presentation;
using App.WinForm.Entities;
using App.WinForm.Entities.Authentication;
using App.WinForm.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm.Application.Security
{
    /// <summary>
    /// 
    /// </summary>
    public class Session
    {
        #region Params
        /// <summary>
        /// MenuForm of Application
        /// </summary>
        public BaseForm ApplicationMenu { set; get; }
        /// <summary>
        /// The connected user
        /// </summary>
        public  User user { set; get; }
        #endregion

        #region Properties
        private CultureInfo cultureInfo;
        /// <summary>
        /// User culture info
        /// </summary>
        public CultureInfo CultureInfo {
            set
            {
                if(cultureInfo != value)
                {
                    cultureInfo = value;
                    Thread.CurrentThread.CurrentCulture = cultureInfo;
                    Thread.CurrentThread.CurrentUICulture = cultureInfo;
                }
            }
            get
            {
                return cultureInfo;
            }
        }
        #endregion

        #region Constructor
        public Session(BaseForm ApplicationMenu, User user,CultureInfo CultureInfo)
        {
            this.ApplicationMenu = ApplicationMenu;
            this.user = user;
            this.CultureInfo = CultureInfo;
        }

        #endregion

        /// <summary>
        /// Change the cultue of Application
        /// </summary>
        /// <param name="cultureInfo"></param>
        public void ChangeLanguage(CultureInfo cultureInfo, FormApplication formApplication)
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            this.cultureInfo = cultureInfo;
            this.ApplicationMenu.Reload();
            if(this.cultureInfo.ThreeLetterISOLanguageName == "fr" || this.cultureInfo.ThreeLetterISOLanguageName == "en")
            {
                formApplication.RightToLeftLayout = false;
                formApplication.RightToLeft = RightToLeft.No;
            }
           
        }
 
    }
}
