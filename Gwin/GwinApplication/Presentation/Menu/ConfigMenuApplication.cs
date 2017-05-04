using App.Gwin.Application.BAL;
using App.Gwin.Application.Presentation.EntityManagement;
using App.Gwin.Attributes;
using App.Gwin.DataModel.ModelInfo;
using App.Gwin.Entities;
using App.Gwin.Entities.Application;
using App.Gwin.Exceptions.Gwin;
using App.Gwin.ModelData;
using App.Gwin.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace App.Gwin.Application.Presentation.MainForm
{
    /// <summary>
    /// Create Menu of Application
    /// </summary>
    public class CreateApplicationMenu
    {
        #region Properites and Params
        /// <summary>
        /// MDI Form that cotrain Menu of Application
        /// </summary>
        private IApplicationMenu MdiFormWithMenu;
        /// <summary>
        /// Helper to Show Management Form
        /// </summary>
        private CreateAndShowManagerFormHelper ShowManagementForm { set; get; }
        /// <summary>
        /// Menu Instance of MDI Form
        /// </summary>
        private MenuStrip menuStrip;

        private MenuStruct MenuStruct { set; get; }

        /// <summary>
        /// Dictionary : MenuItems Structure
        /// </summary>
        private Dictionary<string, Type> MenuItems { set; get; }

        private IGwinBaseBLO MenuItemApplicationService { get; set; }
        #endregion

        /// <summary>
        /// Constructor : Create Application Menu
        /// </summary>
        /// <param name="FormMenu">MDI Form that cotain Menu of Application</param>
        public CreateApplicationMenu(IApplicationMenu FormMenu)
        {
            // Params
            this.MdiFormWithMenu = FormMenu;
            this.menuStrip = FormMenu.getMenuStrip();
            // MenuStruct Instance
            MenuItems = new Dictionary<string, Type>();
            MenuStruct = new MenuStruct();
            // Properties
            this.ShowManagementForm = new CreateAndShowManagerFormHelper(GwinApp.Instance.TypeDBContext, FormMenu);
            this.MenuItemApplicationService = GwinBaseBLO<BaseEntity>
                .CreateBLO_Instance(typeof(MenuItemApplication), GwinApp.Instance.TypeBaseBLO);
            // Create Menu
            this.CalculateMenuItems();
            this.ShowMenuItems();
        }


        /// <summary>
        /// Calculate MenuItmes from DataBase and Model Config
        /// </summary>
        private void CalculateMenuItems()
        {
            // Create Parent groups Menu from ManuItemApplication Table
            foreach (MenuItemApplication menuItemApplication in this.MenuItemApplicationService.GetAll())
            {
                //Continue if user don't have a role required by menuItemApplication roles
                if (menuItemApplication.Roles != null && menuItemApplication.Roles.Count > 0)
                    if (!GwinApp.Instance.user.HasOneOfRoles(menuItemApplication.Roles))
                        continue;

                // Create Parent Menu Item
                Structures.MenuItem menuItem = new Structures.MenuItem(true);

                menuItem.ToolStripMenuItem.Name = "toolStripMenuItem" + menuItemApplication.Code;
                menuItem.ToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
                // Title
                menuItem.ToolStripMenuItem.Text = (menuItemApplication.Title.Current != string.Empty)
                    ? menuItemApplication.Title.Current
                    : menuItem.ToolStripMenuItem.Text = menuItemApplication.Code;

                MenuStruct.ParentMenuItems.Add(menuItem);

            }


            // Create SubMenu MenuItems from ModelCondiguration Entities
            Dictionary<Type, MenuAttribute> MenuAttributes_And_Types = new GwinEntitiesManager().Get_All_Type_And_MenuAttributes();
            foreach (var menuAttributes_And_Types in MenuAttributes_And_Types)
            {
                Type EntityType = null;
                string Title = null;
                string Group = null;

                // Determine Category of Type : Entity or Form
                if (menuAttributes_And_Types.Key.IsSubclassOf(typeof(Form)))
                {
                    if (menuAttributes_And_Types.Value.EntityType == null)
                        throw new GwinException(String.Format("The property EntityType of MenuAttribute of the Form {0} is null \n it can not be null we use it to check security permission", menuAttributes_And_Types.Key));
                    EntityType = menuAttributes_And_Types.Value.EntityType;
                    ConfigEntity configEntity = ConfigEntity.CreateConfigEntity(EntityType);
                    Group = menuAttributes_And_Types.Value.Group;
                    if (menuAttributes_And_Types.Value.Title != null)
                        Title = configEntity.Translate(menuAttributes_And_Types.Value.Title);
                   
                }
                else
                {
                    if (menuAttributes_And_Types.Key.IsSubclassOf(typeof(BaseEntity)))
                    {
                        EntityType = menuAttributes_And_Types.Key;
                        ConfigEntity configEntity = ConfigEntity.CreateConfigEntity(EntityType);
                        Group = configEntity.Menu.Group;
                        Title = configEntity.Menu.Title;
                    }
                    else
                    {
                        throw new GwinException(String.Format("The Type {0} does not inherit from BaseEntity or Form ", menuAttributes_And_Types.Key));
                    }
                }
               


                // Security : Continue if User dont have persmission
                if (!GwinApp.Instance.user.HasAccess(EntityType)) continue;



                // Create MenuItem and Save to Dictionary MenyItem
                Structures.MenuItem SubMenuItem = new Structures.MenuItem(false);

                SubMenuItem.ToolStripMenuItem.Name = menuAttributes_And_Types.Key.FullName;
                SubMenuItem.ToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
                SubMenuItem.ToolStripMenuItem.Text = Title;
                SubMenuItem.ToolStripMenuItem.Click += ToolStripMenuItem_Click;
                SubMenuItem.TypeOfEntity = menuAttributes_And_Types.Key;

                // Find Parent if Exist
                Structures.MenuItem ParentMenuItem = null;
                if (Group != null)
                {
                    string toolStripMenuItem_key = "toolStripMenuItem" + Group;
                    ParentMenuItem = MenuStruct.ParentMenuItems.Where(m => m.ToolStripMenuItem.Name == toolStripMenuItem_key).SingleOrDefault();

                    // If parrent exist
                    if (ParentMenuItem != null)
                        ParentMenuItem.Add(SubMenuItem);
                    else
                    {
                        // throw new GwinException(String.Format("the Parent {0} of {1} not exist ", configEntity.Menu.Group, toolStripMenuItem_key));
                        // Patent not exist bevause user not have permission required by Parent Menu
                    }
                }
                else
                {
                    this.MenuStruct.ParentMenuItems.Add(SubMenuItem);
                }
            }
        }

        /// <summary>
        /// Show Menu Items from MenuStruct
        /// </summary>
        private void ShowMenuItems()
        {
            // Create Parent Menu in Menu Of Application  
            foreach (Structures.MenuItem ParentMenuItem in this.MenuStruct.ParentMenuItems)
            {
                // don't show Empty Parent Menu that not have Click event
                if ((ParentMenuItem.ChildsMenuItems == null || ParentMenuItem.ChildsMenuItems.Count == 0) && ParentMenuItem.isGroup) continue;

                // Add or Update Parent-MenuItem to Menu of Application
                // Update? is performed after Langauge change
                if (this.menuStrip.Items.Find(ParentMenuItem.ToolStripMenuItem.Name, true).Count() == 0)
                {
                    // new
                    this.menuStrip.Items.Add(ParentMenuItem.ToolStripMenuItem);
                }
                else
                {
                    // Update
                    ToolStripItem toolStripItem = this.menuStrip.Items.Find(ParentMenuItem.ToolStripMenuItem.Name, true).First();
                    toolStripItem.Text = ParentMenuItem.ToolStripMenuItem.Text;
                }

                // Add Sub Menu
                if (ParentMenuItem.ChildsMenuItems != null)
                    foreach (Structures.MenuItem SubMenuItem in ParentMenuItem.ChildsMenuItems)
                    {
                        ParentMenuItem.ToolStripMenuItem.DropDownItems.Add(SubMenuItem.ToolStripMenuItem);
                    }

            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            Structures.MenuItem menuitem = MenuStruct.FindMenuItemByToolStripMenuItem(item);
            if (menuitem.TypeOfEntity != null)
            {
                if (menuitem.TypeOfEntity.IsSubclassOf(typeof(BaseEntity)))
                {
                    this.ShowManagementForm.ShowManagerForm(menuitem.TypeOfEntity);
                }
                else
                {
                    if(menuitem.TypeOfEntity.IsSubclassOf(typeof(Form)))
                    {
                        this.ShowManagementForm.ShwoForm(menuitem.TypeOfEntity);
                    }
                    else
                    {
                        throw new GwinException(String.Format("The type '{0}' does not inherit from BaseEntity or Form", menuitem.TypeOfEntity));
                    }
                }
            }
               
            else
                throw new GwinException(String.Format("Type of entity of MenuItem is null"));
        }
    }
}