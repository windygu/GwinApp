using App.Gwin.Application.BAL;
using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Shared.AttributesManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Gwin.Fields;

namespace App.Gwin.Components.Manager.Fields.Traitements.Params
{
    public class BaseFieldTraitementParam
    {
        public IGwinBaseBLO EntityBLO { get; set; }

        public BaseEntity Entity { get; set; }

        public ConfigProperty ConfigProperty { get; set; }
        public BaseField BaseField { get;  set; }
    }
}
