using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GApp.GwinApp.Attributes;
using GApp.Shared.AttributesManager;
using GApp.GwinApp.Application.BAL;

namespace GApp.GwinApp.Components.Manager.Fields.Traitements.Params
{
    public class CreateField_In_Filter_Params : BaseFieldTraitementParam
    {

        public Control FilterContainer { get;  set; }
        public Dictionary<string, object> DefaultFilterValues { get; internal set; }
        public Size SizeControl { get;  set; }
        public Size SizeLabel { get;  set; }
        public int TabIndex { get;  set; }
    }
}
