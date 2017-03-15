using App;
using GenericWinForm.Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Gwin.Entities;

namespace GenericWinForm.Demo.BAL
{
    /// <summary>
    /// This class must be named as : EntityName + BLO
    /// Withe the same NameSpace of BaseBLO
    /// because it is loaded dynamicly to executed Business Role in Gwin Application
    /// </summary>
    public class TaskProjectBLO : BaseBLO<TaskProject>
    {
        public override void ApplyBusinessRolesAfterValuesChanged(object sender, BaseEntity entity)
        {
            TaskProject entityMiniConfig = entity as TaskProject;
            string field_name = (string)sender;

            switch (field_name)
            {
                //[BL] the name mut be UperCase
                case nameof(TaskProject.Title):
                    {
                        entityMiniConfig.Title = entityMiniConfig.Title.ToUpper();
                    }
                    break;
            }
        }
    }
}
