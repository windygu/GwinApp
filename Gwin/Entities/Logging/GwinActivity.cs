using App.Gwin.Attributes;
using App.Gwin.Entities.Secrurity.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.Entities.Logging
{
    [GwinEntity(DisplayMember =nameof(BusinessName))]
    public class GwinActivity : BaseEntity
    {

        public String BusinessName;
        public String ActionName;
    }
}
