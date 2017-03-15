using App.Shared.AttributesManager;
using App.Gwin.Attributes;
using App.Gwin.Fields;
using App.Gwin.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Gwin.Entities.MultiLanguage;
using App.Gwin.Application.BAL;

namespace App.Gwin
{
    /// <summary>
    /// Read from Interface to Entity
    /// </summary>
    public partial class BaseEntryForm
    {
        /// <summary>
        /// Lire les informations du formulaire vers l'Entity
        /// </summary>
        public virtual void ReadFormToEntity()
        {
            BaseEntity entity = this.Entity;
            Type typeEntity = this.EntityBLO.TypeEntity;
            foreach (PropertyInfo item in ListeChampsFormulaire())
            {
                
                ConfigProperty configProperty = new ConfigProperty(item, this.ConfigEntity);

                Type typePropriete = item.PropertyType;
                string NomPropriete = item.Name;

                #region Read :String Field without DataSource
                if (typePropriete.Name == "String" && configProperty.DataSource == null)
                {
                    string value = "";
                    if (this.AutoGenerateField)
                    {
                        BaseField baseField = this.FindGenerateField(item.Name);
                        value = baseField.Value.ToString();
                    }
                    else
                    {
                        TextBox txtBox = (TextBox)this.FindPersonelField(item.Name, "TextBox");
                        value = txtBox.Text;
                    }
                    typeEntity.GetProperty(NomPropriete).SetValue(entity, value);
                }
                #endregion

                #region Read :String Field With DataSource
                if (typePropriete.Name == "String" && configProperty.DataSource != null)
                {
                    string value = "";
                    if (this.AutoGenerateField)
                    {
                        BaseField baseField = this.FindGenerateField(item.Name);
                        value = baseField.Value.ToString();
                    }
                    else
                    {
                        ComboBox txtBox = (ComboBox)this.FindPersonelField(item.Name, "ComboBox");
                        value = txtBox.SelectedItem.ToString() ;
                    }
                    typeEntity.GetProperty(NomPropriete).SetValue(entity, value);
                }
                #endregion

                #region Read : Int32 Field
                if (item.PropertyType.Name == "Int32")
                {
                    int Nombre = 0;
                    if (this.AutoGenerateField)
                    {
                        BaseField baseField = this.FindGenerateField(item.Name);
                        Nombre = Convert.ToInt32(baseField.Value);
                    }
                    else
                    {
                        TextBox txtBox = (TextBox)this.FindPersonelField(item.Name, "TextBox");
                        if (!int.TryParse(txtBox.Text, out Nombre))
                            MessageBox.Show("Impossible de lire un nombre :" + txtBox.Text);
                    }
                    typeEntity.GetProperty(NomPropriete).SetValue(entity, Nombre);

                }
                #endregion

                #region Read : DateTime Field
                if (typePropriete.Name == "DateTime")
                {
                    DateTime date = DateTime.MinValue;
                    if (this.AutoGenerateField)
                    {
                        BaseField baseField = this.FindGenerateField(item.Name);
                        date = Convert.ToDateTime(baseField.Value);
                    }
                    else
                    {
                        DateTimePicker dateTimePicker = (DateTimePicker)this.FindPersonelField(item.Name, "TextBox");
                        date = dateTimePicker.Value;
                    }
                    typeEntity.GetProperty(NomPropriete).SetValue(entity, date);
                }
                #endregion

                #region Read :Enumeration
                if (item.PropertyType.IsEnum)
                {
                    // Default Enumeration Value
                    var value = Activator.CreateInstance(item.PropertyType);
 
                    if (this.AutoGenerateField)
                    {

                        BaseField baseField = this.FindGenerateField(item.Name);
                        value = baseField.Value;
                    }
                    else
                    {
                        ComboBox txtBox = (ComboBox)this.FindPersonelField(item.Name, "ComboBox");
                        value = txtBox.SelectedItem.ToString();
                    }
                    typeEntity.GetProperty(NomPropriete).SetValue(entity, value);
                }
                #endregion

                #region Read :LocalizedString 
                if (typePropriete.Name == "LocalizedString")
                {
                    string value = "";
                    if (this.AutoGenerateField)
                    {
                        BaseField baseField = this.FindGenerateField(item.Name);
                        value = baseField.Value.ToString();
                    }
                    else
                    {
                        TextBox txtBox = (TextBox)this.FindPersonelField(item.Name, "TextBox");
                        value = txtBox.Text;
                    }
                    LocalizedString localizedString = (LocalizedString) typeEntity.GetProperty(NomPropriete).GetValue(entity);
                    if (localizedString == null) localizedString = new LocalizedString();
                    localizedString.Current = value;
                    typeEntity.GetProperty(NomPropriete).SetValue(entity, localizedString);
                }
                #endregion

                #region Read : ManyToOne Field
                if (configProperty.Relationship?.Relation == RelationshipAttribute.Relations.ManyToOne)
                {
                    Int64 id;
                    if (this.AutoGenerateField)
                    {
                        BaseField baseField = this.FindGenerateField(item.Name);
                        id = Convert.ToInt64(baseField.Value);
                    }
                    else
                    {
                        ComboBox comboBox = (ComboBox)this.FindPersonelField(item.Name, "ComboBox");
                        id = Convert.ToInt64(comboBox.SelectedValue);

                    }
                    IBaseBLO ServicesEntity = this.EntityBLO.CreateServiceBLOInstanceByTypeEntity(item.PropertyType);
                    BaseEntity ManyToOneEntity = ServicesEntity.GetBaseEntityByID(Convert.ToInt32(id));
                    typeEntity.GetProperty(NomPropriete).SetValue(entity, ManyToOneEntity);
                }
                #endregion

                #region  Read : ManyToMany
                if (configProperty.Relationship?.Relation == RelationshipAttribute.Relations.ManyToMany_Selection)
                {
                    List<BaseEntity> ls = null;
                    if (this.AutoGenerateField)
                    {
                        ManyToManyField manyToManyField = null;
                        if (configProperty.EntryForm?.TabPage == true)
                        {
                           
                            Control[] recherche = this.tabControlForm.Controls.Find(item.Name, true);
                            if (recherche.Count() > 0)
                                manyToManyField = (ManyToManyField)recherche.First();
                            else
                                throw new FieldNotExistInFormException();
                        }else
                        {
                            Control[] recherche = this.ConteneurFormulaire.Controls.Find(item.Name, true);
                            if (recherche.Count() > 0) {
                                manyToManyField = (ManyToManyField)recherche.First();
                            }
                            else
                            throw new FieldNotExistInFormException();
                        }

                        ls = manyToManyField.Value as List<BaseEntity>;
                    }
                    else
                    {
                        ListBox comboBox = (ListBox)this.FindPersonelField(item.Name, "ListBox");
                        ls = comboBox.Items.Cast<BaseEntity>().ToList<BaseEntity>();

                    }

                  
                    IBaseBLO ServicesEntity =  this.EntityBLO.CreateServiceBLOInstanceByTypeEntityAndContext(item.PropertyType.GetGenericArguments()[0], this.EntityBLO.Context);


                    Type TypeListeObjetValeur = typeof(List<>).MakeGenericType(item.PropertyType.GetGenericArguments()[0]);
                    IList ls_valeur = (IList)Activator.CreateInstance(TypeListeObjetValeur);



                    foreach (BaseEntity b in ls)
                    {
                        var entity_valeur = ServicesEntity.GetBaseEntityByID(b.Id);
                        ls_valeur.Add(entity_valeur);

                    }


                    typeEntity.GetProperty(NomPropriete).SetValue(entity, ls_valeur);

                }
                #endregion

            }
        }
    }
}
