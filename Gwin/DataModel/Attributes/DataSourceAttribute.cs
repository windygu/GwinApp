using System;
using System.Collections.Generic;

namespace App.Gwin.Attributes
{
    /// <summary>
    /// Set DataSource to Fill ComboBox
    /// </summary>
    public class DataSourceAttribute : Attribute
    {
        /// <summary>
        /// Type of Object that containt Data
        /// </summary>
        public Type TypeObject { get; set; }

        /// <summary>
        /// Name of methode to obtaine List of object data
        /// </summary>
        public string MethodeName { get; set; }
        /// <summary>
        /// Property to use in Object returned by MathodeName to Knew DisplyName
        /// </summary>
        public string DisplayName { get; set; }
    }
}