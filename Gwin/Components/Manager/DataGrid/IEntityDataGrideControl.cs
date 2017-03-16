using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Gwin
{
    /// <summary>
    /// Interface of Composant : EntityDataGrid to show and edit list of entities
    /// </summary>
    public interface IEntityDataGrideControl
    {
        #region Events
        /// <summary>
        /// Edit Click envent
        /// </summary>
        event EventHandler EditClick;

        /// <summary>
        /// Edit ManyToOneCollection Click
        /// </summary>
        event EventHandler EditManyToOneCollection;

        /// <summary>
        /// Edit ManyToOneCollection Click
        /// </summary>
        event EventHandler EditManyToManyCollection;
        #endregion

        /// <summary>
        /// Selected Entity in EntityDataGrid
        /// </summary>
        /// <returns></returns>
        BaseEntity SelectedEntity {  get; }
    }
}
