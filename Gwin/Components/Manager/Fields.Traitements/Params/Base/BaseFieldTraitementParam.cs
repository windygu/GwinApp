using GApp.GwinApp.Application.BAL;
using GApp.GwinApp.Attributes;
using GApp.GwinApp.Entities;
using GApp.Shared.AttributesManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GApp.GwinApp.Fields;

namespace GApp.GwinApp.Components.Manager.Fields.Traitements.Params
{
    public class BaseFieldTraitementParam
    {
        public IGwinBaseBLO EntityBLO { get; set; }

        public BaseEntity Entity { get; set; }

        public ConfigProperty ConfigProperty { get; set; }
        public BaseField BaseField { get;  set; }
    }
}
