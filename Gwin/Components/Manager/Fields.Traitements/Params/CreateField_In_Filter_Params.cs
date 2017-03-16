using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Gwin.Attributes;
using App.Shared.AttributesManager;
using App.Gwin.Application.BAL;

namespace App.Gwin.Fields.Traitements.Params
{
    public class CreateField_In_Filter_Params
    {
        public IGwinBaseBLO BLO { get; internal set; }
        public ConfigEntity ConfigEntity { get; internal set; }
        public ConfigProperty ConfigProperty { get;  set; }
        public Control FilterContainer { get;  set; }
        public Dictionary<string, object> DefaultFilterValues { get; internal set; }
        public Size SizeControl { get;  set; }
        public Size SizeLabel { get;  set; }
        public int TabIndex { get;  set; }
    }
}
