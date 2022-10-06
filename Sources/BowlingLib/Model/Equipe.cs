
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.Model
{
    public class Equipe
    {
        private string nom;
        public ReadOnlyCollection<Joueur> Joueurs
        {
            get;
            private set;
        }
        private List<Joueur> joueurs;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public object Id { get; set; }

        private int numero;

        public Equipe(string nom)
        {
            this.nom = nom;
            Joueurs = new ReadOnlyCollection<Joueur>(joueurs);
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
