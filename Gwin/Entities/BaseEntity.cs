using App.Gwin.Attributes;
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
    [DisplayEntity(DisplayMember ="Id")]
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
        [DataGrid(WidthColonne = 50)]
        public int Ordre { set; get; }

        public DateTime DateCreation { get; set; }


        [DisplayProperty(isInGlossary = true)]
        [DataGrid(Ordre = 1000, WidthColonne = 110)]
        public DateTime DateModification { get; set; }
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
            DisplayEntityAttribute AffichageClasse = (DisplayEntityAttribute)this.GetType().GetCustomAttributes(typeof(DisplayEntityAttribute), true)[0];
            object value = this.GetType().GetProperty(AffichageClasse.DisplayMember).GetValue(this);
            if (value != null)  Titre = value.ToString();
            if (Titre == string.Empty) return AffichageClasse.SingularName;
            else return Titre;
        }
        #endregion

        #region Annotation

      
        ///// <summary>
        ///// Trouver l'annotation AffichageClasseAttribute
        ///// </summary>
        ///// <param name="propertyType"></param>
        ///// <returns></returns>
        //public static DisplayEntityAttribute GetAffichageClasseAttribute(Type propertyType)
        //{
        //    Attribute attribute = propertyType.GetCustomAttribute(typeof(DisplayEntityAttribute));
        //    if (attribute == null) throw new AnnotationNotExistException(typeof(DisplayEntityAttribute).ToString());
        //    return (DisplayEntityAttribute)attribute;
        //}

        //public DisplayEntityAttribute GetAffichageClasseAttribute()
        //{
        //  return (DisplayEntityAttribute) this.GetType().GetCustomAttributes(typeof(DisplayEntityAttribute),true).First();
        //}

        #endregion
    }
}
