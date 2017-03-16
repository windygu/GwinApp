namespace App.Gwin
{
    partial class BaseEntryForm
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseEntryForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanelForm = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControlForm = new System.Windows.Forms.TabControl();
            this.tabPageForm = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btEnregistrer = new System.Windows.Forms.Button();
            this.btAnnuler = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlForm.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.CausesValidation = false;
            this.errorProvider.SetError(this.splitContainer1, resources.GetString("splitContainer1.Error"));
            this.errorProvider.SetIconAlignment(this.splitContainer1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.splitContainer1, ((int)(resources.GetObject("splitContainer1.IconPadding"))));
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.CausesValidation = false;
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanelForm);
            this.splitContainer1.Panel1.Controls.Add(this.tabControlForm);
            this.errorProvider.SetError(this.splitContainer1.Panel1, resources.GetString("splitContainer1.Panel1.Error"));
            this.errorProvider.SetIconAlignment(this.splitContainer1.Panel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer1.Panel1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.splitContainer1.Panel1, ((int)(resources.GetObject("splitContainer1.Panel1.IconPadding"))));
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.CausesValidation = false;
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.errorProvider.SetError(this.splitContainer1.Panel2, resources.GetString("splitContainer1.Panel2.Error"));
            this.errorProvider.SetIconAlignment(this.splitContainer1.Panel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer1.Panel2.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.splitContainer1.Panel2, ((int)(resources.GetObject("splitContainer1.Panel2.IconPadding"))));
            this.splitContainer1.TabStop = false;
            // 
            // flowLayoutPanelForm
            // 
            resources.ApplyResources(this.flowLayoutPanelForm, "flowLayoutPanelForm");
            this.errorProvider.SetError(this.flowLayoutPanelForm, resources.GetString("flowLayoutPanelForm.Error"));
            this.errorProvider.SetIconAlignment(this.flowLayoutPanelForm, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("flowLayoutPanelForm.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.flowLayoutPanelForm, ((int)(resources.GetObject("flowLayoutPanelForm.IconPadding"))));
            this.flowLayoutPanelForm.Name = "flowLayoutPanelForm";
            // 
            // tabControlForm
            // 
            resources.ApplyResources(this.tabControlForm, "tabControlForm");
            this.tabControlForm.Controls.Add(this.tabPageForm);
            this.tabControlForm.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.errorProvider.SetError(this.tabControlForm, resources.GetString("tabControlForm.Error"));
            this.errorProvider.SetIconAlignment(this.tabControlForm, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tabControlForm.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.tabControlForm, ((int)(resources.GetObject("tabControlForm.IconPadding"))));
            this.tabControlForm.Multiline = true;
            this.tabControlForm.Name = "tabControlForm";
            this.tabControlForm.SelectedIndex = 0;
            this.tabControlForm.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlForm.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabPageForm
            // 
            resources.ApplyResources(this.tabPageForm, "tabPageForm");
            this.errorProvider.SetError(this.tabPageForm, resources.GetString("tabPageForm.Error"));
            this.errorProvider.SetIconAlignment(this.tabPageForm, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tabPageForm.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.tabPageForm, ((int)(resources.GetObject("tabPageForm.IconPadding"))));
            this.tabPageForm.Name = "tabPageForm";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.CausesValidation = false;
            this.panel1.Controls.Add(this.btEnregistrer);
            this.panel1.Controls.Add(this.btAnnuler);
            this.errorProvider.SetError(this.panel1, resources.GetString("panel1.Error"));
            this.errorProvider.SetIconAlignment(this.panel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("panel1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.panel1, ((int)(resources.GetObject("panel1.IconPadding"))));
            this.panel1.Name = "panel1";
            // 
            // btEnregistrer
            // 
            resources.ApplyResources(this.btEnregistrer, "btEnregistrer");
            this.errorProvider.SetError(this.btEnregistrer, resources.GetString("btEnregistrer.Error"));
            this.errorProvider.SetIconAlignment(this.btEnregistrer, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btEnregistrer.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.btEnregistrer, ((int)(resources.GetObject("btEnregistrer.IconPadding"))));
            this.btEnregistrer.Image = global::App.Gwin.Properties.Resources.save;
            this.btEnregistrer.Name = "btEnregistrer";
            this.btEnregistrer.UseVisualStyleBackColor = true;
            this.btEnregistrer.Click += new System.EventHandler(this.btEnregistrer_Click);
            // 
            // btAnnuler
            // 
            resources.ApplyResources(this.btAnnuler, "btAnnuler");
            this.btAnnuler.CausesValidation = false;
            this.errorProvider.SetError(this.btAnnuler, resources.GetString("btAnnuler.Error"));
            this.errorProvider.SetIconAlignment(this.btAnnuler, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btAnnuler.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.btAnnuler, ((int)(resources.GetObject("btAnnuler.IconPadding"))));
            this.btAnnuler.Image = global::App.Gwin.Properties.Resources.fermer_noir;
            this.btAnnuler.Name = "btAnnuler";
            this.btAnnuler.UseVisualStyleBackColor = true;
            this.btAnnuler.Click += new System.EventHandler(this.btAnnuler_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // BaseEntryForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.errorProvider.SetError(this, resources.GetString("$this.Error"));
            this.errorProvider.SetIconAlignment(this, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("$this.IconAlignment"))));
            this.errorProvider.SetIconPadding(this, ((int)(resources.GetObject("$this.IconPadding"))));
            this.Name = "BaseEntryForm";
            this.Load += new System.EventHandler(this.BaseEntryForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlForm.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btAnnuler;
        private System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.ErrorProvider errorProvider;
        public System.Windows.Forms.Button btEnregistrer;
        public System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabPageForm;
        protected System.Windows.Forms.TabControl tabControlForm;
        protected System.Windows.Forms.FlowLayoutPanel flowLayoutPanelForm;
    }
}
