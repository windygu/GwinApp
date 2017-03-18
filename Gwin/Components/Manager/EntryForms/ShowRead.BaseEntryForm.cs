using App.Shared.AttributesManager;
using App.Gwin.Attributes;
using App.Gwin.Fields;
using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using App.Gwin.Entities.MultiLanguage;
using App.Gwin.Components.Manager.Fields.Traitements.Params;
using App.Gwin.FieldsTraitements;
using App.Gwin.Exceptions.Gwin;

namespace App.Gwin
{
    /// <summary>
    /// Shwo and Read Entity
    /// </summary>
    public partial class BaseEntryForm
    {

        public virtual void ShowEntity()
        {
            this.ShowEntity(null);
        }
        /// <summary>
        /// Affiher l'entité dans le formulaire avec 
        /// les valeurs initiaux de l'objet
        /// et les initiaux de filtre avec la priéorité pour le filtre
        /// </summary>
        public virtual void ShowEntity(Dictionary<string, object> CritereRechercheFiltre)
        {
            // Generate the the form if is note generated
            CreateFieldIfNotGenerated();

            // début de la phase d'initialisation, pour ne pas lancer les evénement 
            // de changement des valeurs des contôle
            isStepInitializingValues = true;
            BaseEntity entity = this.Entity;
            Type typeEntity = this.EntityBLO.TypeEntity;
            foreach (PropertyInfo item in ListeChampsFormulaire())
            {
                ConfigProperty configProperty = new ConfigProperty(item, this.ConfigEntity);
                // Param
                WriteEntity_To_EntryForm_Param param = new WriteEntity_To_EntryForm_Param();
                param.Entity = this.Entity;
                param.ConfigProperty = configProperty;
                param.CritereRechercheFiltre = CritereRechercheFiltre;
                param.FromContainer = ConteneurFormulaire;
                // Get FieldTraitement Type
                IFieldTraitements fieldTraitement = BaseFieldTraitement.CreateInstance(configProperty);
                // Invok Create Field Method
                fieldTraitement.ShowEntity_To_EntryForm(param);
            }
            // Fin de la phase d'initialisaiton
            this.isStepInitializingValues = false;
        }

        /// <summary>
        /// Set Values to Entity
        /// </summary>
        public virtual void ReadEntity()
        {
            foreach (PropertyInfo item in ListeChampsFormulaire())
            {
                ConfigProperty ConfigProperty = new ConfigProperty(item, this.ConfigEntity);
                // Find Field
                BaseField baseField = null;
                if (ConfigProperty.EntryForm?.TabPage == true)
                {
                    Control[] recherche = this.tabControlForm.Controls.Find(item.Name, true);
                    if (recherche.Count() > 0)
                        baseField = (BaseField)recherche.First();
                    else
                        throw new FieldNotExistInFormException();
                }
                else
                {
                    Control[] recherche = this.ConteneurFormulaire.Controls.Find(item.Name, true);
                    if (recherche.Count() > 0)
                    {
                        baseField = (BaseField)recherche.First();
                    }
                    else
                        throw new FieldNotExistInFormException();
                }
                // Params
                BaseFieldTraitementParam param = new BaseFieldTraitementParam();
                param.ConfigProperty = ConfigProperty;
                param.Entity = this.Entity;
                param.BaseField = baseField;
                param.EntityBLO = this.EntityBLO;
                // Get FieldTraitement Type
                IFieldTraitements fieldTraitement = BaseFieldTraitement.CreateInstance(param.ConfigProperty);
                object value = fieldTraitement.ConvertValue(param);
                param.Entity.GetType().GetProperty(param.ConfigProperty.PropertyInfo.Name).SetValue(param.Entity, value);
            }
        }
    }
}
