using App.WinForm.Attributes;
using App.WinForm.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace App
{
    /// <summary>
    ///  BaseBAO Interface
    /// </summary>
    public interface IBaseBAO 
    {
        #region Properties
        /// <summary>
        /// Get or Set the entity Type
        /// </summary>
        Type TypeEntity { set; get; }
        /// <summary>
        /// ConfigEntity Object
        /// </summary>
        ConfigEntity ConfigEntity { set; get; }
        #endregion

        #region Business Role
        /// <summary>
        /// To run after the event that indicates that the entity's values are changed
        /// </summary>
        void ApplyBusinessRolesAfterValuesChanged(object sender, BaseEntity entity);
        #endregion

        #region Context
        /// <summary>
        /// Obtient le context 
        /// </summary>
        /// <returns></returns>
       // ModelContext Context();
        DbContext Context { get; set;}

    void Dispose();
        #endregion

        #region CRUD opetation

        /// <summary>
        /// Saving an Entity in case of Add or Update
        /// </summary>
        /// <param name="entity">The entity to be saved</param>
        /// <returns>Entity ID</returns>
        int Save(BaseEntity entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Number of deleted entities</returns>
        int Delete(BaseEntity obj);
        #endregion

        #region Search Operation

        /// <summary>
        /// Search 
        /// </summary>
        /// <param name="rechercheInfos"></param>
        /// <param name="startPage"></param>
        /// <param name="itemsPerPage"></param>
        /// <returns></returns>
        List<Object> Recherche(Dictionary<string, object> rechercheInfos, int startPage = 0, int itemsPerPage = 0);

        /// <summary>
        /// Returns all objects with the detached state
        /// </summary>
        /// <returns></returns>
        List<object> GetAllDetached();

        List<Object> GetAll();

        BaseEntity GetBaseEntityByID(Int64 id);

        #endregion


        #region Create Instance
        /// <summary>
        /// Creating an instance of the T object
        /// </summary>
        /// <returns></returns>
        object CreateEntityInstance();

        /// <summary>
        /// Creating an instance of Entity by Type 
        /// </summary>
        /// <param name="TypeEntity">Type of Entity to be instantiated</param>
        /// <returns></returns>
        IBaseBAO CreateEntityInstanceByType(Type TypeEntity);
        IBaseBAO CreateEntityInstanceByTypeAndContext(Type TypeEntity,DbContext context);
        #endregion

    }
}
