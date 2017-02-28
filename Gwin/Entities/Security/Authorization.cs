using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.Entities.Security
{
    public class Authorization : BaseEntity
    {
        public string Name { set; get; }

        public string Description { set; get; }

        public virtual UserAction Action { set; get; }

        public string Entity { set; get; }

    }
}
