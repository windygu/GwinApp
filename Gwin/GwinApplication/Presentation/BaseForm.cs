
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Gwin.Application.Presentation
{
    public class BaseForm :Form, IBaseForm
    {
        
        List<string> Skins;

        public BaseForm()
        {
            
        }

        /// <summary>
        /// Reload the form after language change
        /// </summary>
       public virtual void Reload() { } 
    }
}
