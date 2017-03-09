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
using App.Gwin.Fields.Traitements.Params;
using App.Gwin.FieldsTraitements;
using App.Gwin.Exceptions.Gwin;

namespace App.Gwin
{
    /// <summary>
    /// Write from Entity to Interface
    /// </summary>
    public partial class BaseEntryForm
    {

        public virtual void WriteEntityToField()
        {
            this.WriteEntityToField(null);
        }

        /// <summary>
        /// Affiher l'entité dans le formulaire avec 
        /// les valeurs initiaux de l'objet
        /// et les initiaux de filtre avec la priéorité pour le filtre
        /// </summary>
        public virtual void WriteEntityToField(Dictionary<string, object> CritereRechercheFiltre)
        {
            // Generate the the form if is note generated
            CreateFieldIfNotGenerated();

            // début de la phase d'initialisation, pour ne pas lancer les evénement 
            // de changement des valeurs des contôle
            isStepInitializingValues = true;

            BaseEntity entity = this.Entity;
            Type typeEntity = this.Service.TypeEntity;

           

            foreach (PropertyInfo item in ListeChampsFormulaire())
            {

                ConfigProperty configProperty = new ConfigProperty(item, this.ConfigEntity);

                WriteEntity_To_EntryForm_Param param = new WriteEntity_To_EntryForm_Param();
                param.Entity = this.Entity;
                param.ConfigProperty = configProperty;
                param.CritereRechercheFiltre = CritereRechercheFiltre;
                param.FromContainer = ConteneurFormulaire;

                // Get FieldTraitement Type
                IFieldTraitements fieldTraitement = FieldTraitement.CreateInstance(configProperty);

                // Invok Create Field Method
                fieldTraitement.WriteEntity_To_EntryForm(param);
            }
 
            // Fin de la phase d'initialisaiton
            this.isStepInitializingValues = false;
        }
        private Control FindPersonelField(string name, String TypeControl)
        {
            String PossibiliteNomControle1 = char.ToLower(name[0]) + name.Substring(1) + TypeControl;
            Control[] recherche1 = this.ConteneurFormulaire.Controls.Find(PossibiliteNomControle1, true);
            if (recherche1.Count() > 0) return recherche1.First();
            throw new FieldNotExistInFormException();
        }
        /// <summary>
        /// Trouver un controle dans l'interface du formlaire 
        /// </summary>
        /// <param name="name">Le nom de la propriété</param>
        /// <param name="TypeControl">Le type de control qui est en relation avec le type de la propriété</param>
        /// <returns></returns>
        private BaseField FindGenerateField(string name)
        {
            Control[] recherche = this.ConteneurFormulaire.Controls.Find(name, true);
            if (recherche.Count() > 0) return (BaseField)recherche.First();
            throw new FieldNotExistInFormException();
        }




    }
}
