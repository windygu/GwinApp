using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GApp.GwinApp.Structures
{
    /// <summary>
    /// Struct represente Menu of Application
    /// </summary>
    public class MenuStruct
    {
        public List<MenuItem> ParentMenuItems { set; get; }


        public MenuStruct()
        {
            ParentMenuItems = new List<MenuItem>();
        }

        public MenuItem FindMenuItemByToolStripMenuItem(ToolStripMenuItem toolStripMenuItem)
        {
            

            foreach (MenuItem menuItem in ParentMenuItems)
            {
                if (menuItem.ToolStripMenuItem == toolStripMenuItem)
                    return menuItem;

                if (menuItem.ChildsMenuItems != null)
                    foreach (var item in menuItem.ChildsMenuItems)
                    {
                        if (item.ToolStripMenuItem == toolStripMenuItem)
                            return item;
                    }
            }
            return null;
        }
    }
}
