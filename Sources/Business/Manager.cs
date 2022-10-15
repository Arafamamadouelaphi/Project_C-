using BowlingLib.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Manager
    {
        public ReadOnlyCollection<Partie> Parties { get; private set; }
        private readonly List<Partie> parties = new();
        public ReadOnlyCollection<Equipe> Equipes { get; private set; }
        private readonly List<Equipe> equipes = new();
        public ReadOnlyCollection<Joueur> Joueurs { get; private set; }
        private readonly List<Joueur> joueurs = new();
        

        public IDataManager<Joueur> JoueurDataManager => joueurDataManager;
        private readonly IDataManager<Joueur> joueurDataManager;
        public IDataManager<Partie> PartieDataManager => partieDataManager;
        private readonly IDataManager<Partie> partieDataManager;
        public IDataManager<Equipe> EquipeDataManager => equipeDataManager;
        private readonly IDataManager<Equipe> equipeDataManager;

        public Manager(IDataManager<Joueur> joueurManager)
        {
            this.joueurDataManager = joueurManager;
            Joueurs = new ReadOnlyCollection<Joueur>(joueurs);

        }

        public Manager(IDataManager<Partie> partieDataManager)
        {
            this.partieDataManager = partieDataManager;
            Parties = new ReadOnlyCollection<Partie>(parties);
        }
        
        
        public Manager(IDataManager<Equipe> equipeDataManager)
        {
            this.equipeDataManager = equipeDataManager;
            Equipes = new ReadOnlyCollection<Equipe>(equipes);
        }

        /// <summary>
        /// Ajoute un joueur à la liste des joueurs
        /// </summary>
        /// <param name="joueur"></param>
        /// <returns></returns>
        public bool AddJoueur(Joueur joueur)
        {
            if (joueurDataManager == null)
            {
                return false;
            }
            return joueurDataManager.Add(joueur);
        }

        /// <summary>
        /// Ajoute une partie à la liste des parties
        /// </summary>
        /// <param name="partie"></param>
        /// <returns></returns>
        public bool AddPartie(Partie partie)
        {
            if (partieDataManager == null)
            {
                return false;
            }
            return partieDataManager.Add(partie);
        }

        /// <summary>
        /// Ajoute une équipe à la liste des équipes
        /// </summary>
        /// <param name="equipe"></param>
        /// <returns></returns>
        public bool AddEquipe(Equipe equipe)
        {
            if (equipeDataManager == null)
            {
                return false;
            }
            return equipeDataManager.Add(equipe);
        }

        /// <summary>
        /// Retourne la liste des joueurs
        /// </summary>
        /// <param name="joueur"></param>
        public bool DeleteJoueur(Joueur joueur)
        {
            if (joueurDataManager == null)
            {
                return false;
            }
            return JoueurDataManager.Delete(joueur);
        }

        /// <summary>
        /// Supprime une partie
        /// </summary>
        /// <param name="partie"></param>
        public bool DeletePartie(Partie partie)
        {
            if (partieDataManager == null)
            {
                return false;
            }
            return partieDataManager.Delete(partie);
        }

        /// <summary>
        /// Supprime une équipe
        /// </summary>
        /// <param name="equipe"></param>
        public bool DeleteEquipe(Equipe equipe)
        {
            if (equipeDataManager == null)
            {
                return false;
            }
            return equipeDataManager.Delete(equipe);
        }

        /// <summary>
        /// Retourne la liste des joueurs
        /// </summary>
        /// <param name="joueur"></param>
        public bool UpdateJoueur(Joueur joueur)
        {
            if (joueurDataManager == null)
            {
                return false;
            }
            return JoueurDataManager.Update(joueur);
        }

        /// <summary>
        /// Met à jour une partie
        /// </summary>
        /// <param name="partie"></param>
        public bool UpdatePartie(Partie partie)
        {
            if (partieDataManager == null)
            {
                return false;
            }
            return partieDataManager.Update(partie);
        }

        /// <summary>
        /// Met à jour une équipe
        /// </summary>
        /// <param name="equipe"></param>
        public bool UpdateEquipe(Equipe equipe)
        {
            if (equipeDataManager == null)
            {
                return false;
            }
            return equipeDataManager.Update(equipe);
        }

        /// <summary>
        /// Retourne la liste des joueurs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Joueur> GetAllJoueur()
        {
            return JoueurDataManager.GetAll();
        }

        /// <summary>
        /// Retourne les dernières parties du joueur
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Partie> GetAllPartie()
        {
            return partieDataManager.GetAll();
        }

        /// <summary>
        /// Retourne les Equipe en fonction d'une partie
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Equipe> GetAllEquipe()
        {
            return equipeDataManager.GetAll();
        }

    }
}
