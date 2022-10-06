using BowlingLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.Model
{
    public class Manager
    {
        public IDataManager<Joueur> joueurManager { get; private set; }
        public IDataManager<Partie> partieManager { get; private set; }
        public IDataManager<Equipe> equipeManager { get; private set; }

        public Manager(IDataManager<Joueur> joueurManager)
        {
            this.joueurManager = joueurManager;
        }

        public Manager(IDataManager<Partie> partieManager)
        {
            this.partieManager = partieManager;
        }

        /// <summary>
        /// Ajoute un joueur à la liste des joueurs
        /// </summary>
        /// <param name="equipeManager"></param>
        public Manager(IDataManager<Equipe> equipeManager)
        {
            this.equipeManager = equipeManager;
        }

        /// <summary>
        /// Ajoute un joueur à la liste des joueurs
        /// </summary>
        /// <param name="joueur"></param>
        public void AddJoueur(Joueur joueur)
        {
            joueurManager.Add(joueur);
        }

        /// <summary>
        /// Ajoute une partie à la liste des parties
        /// </summary>
        /// <param name="partie"></param>
        public void AddPartie(Partie partie)
        {
            partieManager.Add(partie);
        }

        /// <summary>
        /// Ajoute une équipe à la liste des équipes
        /// </summary>
        /// <param name="equipe"></param>
        public void AddEquipe(Equipe equipe)
        {
            equipeManager.Add(equipe);
        }

        /// <summary>
        /// Retourne la liste des joueurs
        /// </summary>
        /// <param name="joueur"></param>
        public void DeleteJoueur(Joueur joueur)
        {
            joueurManager.Delete(joueur);
        }

        /// <summary>
        /// Supprime une partie
        /// </summary>
        /// <param name="partie"></param>
        public void DeletePartie(Partie partie)
        {
            partieManager.Delete(partie);
        }

        /// <summary>
        /// Supprime une équipe
        /// </summary>
        /// <param name="equipe"></param>
        public void DeleteEquipe(Equipe equipe)
        {
            equipeManager.Delete(equipe);
        }

        /// <summary>
        /// Retourne la liste des joueurs
        /// </summary>
        /// <param name="joueur"></param>
        public void UpdateJoueur(Joueur joueur)
        {
            joueurManager.Update(joueur);
        }

        /// <summary>
        /// Met à jour une partie
        /// </summary>
        /// <param name="partie"></param>
        public void UpdatePartie(Partie partie)
        {
            partieManager.Update(partie);
        }

        /// <summary>
        /// Met à jour une équipe
        /// </summary>
        /// <param name="equipe"></param>
        public void UpdateEquipe(Equipe equipe)
        {
            equipeManager.Update(equipe);
        }

        /// <summary>
        /// Retourne la liste des joueurs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Joueur> GetAllJoueur()
        {
            return joueurManager.GetAll();
        }

        /// <summary>
        /// Retourne les dernières parties du joueur
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Partie> GetAllPartie()
        {
            return partieManager.GetAll();
        }

        /// <summary>
        /// Retourne les Equipe d'une partie
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Equipe> GetAllEquipe()
        {
            return equipeManager.GetAll();
        }
        
        


    }
}
