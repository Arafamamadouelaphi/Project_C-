
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Collections.ObjectModel;

namespace BowlingLib.Model
{
    public class Equipe
    {
        private string nom;

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
        public object Id { get; set; }

        private int numero;

        public Equipe(string nom)
        {
            this.nom = nom;
        }

       
       public List<Joueur> AjouterJoueurs(params Joueur[] joueurs)
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

        public bool AjouterJoueur(Joueur joueur)
        {
            if(!isExist(joueur))
            {
                Joueurs.Add(joueur);
                return true;
            }else
            {
                return false;
            }
        }

        public void SupprimerJoueur(Joueur joueur)
        {
            Joueurs.Remove(joueur);
        }

        //retourner la liste non modifiable des joueurs de l'équipe
        public long GetJoueurs()
        {
            return Joueurs.Count;
        }


        // Fonction permettant de vérifier si un joueur existe déjà dans la liste (l'équipe)
        public bool isExist(Joueur nouvJoueur)
        {
             
                    if (Joueurs.Contains(nouvJoueur)) return true;
                
            
            return false;
        }

    }
}
