using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Shared.AttributesManager;

namespace App.Gwin.Fields.Traitements.Params
{
    public class CreateFieldColumns_In_EntityDataGrid
    {
        public DataGridViewColumn Column { get;  set; }
        public ConfigProperty ConfigProperty { get; internal set; }
    }
}
