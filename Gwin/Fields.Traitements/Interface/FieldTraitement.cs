using App.Gwin.Exceptions.Gwin;
using App.Shared.AttributesManager;
using System;
using System.Reflection;

namespace App.Gwin.FieldsTraitements
{
    public class FieldTraitement
    {
        /// <summary>
        /// Create Instance of FieldTraitement 
        /// </summary>
        /// <param name="configProperty">Config Property instance</param>
        /// <returns>The FieldTraitement Instance</returns>
        public static IFieldTraitements CreateInstance(ConfigProperty configProperty)
        {
            
            // Get TypeFieldTraitement
            string field_nature = configProperty.FieldNature.ToString();
            Assembly assembly = typeof(StringFieldTraitement).Assembly;
            string TypeFieldTraitement_Name = nameof(App) + "." + nameof(App.Gwin) + "." + nameof(App.Gwin.FieldsTraitements) + "." + field_nature + nameof(FieldTraitement);
            Type TypeFieldTraitement = assembly.GetType(TypeFieldTraitement_Name);
            if (TypeFieldTraitement == null) throw new GwinException("The class " + TypeFieldTraitement_Name + " not exist ");

            // Create FieldTraitement Instance
            IFieldTraitements fieldTraitement = (IFieldTraitements)Activator.CreateInstance(TypeFieldTraitement);
            return fieldTraitement;

        }
    }
}