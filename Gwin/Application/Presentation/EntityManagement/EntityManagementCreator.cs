using App;
using App.WinForm.Application.BAL;
using App.WinForm.Application.BAL.GwinApplication;
using App.WinForm.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace App.WinForm.Application.Presentation.EntityManagement
{
    /// <summary>
    /// Show Entity Management Form
    /// </summary>
    public class EntityManagementCreator
    {
        #region Private Properties
        /// <summary>
        /// FormApplication Instance
        /// </summary>
        IBaseForm FormApplicationMdi { set; get; }

        /// <summary>
        /// Type of DbContext 
        /// </summary>
        public Type TypeDbContext { get; set; }
        /// <summary>
        /// Type of BaseBLO classe
        /// </summary>
        public Type TypeBaseBLO { get; private set; }

        #endregion


        /// <summary>
        /// Creare EntityManagementCreator instance
        /// </summary>
        /// <param name="Service"></param>
        /// <param name="FormApplicationMdi">Mdi form that with MenuApplication</param>
        public EntityManagementCreator(Type TypeDbContext, IBaseForm FormApplicationMdi)
        {

            if (!((Form)FormApplicationMdi).IsMdiContainer) throw new Exception("FormApplicationMdi must be MdiContainer");

            this.FormApplicationMdi = FormApplicationMdi;
            
            this.TypeDbContext = TypeDbContext;
        }


        #region ShowManagementForm

        /// <summary>
        /// Create New DBContext Instance
        /// </summary>
        /// <returns></returns>
        public DbContext CreateContext()
        {
            return Activator.CreateInstance(TypeDbContext) as DbContext;
        }

        public EntityManagementForm ShowManagementForm(Type TypeEntity)
        {
            IBaseBLO baseRepository = BaseEntityBLO<BaseEntity>.CreateBLOInstanceByTypeEntity(TypeEntity,Gwin.Instance.TypeBaseBLO, CreateContext());
            EntityManagementForm form = new EntityManagementForm(baseRepository, null, null, (Form)this.FormApplicationMdi);
            this.ShwoForm(form);
            return form;
        }

        public EntityManagementForm ShowManagementForm<T>() where T : BaseEntity
        {
            return ShowManagementForm(typeof(T));
        }
        public void ShowManagementForm<T>(IBaseBLO Service) where T : BaseEntity
        {
            EntityManagementForm form = new EntityManagementForm(Service, null, null, (Form)this.FormApplicationMdi);
            this.ShwoForm(form);
        }

        /// <summary>
        /// Show Management from with specifique EntryForm
        /// </summary>
        public EntityManagementForm ShowManagementForm<T>(BaseEntryForm formulaire) where T : BaseEntity
        {
            EntityManagementForm form = new EntityManagementForm(formulaire.Service, formulaire, null, (Form)this.FormApplicationMdi);
            this.ShwoForm(form);
            return form;
        }

        public void ShowManagementForm<T>(IBaseBLO Service, BaseEntryForm formulaire) where T : BaseEntity
        {
            EntityManagementForm form = new EntityManagementForm(Service, formulaire, null, (Form)this.FormApplicationMdi);
            this.ShwoForm(form);
        }
        #endregion



        /// <summary>
        /// Shwo Entity Management Form
        /// </summary>
        /// <param name="addForm">Entity Management Form instance  </param>
        public void ShwoForm(Form addForm)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form form = ((BaseForm)FormApplicationMdi).MdiChildren.Where(f => f.Name == addForm.Name).FirstOrDefault();
            if (form == null)
            {
                addForm.MdiParent = (Form)FormApplicationMdi;
                addForm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                addForm.WindowState = FormWindowState.Normal;
                addForm.Show();
            }
            else
            {
                form.WindowState = FormWindowState.Normal;

            }

            Cursor.Current = Cursors.Default;
        }
    }
}
