using App.Gwin.Application;
using App.Gwin.Application.BAL;
using App.Gwin.Attributes;
using App.Gwin.Entities.Application;
using App.Gwin.Entities.Persons;
using App.Gwin.Entities.Secrurity.Autorizations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin.Entities.Secrurity.Authentication
{
    [GwinEntity(Localizable = true, isMaleName = true, DisplayMember = "Login")]
    [Menu(Group = nameof(MenuItemApplication.ParentsMenuItem.Configuration))]
    public class User : Person
    {

        /// <summary>
        /// Users Categories
        /// </summary>
        public enum Users
        {
            Guest,
            Root,
            Admin,
            User
        }

        public User() : base()
        {

        }

        #region BLO
        /// <summary>
        /// Check access permition
        /// </summary>
        /// <param name="BusinessEntity"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public Boolean HasAccess(string BusinessEntity, string action)
        {
            if (this.Roles == null) return false;
            if (this.Roles.Any(r => r.Reference == nameof(Role.Roles.Root))) return true;
            foreach (Role role in this.Roles)
            {
                foreach (Authorization authorization in role.Authorizations)
                {
                    if (authorization.BusinessEntity == BusinessEntity)
                        if (authorization.ActionsNames != null && authorization.ActionsNames.Count > 0)
                        {
                            if(action == "Any") return true;
                            if (authorization.ActionsNames.Contains(action))
                                return true;
                        }
                        else // Has All Actions 
                        {

                            return true;
                        }


                }
            }
            return false;
        }

        /// <summary>
        /// Check if user have acces to Entity
        /// </summary>
        /// <param name="TypeOfEntity">Type of Entity</param>
        /// <returns>Persmission </returns>
        public Boolean HasAccess(Type TypeOfEntity)
        {
           return this.HasAccess(TypeOfEntity.FullName, "Any");
        }

        /// <summary>
        /// Check user if have one of Roles list
        /// </summary>
        /// <param name="roles">List of Role to check</param>
        public bool HasOneOfRoles(List<Role> roles)
        {
            if (roles == null || this.Roles == null) return false;
            return roles.Any(r => this.Roles.Contains(r));
        }

        /// <summary>
        ///  Create Guest User
        /// </summary>
        /// <returns></returns>
        public static User CreateGuestUser()
        {
            User guest = new User();
            guest.LastName.Current = nameof(User.Users.Guest);
            guest.Reference = nameof(User.Users.Guest);
            guest.Roles = new List<Role>();

            Role RoleGuest = new Role() ;
            RoleGuest.Reference = nameof(Role.Roles.Guest);
            RoleGuest.Authorizations = new List<Authorization>();

            // Add Autorization of UserBLO to GuestUser
            Authorization UserAutorization = new Authorization();
            RoleGuest.Authorizations.Add(UserAutorization);
            UserAutorization.BusinessEntity = typeof(User).FullName;
            UserAutorization.ActionsNames = new List<string>();
            UserAutorization.ActionsNames.Add(nameof(IGwinBaseBLO.Recherche));
            

            guest.Roles.Add(RoleGuest);

            return guest;
        }

        /// <summary>
        ///  Create Guest User
        /// </summary>
        /// <returns></returns>
        public static User CreateRootUser()
        {
            User root = new User();
            root.LastName.Current = nameof(User.Users.Root);
            root.Reference = nameof(User.Users.Root);
            root.Roles = new List<Role>();
 
            return root;
        }
        #endregion

        // Authentification
        // La création d'un index dans la classe Utilisateur
        // créer un index pour chaque classe fille comme 
        // la classe Stagiaire et Formateur
        // ce qui générer une exéception lors de la Migration automatique 
        // de la base de donénes 
        // parceque les tous les index des tables prend le même nom
        // comme solution il faut nommer l'index selon le type de la classe
        // [Index("LoginIndex"  , IsUnique = true)]
        //[StringLength(450)]

        [DisplayProperty]
        [EntryForm(GroupeBox = "authentication")]
        [StringLength(255)]
        [Index("IX_Login", 1, IsUnique = true)]
        public string Login { set; get; }

        [DisplayProperty]
        [EntryForm(GroupeBox = "authentication")]
        public string Password { set; get; }

        


        [EntryForm(GroupeBox = "authentication")]
        public GwinApp.Languages Language { set; get; }

        [EntryForm(GroupeBox = "authentication")]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection)]
        public virtual List<Role> Roles { set; get; }



    }
}
