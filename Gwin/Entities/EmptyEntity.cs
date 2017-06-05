using GApp.GwinApp.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApp.GwinApp.Entities
{
    [GwinEntity(DisplayMember = "Id")]
    public class EmptyEntity : BaseEntity
    {
        public override string ToString()
        {
            return "";
        }
    }
}
