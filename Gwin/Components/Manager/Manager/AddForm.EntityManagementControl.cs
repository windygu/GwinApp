using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Gwin
{
    public partial class EntityManagementControl
    {
        #region Formulaire
        /// <summary>
        /// Boutton Ajouter un nouveau entité
        /// </summary>
        public void bt_Ajouter_Click(object sender, EventArgs e)
        {

            // Insertion de la page TabAjouter s'il n'existe pas
            if (tabPageAdd.Text == "")
            {
                // 
                // Création de TabAjouter 
                //

                tabPageAdd.Text = this.Service.ConfigEntity.AddButton?.Title;
                tabControl_MainManager.CausesValidation = false;
                tabControl_MainManager.SelectedTab = tabPageAdd;
                //
                // Insertion du formulaire 
                //
                BaseEntity Entity = (BaseEntity)this.Service.CreateEntityInstance();
                BaseEntryForm form = Formulaire.CreateInstance(Service, Entity, this.FilterControl.GetFilterValues());
                form.Name = "Form";
                form.Dock = DockStyle.Fill;
                form.ShowEntity(this.FilterControl.GetFilterValues());
                tabPageAdd.Controls.Add(form);
                form.EnregistrerClick += Form_EnregistrerClick;
                form.AnnulerClick += Form_AnnulerAjouterClick;
            }
        }
        /// <summary>
        /// Enregistrer un Stagiaire
        /// </summary>
        private void Form_EnregistrerClick(object sender, EventArgs e)
        {
            
            BaseEntryForm form = (BaseEntryForm)tabPageAdd.Controls
                .Find("Form", false).First();
            this.EndAdd();
            this.Actualiser();
        }
        /// <summary>
        /// Annuler l'insertion d'un stagiaire
        /// </summary>
        private void Form_AnnulerAjouterClick(object sender, EventArgs e)
        {

            this.EndAdd();
        }

        private void EndAdd()
        {
            tabPageAdd.Text = "";
            tabPageAdd.Controls.Clear();
            tabControl_MainManager.SelectedTab = TabGrid;

        }


        #endregion
    }
}
