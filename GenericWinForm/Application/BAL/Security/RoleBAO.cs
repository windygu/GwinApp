using App.WinForm.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.WinForm.Entities;
using System.Windows.Forms;

namespace App.WinForm.Application.BAL.Security
{
    /// <summary>
    /// [Bug] this class use TestModelContext and Noye ModelContext of Application
    /// </summary>
    public class RoleBAO : BaseEntityBLO<Role>
    {

        public override void ApplyBusinessRolesAfterValuesChanged(object sender, BaseEntity entity)
        {

            Role role = entity as Role;
            string field_name = (string) sender;

            switch (field_name)
            {
                // Business Role : the role name mut be UperCase
                case nameof(role.Name): 
                    {
                        role.Name = role.Name.ToUpper();
                    }
                    break;
            }
        }
    }
}
