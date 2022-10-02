
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Collections.ObjectModel;

namespace BowlingLib.Model
{
    public class Equipe
    {
        private string nom;
        private List<Joueur> joueurs;
        private List<Joueur> Joueurs { get; private set; }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

 


        public Equipe(string nom, params Joueur[] joueurs)
        {
            this.nom = nom;

            if ( joueurs != null && joueurs.Count > 0)
            {
                foreach (Joueur nouv in joueurs) AjouterJoueur(nouv);
            }
            else
            {
                throw new ArgumentException("La liste est null ");
            }


            Joueurs = new ReadOnlyCollection<Joueur>(this.joueurs);


        }

        public Equipe(string nom)
        {
            this.nom = nom;
        }

       
       public void AjouterJoueurs(params Joueur[] joueurs)
        {
            foreach(var j in joueurs)
            {
                AjouterJoueur(j);
            }

            Joueurs = new ReadOnlyCollection<Joueur>(this.joueurs);
        }

        public bool AjouterJoueur(Joueur joueur)
        {
            if(!isExist(joueur))
            {
                joueurs.Add(joueur);
                return true;
            }else
            {
                throw new ArgumentException("Le joueur existe déjà dans l'équipe");
            }
                return false;
        }

        public void SupprimerJoueur(Joueur joueur)
        {
            joueurs.Remove(joueur);
        }

        //retourner la liste non modifiable des joueurs de l'équipe
        public List<Joueur> GetJoueurs()
        {
            return joueurs.AsReadOnly().ToList();
        }


        // Fonction permettant de vérifier si un joueur existe déjà dans la liste (l'équipe)
        public bool isExist(Joueur nouvJoueur)
        {
            foreach(Joueur j in Joueurs)
            {
                if (nouvJoueur.Equals(j)) return true;
            }
            return false;
        }

    }
}
