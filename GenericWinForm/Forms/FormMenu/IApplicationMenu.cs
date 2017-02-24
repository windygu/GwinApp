using System.Windows.Forms;

namespace App.WinForm.Forms.FormMenu
{
    /// <summary>
    /// Application menu interface
    /// </summary>
    public interface IApplicationMenu : IBaseForm
    {
        /// <summary>
        /// Get the menu application instance
        /// </summary>
        /// <returns></returns>
        MenuStrip getMenuStrip();
    }
}