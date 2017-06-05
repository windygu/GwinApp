using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GApp.Shared.AttributesManager;

namespace GApp.GwinApp.Components.Manager.Fields.Traitements.Params
{
    public class CreateFieldColumns_In_EntityDataGrid : BaseFieldTraitementParam
    {
        public DataGridViewColumn Column { get;  set; }
    }
}
