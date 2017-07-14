using App;
using App.Gwin.Application.BAL;
using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.GwinApplication.Security.Exception;
using MetroFramework.Forms;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace App.Gwin.Application.Presentation.EntityManagement
{
    /// <summary>
    /// Create an Show ManagerForm
    /// </summary>
    public class CreateAndShowManagerFormHelper
    {
        #region Properties
        /// <summary>
        /// MdiForm Application Instance
        /// </summary>
        public IBaseForm MdiForm { set; get; }
        /// <summary>
        /// Type of DbContext 
        /// </summary>
        public Type ContextType { get; set; }
        /// <summary>
        /// Type of BaseBLO classe
        /// </summary>
        public Type BaseBLOType { get; set; }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ContextType"></param>
        /// <param name="MdiForm">Mdi form that with MenuApplication</param>
        public CreateAndShowManagerFormHelper(Type ContextType, IBaseForm ParentForm)
        {
            // Merto FrameWork not support MDI Application
            // if (!((Form)MdiForm).IsMdiContainer) throw new Exception("FormApplicationMdi must be MdiContainer");

            this.MdiForm = MdiForm;
            this.ContextType = ContextType;
        }

        /// <summary>
        /// Create an Show ManagerForm
        /// </summary>
        /// <param name="EntityType">Type of Entity</param>
        /// <returns></returns>
        public ManagerForm ShowManagerForm(Type EntityType)
        {
            IGwinBaseBLO baseRepository = GwinBaseBLO<BaseEntity>.CreateBLO_Instance(EntityType, GwinApp.Instance.TypeBaseBLO);
            ManagerForm form = new ManagerForm(baseRepository, null, null, (Form)this.MdiForm);
            this.ShwoForm(form);
            return form;
        }



        /// <summary>
        /// Create an Show ManagerForm
        /// </summary>
        /// <typeparam name="T">Type of Entity</typeparam>
        /// <returns></returns>
        public ManagerForm ShowManagerForm<T>() where T : BaseEntity
        {
            return ShowManagerForm(typeof(T));
        }
        /// <summary>
        /// Create an Show ManagerForm
        /// </summary>
        /// <typeparam name="T">Type of Entity</typeparam>
        /// <param name="EntityBLO">EntityBLO instance</param>
        public void ShowManagerForm<T>(IGwinBaseBLO EntityBLO) where T : BaseEntity
        {
            ManagerForm form = new ManagerForm(EntityBLO, null, null, (Form)this.MdiForm);
            this.ShwoForm(form);
        }

        /// <summary>
        /// Create an Show ManagerForm
        /// </summary>
        /// <typeparam name="T">Type of Entity</typeparam>
        /// <param name="EntryFormInstance">Entry Form Instance</param>
        /// <returns></returns>
        public ManagerForm ShowManagerForm<T>(BaseEntryForm EntryFormInstance) where T : BaseEntity
        {
            ManagerForm form = new ManagerForm(EntryFormInstance.EntityBLO, EntryFormInstance, null, (Form)this.MdiForm);
            this.ShwoForm(form);
            return form;
        }

        /// <summary>
        /// Create an Show ManagerForm
        /// </summary>
        /// <typeparam name="T">Type of Entity</typeparam>
        /// <param name="Service">EntityBLO Instance</param>
        /// <param name="EntriyFormInstance">Entry Form Instance</param>
        public void ShowManagerForm<T>(IGwinBaseBLO Service, BaseEntryForm EntriyFormInstance) where T : BaseEntity
        {
            ManagerForm form = new ManagerForm(Service, EntriyFormInstance, null, (Form)this.MdiForm);
            this.ShwoForm(form);
        }



        /// <summary>
        /// Show Form bay Type
        /// </summary>
        /// <param name="TypeOfForm">Type of Form</param>
        public void ShwoForm(Type TypeOfForm)
        {
            Form FormInstance = Activator.CreateInstance(TypeOfForm) as Form;
            this.ShwoForm(FormInstance);
        }

        /// <summary>
        /// Create an Show GForm
        /// </summary>
        /// <param name="GFormInstance">GForm instance  </param>
        public void ShwoForm(ManagerForm GFormInstance)
        {
            Cursor.Current = Cursors.WaitCursor;
            GFormInstance.Icon = GwinApp.Instance.FormApplication.Icon;

            // WindowState 
            if (ManagementFormAttribute.WindowState.Maximized == GFormInstance.EntityBLO.ConfigEntity.ManagementForm.Window_State)
                //  GFormInstance.WindowState = FormWindowState.Maximized; Generate Bug with MetroFramewrok
                // We well use Maximized after FormLoad
                GFormInstance.WindowState = FormWindowState.Normal;
            else
                GFormInstance.WindowState = FormWindowState.Normal;

            GFormInstance.ShowDialog();
            Cursor.Current = Cursors.Default;
        }
        /// <summary>
        /// Create an Show GForm
        /// </summary>
        /// <param name="GFormInstance">GForm instance  </param>
        public void ShwoForm(Form GFormInstance)
        {
            Cursor.Current = Cursors.WaitCursor;
            GFormInstance.Icon = GwinApp.Instance.FormApplication.Icon;
            //GFormInstance.WindowState = FormWindowState.Normal;
            GFormInstance.ShowDialog();
            Cursor.Current = Cursors.Default;
        }
    }
}
