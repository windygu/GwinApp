using GApp.GwinApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GApp.GwinApp
{
    /// <summary>
    /// Interface of Composant : EntityDataGrid to show and edit list of entities
    /// </summary>
    public interface IGwinDataGridComponent
    {
        #region Events
        /// <summary>
        /// Edit Click envent
        /// </summary>
        event EventHandler EditClick;

        /// <summary>
        /// Edit ManyToOneCollection Click
        /// </summary>
        event EventHandler EditManyToMany_Creation;
        #endregion

        /// <summary>
        /// Selected Entity in EntityDataGrid
        /// </summary>
        /// <returns></returns>
        BaseEntity SelectedEntity {  get; }
    }
}
