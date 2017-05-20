namespace GenericWinForm.Demo.Presentation.ProjectManager
{
    partial class ProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectForm));
            this.panel_Project = new System.Windows.Forms.Panel();
            this.Title = new App.Gwin.Fields.StringField();
            this.Description = new App.Gwin.Fields.StringField();
            this.groupBox1 = new System.Windows.Forms.GroupBox();

            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel_form.SuspendLayout();
            this.FlowLayoutContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel_Project);
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            // 
            // btEnregistrer
            // 
            resources.ApplyResources(this.btEnregistrer, "btEnregistrer");
            // 
            // panel_form
            // 
            resources.ApplyResources(this.panel_form, "panel_form");
            this.panel_form.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_form_Paint);
            // 
            // FlowLayoutContainer
            // 
   
            this.FlowLayoutContainer.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.FlowLayoutContainer, "FlowLayoutContainer");
            // 
            // panel_Project
            // 
            resources.ApplyResources(this.panel_Project, "panel_Project");
            this.panel_Project.Name = "panel_Project";
            this.panel_Project.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Project_Paint);
            // 
            // Title
            // 
            this.Title.AutoSizeConfig = true;
            this.Title.IsMultiline = false;
            resources.ApplyResources(this.Title, "Title");
            this.Title.Name = "Title";
            this.Title.NombreLigne = 5;
            this.Title.OrientationField = System.Windows.Forms.Orientation.Vertical;
            this.Title.PropertyInfo = null;
            this.Title.SizeControl = new System.Drawing.Size(200, 20);
            this.Title.SizeLabel = new System.Drawing.Size(100, 20);
            this.Title.Text_Label = "Nom du projet";
            this.Title.Value = "";
            // 
            // Description
            // 
            this.Description.AutoSizeConfig = true;
            this.Description.IsMultiline = true;
            resources.ApplyResources(this.Description, "Description");
            this.Description.Name = "Description";
            this.Description.NombreLigne = 5;
            this.Description.OrientationField = System.Windows.Forms.Orientation.Vertical;
            this.Description.PropertyInfo = null;
            this.Description.SizeControl = new System.Drawing.Size(300, 20);
            this.Description.SizeLabel = new System.Drawing.Size(100, 20);
            this.Description.Text_Label = "شرح المشروع";
            this.Description.Value = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Title);
            this.groupBox1.Controls.Add(this.Description);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // manyToManyField1
            // 
 
            // 
            // manyToManyField2
            // 
      
            // 
            // manyToManyField3
            // 
        
            // 
            // ProjectForm
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "ProjectForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel_form.ResumeLayout(false);
            this.FlowLayoutContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Project;
        private App.Gwin.Fields.StringField Description;
        private App.Gwin.Fields.StringField Title;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}
