using GApp.GwinApp.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApp.GwinApp.GwinApplication.Themes
{
    public interface IGwinTheme
    {
       void RequiredField(BaseField baseField);
    }
}
