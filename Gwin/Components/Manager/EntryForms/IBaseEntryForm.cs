
using GApp.GwinApp.Application.BAL;
using GApp.GwinApp.Entities;

namespace GApp.GwinApp
{
    public interface IBaseEntryForm
    {
        /// <summary>
        /// Afficher l'objet dans le formulaire
        /// </summary>
        void ShowEntity();

        /// <summary>
        /// Lire l'objet à partire du formulaire
        /// </summary>
        void Lire();

        /// <summary>
        /// Création d'une instance du form en cours
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        BaseEntryForm CreateInstance(IGwinBaseBLO service);

        /// <summary>
        /// Créer d'une instance de l'objet en cours
        /// </summary>
        /// <returns></returns>
        BaseEntity CreateObjetInstance();
    }
}