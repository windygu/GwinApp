using App.WinForm.Application.BAL;
using App.WinForm.Application.BAL.GwinApplication;
using App.WinForm.Application.Presentation.EntityManagement;
using App.WinForm.Attributes;
using App.WinForm.Entities;
using App.WinForm.Entities.Application;
using App.WinForm.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace App.WinForm.Application.Presentation.MainForm
{
    /// <summary>
    /// Application Menu Configuration
    /// </summary>
    public class ConfigMenuApplication
    {
        #region Params
        private IApplicationMenu formMenu;
        private EntityManagementCreator ShowManagementForm { set; get; }
        #endregion
        #region Variables
        private MenuStrip menuStrip;
        private Dictionary<string, Type> MenuItems { set; get; }
        private IBaseBLO Service { get;  set; }
        #endregion

        public ConfigMenuApplication(IApplicationMenu formMenu)
        {
            this.formMenu = formMenu;
            this.menuStrip = formMenu.getMenuStrip();
            MenuItems = new Dictionary<string, Type>();
            this.ShowManagementForm = new EntityManagementCreator(Gwin.Instance.TypeDBContext,formMenu);
            this.Service = BaseEntityBLO<BaseEntity>
                .CreateBLOInstanceByTypeEntity(typeof(MenuItemApplication),Gwin.Instance.TypeBaseBLO, this.ShowManagementForm.CreateContext());
            this.CreateMenu();
        }


        /// <summary>
        /// Create Menu from ModelConfig
        /// </summary>
        private void CreateMenu()
        {
            // Create Parent Menu from ManuItemApplication Table
            foreach (MenuItemApplication menuItemApplication in this.Service.GetAll())
            {
                // ToolStripMenu
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Name = "toolStripMenuItem" + menuItemApplication.Name;
                toolStripMenuItem.Size = new System.Drawing.Size(82, 20);
                toolStripMenuItem.Text = menuItemApplication.TitrleCulture(Gwin.Instance.CultureInfo);
                this.menuStrip.Items.Add(toolStripMenuItem);
            }


            // Create MenuItems from ModelCondiguration Entities
            Dictionary<Type, MenuAttribute> MenuAttributes_And_Types = new ModelConfiguration().Get_All_Type_And_MenuAttributes();
            foreach (var menuAttributes_And_Types in MenuAttributes_And_Types)
            {

                ConfigEntity configEntity = ConfigEntity.CreateConfigEntity(menuAttributes_And_Types.Key);

                // ToolStripMenu
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Name = "toolStripMenuItem" + configEntity.Menu.Title;
                toolStripMenuItem.Size = new System.Drawing.Size(82, 20);
                toolStripMenuItem.Text = configEntity.Menu.Title;
                toolStripMenuItem.Click += ToolStripMenuItem_Click;
                MenuItems.Add(toolStripMenuItem.Name, menuAttributes_And_Types.Key);

                // Find groupe
                if (configEntity.Menu.Group != null) {
                    ToolStripItem GroupeToolStripItem = this.menuStrip.Items.Find("toolStripMenuItem" + configEntity.Menu.Group, true).SingleOrDefault();
                    ToolStripMenuItem GroupeToolStripMenuItem = GroupeToolStripItem as ToolStripMenuItem;
                    if(GroupeToolStripMenuItem != null)
                      GroupeToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
                }else
                {
                    this.menuStrip.Items.Add(toolStripMenuItem);
                }
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            this.ShowManagementForm.ShowManagementForm(MenuItems[item.Name]);
        }
    }
}