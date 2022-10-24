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
    /// <summary>
    /// This class is used to create a match
    /// </summary>
    public static class Match
    {
        #region Méthodes

        /// <summary>
        /// Match en Equipe
        /// </summary>
        /// <param name="saissiseur"></param>
        public static void JeuxEnEquipe(Saissiseur saissiseur)
        {
            Afficheur.InviteNrb("Equipe");
            int nbrE = saissiseur.CollecteNbr();
            Afficheur.InviteNrb("Joueur par Equipe");
            int nbrJ = saissiseur.CollecteNbr();
            List<Equipe> equipes = new List<Equipe>();
            for (int i = 0; i < nbrE; i++)
            {
                Afficheur.InviteNom($"Equipe {i+1}");//Recuperer le nom de l'equipe
                string Nom = saissiseur.CollecteNom();
                Equipe equipe = new Equipe(Nom);
                for (int j = 0; j < nbrJ; j++)
                {
                    Console.WriteLine($"Equipe {i + 1}");
                    Afficheur.InviteNom($"Joueur {j + 1}"); //Recuperer le nom des joueur de chaque Equipe
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
                    Lancer(partie, saissiseur);
                    manager.AddPartie(partie);
                }
            }
        }

        /// <summary>
        /// Match en Individuel
        /// </summary>
        /// <param name="saissiseur"></param>
        public static void JeuIndividuel(Saissiseur saissiseur)
        {

            Afficheur.InviteNrb("Joueur");
            int nbrj = saissiseur.CollecteNbr();
            List<Joueur> joueurs = new List<Joueur>();

            // Création des joueurs
            for (int j = 0; j < nbrj; j++)
            {
                Afficheur.InviteNom($"Joueur {j + 1}"); 
                string nomJoueur = saissiseur.CollecteNom();
                Joueur joueur = new Joueur(nomJoueur);
                joueurs.Add(joueur);
            }


            // Création des parties pour chaque joueur
            Manager manager = new Manager(new EquipeDbDataManager(), new PartieDbDataManager(), new JoueurDbDataManager());

            for (int i = 0; i < joueurs.Count; i++)
            {
                Partie partie = new Partie(joueurs[i]);
                manager.AddJoueur(joueurs[i]);
                joueurs.ForEach(item => manager.AddJoueur(item));
                Lancer(partie, saissiseur);
                manager.AddPartie(partie);
            }


            // Lancement pour chaque partie avce  des frame
            for(int j = 0; j<10; j++) // pour chaque frame
            {
                Frame frame = new Frame(j);
                for (int i = 0; i < manager.GetAllPartie().Result.Count(); i++) // on lance les parties à tour de rôle
                {
                    LancerFrame(manager.GetAllPartie().Result.ElementAt(i), saissiseur, frame);
                    manager.AddPartie(manager.GetAllPartie().Result.ElementAt(i));
                }

            }
            



        }

        /// <summary>
        /// Match en Solo
        /// </summary>
        /// <param name="saissiseur"></param>
        public static void JeuSolo(Saissiseur saissiseur)
        {
            Afficheur.InviteNom("Joueur");
            string Nom = saissiseur.CollecteNom();
            Joueur joueur = new Joueur(Nom);
            Partie partie = new Partie(joueur);
            Manager manager = new Manager(new EquipeDbDataManager(), new PartieDbDataManager(), new JoueurDbDataManager());
            manager.AddJoueur(joueur);
            Lancer(partie, saissiseur);
            manager.AddPartie(partie);
        }

        /// <summary>
        /// Faire des lancers
        /// </summary>
        /// <param name="partie"></param>
        /// <param name="saissiseur"></param>
        private static void Lancer(Partie partie,Saissiseur saissiseur)
        {
            for (int i = 0; i < 10; i++)
            {
                Afficheur.AfficheNumFrame(i + 1);
                Frame frame = new Frame(i + 1);
                Afficheur.InviteQuilleTombe(1);
                frame.Lancer1 = new Lancer(saissiseur.CollectQuilleTomber());
                Afficheur.InviteQuilleTombe(2);
                frame.Lancer2 = new Lancer(saissiseur.CollectQuilleTomber());
                partie.AddFrame(frame);
            }
        }
        #endregion

        /// <summary>
        /// Faire des lancers avec des frames spécifiques
        /// </summary>
        /// <param name="partie"></param>
        /// <param name="saissiseur"></param>
        /// <param name="frame"></param>
        private static void LancerFrame(Partie partie, Saissiseur saissiseur,Frame frame)
        { 
                frame.Lancer1 = new Lancer(saissiseur.CollectQuilleTomber());
                Afficheur.InviteQuilleTombe(2);
                frame.Lancer2 = new Lancer(saissiseur.CollectQuilleTomber());
                partie.AddFrame(frame);
          
        }
    }
}
