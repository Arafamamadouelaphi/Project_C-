
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.Model
{
    /// <summary>
    /// Classe Model Equipe
    /// </summary>
    public class Equipe
    {
        private string nom;
        private readonly long id;


        public List<Joueur> Joueurs = new List<Joueur>();


        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }




        public Equipe(string nom, params Joueur[] joueurs)
        {
            this.nom = nom;
            AjouterJoueurs(joueurs);
            //  foreach (Joueur nouv in joueurs) AjouterJoueur(nouv);           

        }
        public long Id
        {
            get { return id; }
        }


        public Equipe(string nom)
        {
            this.nom = nom;
        }

        public Equipe(long id, string nom, List<Joueur> joueurs)
        {
            this.id = id;
            Joueurs = joueurs;
            Nom = nom;
        }

        /// <summary>
        /// Ajoute une liste de joueur à l'équipe
        /// </summary>
        /// <param name="joueurs"></param>
        /// <returns></returns>
        public IEnumerable<Joueur> AjouterJoueurs(params Joueur[] joueurs)
        {
            List<Joueur> result = new();
            foreach (var a in joueurs)
            {
                if (AjouterJoueur(a))
                {
                    result.Add(a);
                }
            }
            return result;


        }

        /// <summary>
        /// Ajouter un joueur s'il n'exciste pas dans la bd
        /// </summary>
        /// <param name="joueur"></param>
        /// <returns></returns>

        public bool AjouterJoueur(Joueur joueur)
        {
            if (!isExist(joueur))
            {
                Joueurs.Add(joueur);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Supprimer un joueur
        /// </summary>
        /// <param name="joueur"></param>

        public void SupprimerJoueur(Joueur joueur)
        {
            Joueurs.Remove(joueur);
        }

        /// <summary>
        /// retourner la liste non modifiable des joueurs de l'équipe
        /// </summary>
        /// <returns></returns>
        public List<Joueur> GetJoueurs()
        {
            return Joueurs;
        }


        /// <summary>
        /// Fonction permettant de vérifier si un joueur existe déjà dans la liste (l'équipe)
        /// </summary>
        /// <param name="nouvJoueur"></param>
        /// <returns></returns>
        public bool isExist(Joueur nouvJoueur)
        {
            if (Joueurs.Contains(nouvJoueur))
                return true;
            return false;
        }

    }
}
