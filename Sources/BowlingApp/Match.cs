using BowlingLib.Model;
using BowlingMaping;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp
{
    public class Match
    {
     
        public static void JeuxEnEquipe(Saissiseur saissiseur,Afficheur afficheur)
        {
            afficheur.InviteNrb("Equipe");
            int nbrE = saissiseur.CollecteNbr();
            afficheur.InviteNrb("Joueur par Equipe");
            int nbrJ = saissiseur.CollecteNbr();
            List<Equipe> equipes = new List<Equipe>();
            for (int i = 0; i < nbrE; i++)
            {
                afficheur.InviteNom($"Equipe {i+1}");//Recuperer le nom de l'equipe
                string Nom = saissiseur.CollecteNom();
                Equipe equipe = new Equipe(Nom);
                for (int j = 0; j < nbrJ; j++)
                {
                    Console.WriteLine($"Equipe {i + 1}");
                    afficheur.InviteNom($"Joueur {j + 1}"); //Recuperer le nom des joueur de chaque Equipe
                    string nomJoueur = saissiseur.CollecteNom();
                    Joueur joueur = new Joueur(nomJoueur);
                    equipe.AjouterJoueur(joueur);
                }
                equipes.Add(equipe);
            }

            for (int i = 0; i < equipes.Count; i++)
            {
                for (int j = 0; j < equipes[i].Joueurs.Count; j++)
                {
                    Joueur joueur = equipes[i].Joueurs[j];
                    Partie partie = new Partie(joueur);
                    Manager manager = new Manager(new EquipeDbDataManager(), new PartieDbDataManager(), new JoueurDbDataManager());
                    manager.AddJoueur(joueur);
                    equipes.ForEach(item => manager.AddEquipe(item));
                    Lancer(partie, saissiseur, afficheur);
                    manager.AddPartie(partie);
                }
            }
        }
        public static void JeuIndividuel(Saissiseur saissiseur, Afficheur afficheur)
        {
            afficheur.InviteNrb("Joueur");
            int nbrj = saissiseur.CollecteNbr();
            List<Joueur> joueurs = new List<Joueur>();
            for (int j = 0; j < nbrj; j++)
            {
                afficheur.InviteNom($"Joueur {j + 1}"); 
                string nomJoueur = saissiseur.CollecteNom();
                Joueur joueur = new Joueur(nomJoueur);
                joueurs.Add(joueur);
            }
            for (int i = 0; i < joueurs.Count; i++)
            {
                Joueur joueur = joueurs[i];
                Partie partie = new Partie(joueur);
                Manager manager = new Manager(new EquipeDbDataManager(), new PartieDbDataManager(), new JoueurDbDataManager());
                manager.AddJoueur(joueur);
                joueurs.ForEach(item => manager.AddJoueur(item));
                Lancer(partie, saissiseur, afficheur);
                manager.AddPartie(partie);


            }




        }

        public static void JeuSolo(Saissiseur saissiseur, Afficheur afficheur)
        {
            afficheur.InviteNom("Joueur");
            string Nom = saissiseur.CollecteNom();
            Joueur joueur = new Joueur(Nom);
            Partie partie = new Partie(joueur);
            Manager manager = new Manager(new EquipeDbDataManager(), new PartieDbDataManager(), new JoueurDbDataManager());
            manager.AddJoueur(joueur);
            Lancer(partie, saissiseur, afficheur);
            manager.AddPartie(partie);
        }

        private static void Lancer(Partie partie,Saissiseur saissiseur,Afficheur afficheur)
        {
            for (int i = 0; i < 10; i++)
            {
                afficheur.AfficheNumFrame(i + 1);
                Frame frame = new Frame(i + 1);
                afficheur.InviteQuilleTombe(1);
                frame.Lancer1 = new Lancer(saissiseur.CollectQuilleTomber());
                afficheur.InviteQuilleTombe(2);
                frame.Lancer2 = new Lancer(saissiseur.CollectQuilleTomber());
                partie.AddFrame(frame);
            }
        }
      
    }
}
