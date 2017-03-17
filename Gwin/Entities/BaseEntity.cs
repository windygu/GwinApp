using App.Gwin.Attributes;
using App.Gwin.Entities.Secrurity.Authentication;
using App.Gwin.Exceptions.Gwin;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace App.Gwin.Entities
{
    /// <summary>
    /// La classe de Base de toutes les entity
    /// </summary>
    public  class BaseEntity : IBaseEntity
    {

        #region constructor
        public BaseEntity()
        {
            // Problème de EF avec DateTime
            this.DateCreation = DateTime.Now;
            this.DateModification = DateTime.Now;
        }
        #endregion

        #region Proerties
        [Key]
        public Int64 Id { get; set; }

        [DisplayProperty(isInGlossary = true)]
       
        public int Ordre { set; get; }

        public DateTime DateCreation { get; set; }


        [DisplayProperty(isInGlossary = true)]
        [DataGrid(Ordre = 1000, WidthColonne = 110)]
        public DateTime DateModification { get; set; }

        ///// <summary>
        ///// The uset that create the Entity : The Owner
        ///// </summary>
        //public virtual User Owner { set; get; }
        #endregion

        #region Equals & ToString

        public override bool Equals(Object obj)
        {
            if (obj == DBNull.Value) return false;
            if (obj == null) return false;
            BaseEntity objet = (BaseEntity)obj;
            
            if (this.Id == objet.Id) return true;
            else return false;
           
        }

        /// <summary>
        /// Généric ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string Titre = "";
            GwinEntityAttribute AffichageClasse = (GwinEntityAttribute)this.GetType().GetCustomAttributes(typeof(GwinEntityAttribute), true)[0];

            // Test if the object has the memeber AffichageClasse.DisplayMember
            if (this.GetType().GetProperty(AffichageClasse.DisplayMember) == null)
                throw new GwinException("The Entity " + this.GetType() + "does not have the membe  : " + AffichageClasse.DisplayMember);

            object value = this.GetType().GetProperty(AffichageClasse.DisplayMember).GetValue(this);
            if (value != null)  Titre = value.ToString();
            if (Titre == string.Empty) return AffichageClasse.SingularName;
            else return Titre;
        }
        #endregion

       
    }
}
