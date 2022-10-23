
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
        public string Nom { get; private set; }
        public  long Id { get; private set; }

         public ReadOnlyCollection<Joueur> Joueurs { get; private set; }

        private List<Joueur> joueurs = new List<Joueur>();


      /*  public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
*/



   /*     public Equipe(string nom, params Joueur[] joueurs)
        {
            this.Nom = nom;
            AjouterJoueurs(joueurs);
            //  foreach (Joueur nouv in joueurs) AjouterJoueur(nouv);           

        }*/
     


        public Equipe(string nom)
        {
            Nom = nom;
        }

        public Equipe(long id, string nom, params Joueur[] joueurs)
        {
            Id = id;
          //  Joueurs = joueurs;
            Nom = nom;
             Joueurs = new ReadOnlyCollection<Joueur>(this.joueurs);
            AjouterJoueurs(joueurs);
        }

        public Equipe(string nom, params Joueur[] joueurs)
            : this(0, nom, joueurs) {}

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
                joueurs.Add(joueur);
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
            joueurs.Remove(joueur);
        }

        /// <summary>
        /// retourner la liste non modifiable des joueurs de l'équipe
        /// </summary>
        /// <returns></returns>
      /*  public List<Joueur> GetJoueurs()
        {
            return Joueurs;
        }*/


        /// <summary>
        /// Fonction permettant de vérifier si un joueur existe déjà dans la liste (l'équipe)
        /// </summary>
        /// <param name="nouvJoueur"></param>
        /// <returns></returns>
        public bool isExist(Joueur nouvJoueur)
        {
            if (joueurs.Contains(nouvJoueur))
                return true;
            return false;
        }

    }
}
