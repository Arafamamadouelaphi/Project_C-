
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.Model
{
    public class Equipe
    {
        private string nom;
        private List<Joueur> joueurs;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public List<Joueur> Joueurs
        {
            get { return this.joueurs.AsReadOnly().ToList(); }
            set {

                foreach (Joueur nouv in value) AjouterJoueur(nouv);
            }
        }


        public Equipe(string nom, List<Joueur> joueurs)
        {
            this.nom = nom;

            if ( joueurs != null && joueurs.Count > 0)
            {
                 if (!this.joueurs.SequenceEqual(joueurs)) this.joueurs = joueurs; // Verification de doublon avant l'ajout des joueurs dans l'équipe
            }
            else
            {
                throw new ArgumentException("La liste est null ");
            }
           

        }

        public Equipe(string nom)
        {
            this.nom = nom;
            joueurs = new List<Joueur>();
        }

       
       

        public void AjouterJoueur(Joueur joueur)
        {
            if(!isExist(joueur))
            {
                joueurs.Add(joueur);

            }else
            {
                throw new ArgumentException("Le joueur existe déjà dans l'équipe");
            }
            
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
                if (nouvJoueur.Equals(j) return true;
            }
            return false;
        }

    }
}
