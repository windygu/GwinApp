using System.Windows.Forms;

namespace App.Gwin.Application.Presentation.MainForm
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