using App.Gwin.Application.BAL;
using App.Gwin.Entities.Secrurity.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.GwinApplication.BLL.Authentication
{
    public class AuthenticationBLO
    {
        public bool Authentication(string login,string password)
        {

            // Check User password
            User user = CheckUser(login, password);

            if (user == null) return false;
            else
            {
                GwinApp.Instance.user = user;
                return true;
            }
        }

        /// <summary>
        /// Check if User Exist
        /// </summary>
        /// <param name="login">Login </param>
        /// <param name="password">Password </param>
        /// <returns>Existance User or Null</returns>
        private User CheckUser(string login, string password)
        {
            // Create UserBLO Instance
            IGwinBaseBLO userBLO = GwinBaseBLO<User>.CreateBLO_Instance(typeof(User), GwinApp.Instance.TypeBaseBLO);

            Dictionary<string, object> rechercheInfos = new Dictionary<string, object>();
            rechercheInfos.Add(nameof(User.Login), "="+login);
            rechercheInfos.Add(nameof(User.Password), "="+password);

            List<object> resultat = userBLO.Recherche(rechercheInfos);
            if (resultat != null && resultat.Count > 0)
                return resultat[0] as User;
            else
                return null;

        }
    }
}
