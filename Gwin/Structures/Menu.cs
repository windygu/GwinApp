using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Gwin.Structures
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

        public MenuItem FinMenuItemByToolStripMenuItem(ToolStripMenuItem item)
        {
            MenuItem ParentmenuItem = ParentMenuItems.Where(p => p.ToolStripMenuItem == item).SingleOrDefault();
            if (ParentmenuItem != null) return ParentmenuItem;

            foreach (MenuItem menuItem in ParentMenuItems)
            {
                if(menu)
            }
        }
    }
}
