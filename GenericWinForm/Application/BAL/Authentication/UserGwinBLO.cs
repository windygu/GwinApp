using App.WinForm.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.Application.BAL.Authentication
{
    /// <summary>
    /// User Gwin Business Logic
    /// </summary>
    internal class UserGwinBLO
    {
 
        /// <summary>
        /// Create Guest User
        /// </summary>
        /// <returns></returns>
        public User CreateGuestUser()
        {
            User user = new User();
            user.Name = "Guest";
            return user;
        }
    }
}
