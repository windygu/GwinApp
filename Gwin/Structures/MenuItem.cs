using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Gwin.Structures
{
    /// <summary>
    /// Menu Item of Menu of Application
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// is Group or Menuitem
        /// </summary>
        public bool isGroup { set; get; }
        /// <summary>
        /// Child Menu ITems
        /// it Value can be null 
        /// </summary>
        public List<MenuItem> ChildsMenuItems { set; get; }

        public ToolStripMenuItem ToolStripMenuItem { set; get; }

        public MenuItem(bool isGroup)
        {
            this.isGroup = isGroup;
            ToolStripMenuItem = new ToolStripMenuItem();
        }

        public void Add(MenuItem menuItem)
        {
            if (ChildsMenuItems == null) ChildsMenuItems = new List<MenuItem>();
            ChildsMenuItems.Add(menuItem);
        }


    }
}
