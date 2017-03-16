
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Gwin.Application.Presentation
{
    public class BaseForm : Form , IBaseForm
    {
        /// <summary>
        /// Reload the form after language change
        /// </summary>
       public virtual void Reload() { } 
    }
}
