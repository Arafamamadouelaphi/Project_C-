<<<<<<< HEAD
﻿using System;
=======
<<<<<<< HEAD
﻿using System;
=======
using System;
>>>>>>> origin/CreationTest
>>>>>>> 8e1fb8c3cd98585de832d5a5d1b851f8a5f444ce
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
            get { return joueurs; }
            set { joueurs = value; }
        }

        public Equipe(string nom)
        {
            this.nom = nom;
            joueurs = new List<Joueur>();
        }

        public void AjouterJoueur(Joueur joueur)
        {
            joueurs.Add(joueur);
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
    }
}
