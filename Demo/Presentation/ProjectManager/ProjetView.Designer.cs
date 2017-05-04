namespace GenericWinForm.Demo.Presentation.ProjectManager
{
    partial class ProjetView
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_Project = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel_Project);
            this.splitContainer1.Size = new System.Drawing.Size(835, 460);
            this.splitContainer1.SplitterDistance = 379;
            // 
            // tabControlForm
            // 
            this.tabControlForm.Location = new System.Drawing.Point(785, 345);
            // 
            // btEnregistrer
            // 
            this.btEnregistrer.Location = new System.Drawing.Point(3, 23);
            // 
            // panel_Project
            // 
            this.panel_Project.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Project.Location = new System.Drawing.Point(0, 0);
            this.panel_Project.Name = "panel_Project";
            this.panel_Project.Size = new System.Drawing.Size(835, 379);
            this.panel_Project.TabIndex = 3;
            // 
            // ProjetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ProjetView";
            this.Size = new System.Drawing.Size(835, 460);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Project;
    }
}
