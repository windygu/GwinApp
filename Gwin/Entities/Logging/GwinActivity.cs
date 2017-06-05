using GApp.GwinApp.Attributes;
using GApp.GwinApp.Entities.Secrurity.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApp.GwinApp.Entities.Logging
{
    [GwinEntity(DisplayMember =nameof(BusinessName))]
    public class GwinActivity : BaseEntity
    {

        public String BusinessName;
        public String ActionName;
    }
}
