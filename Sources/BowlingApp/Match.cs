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
            Manager manager = new Manager(new EquipeDbDataManager(), new PartieDbDataManager(), new JoueurDbDataManager());
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
                manager.AddEquipe(equipe);
            }

            for (int i = 0; i < equipes.Count; i++)
            {
                for (int j = 0; j < equipes[i].Joueurs.Count; j++)
                {
                    Joueur joueur = equipes[i].Joueurs[j];
                    Partie partie = new Partie(joueur);
                    manager.AddJoueur(joueur);
                    LancerBoulle(partie, saissiseur);
                    manager.AddPartie(partie);
                }
            }
        }

        /// <summary>
        /// Match en Individuel
        /// </summary>
        /// <param name="saissiseur"></param>
        public static async void JeuIndividuel(Saissiseur saissiseur)
        {

            // Création des parties pour chaque joueur
            Manager manager = new Manager(new EquipeDbDataManager(), new PartieDbDataManager(), new JoueurDbDataManager());


            Afficheur.InviteNrb("Joueur");
            int nbrj = saissiseur.CollecteNbr();
            List<Joueur> joueurs = new List<Joueur>();
            List<Partie> partiees = new List<Partie>();
            bool verit = false;
            int nbPartie = 1; // Nombre de partie pour chaque joueur
            // Création des joueurs et leur partie
            for (int j = 0; j < nbrj; j++)
            {
                Afficheur.InviteNom($"Joueur {j + 1}");
                string nomJoueur = saissiseur.CollecteNom();
                Joueur joueur = new Joueur(nomJoueur);
                Partie partie = new Partie(joueur);


                joueurs.Add(joueur);
                partiees.Add(partie);
                // verit =   await manager.AddJoueur(joueur);
            }

            Console.WriteLine(verit);

            for (int p = 0; p < nbPartie; p++)
            {
                // Lancement pour chaque partie avce  10 frames
                for (int j = 0; j < 10; j++) // 
                {

                    for (int i = 0; i < partiees.Count; i++) // on lance les parties à tour de rôle
                    {
                        Frame frame = new Frame(j + 1);
                        Afficheur.InviteNomJoueur(joueurs[i].Pseudo);
                        LancerFrame(partiees.ElementAt(i), saissiseur, frame);
                        //  await  manager.UpdatePartie(joueurs.ElementAt(i).Parties.ElementAt(p));

                    }

                }
            }

            for (int i = 0; i < joueurs.Count; i++)
            {
                joueurs[i].AddPartie(partiees[i]);
                verit = await manager.AddJoueur(joueurs[i]);
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
            LancerBoulle(partie, saissiseur);
            joueur.AddPartie(partie);
            manager.AddJoueur(joueur);
        }
        
        /// <summary>
        /// Faire des lancers
        /// </summary>
        /// <param name="partie"></param>
        /// <param name="saissiseur"></param"""
        private static void LancerBoulle(Partie partie,Saissiseur saissiseur)
        {
            //Création des Frames pour la Partie
            for (int i = 0; i < 10; i++)
            {
                Afficheur.AfficheNumFrame(i + 1);
                Frame frame = new Frame(i + 1);
                Afficheur.InviteQuilleTombe(1);
                frame.Lancer(saissiseur.CollectQuilleTomber());//Premier lancer du Frame

                //Faire le deuxième lancer si le premier n'est pas un strike
                if (!frame.IsStrike)
                {
                    Afficheur.InviteQuilleTombe(2);
                    frame.Lancer(saissiseur.CollectQuilleTomber());
                }

                //Faire le troisième du dernier frame lancer si le premier est un strike ou le deuxième est un spare
                if (i == 9 && (frame.IsStrike || frame.IsSpare))
                {
                    Afficheur.InviteQuilleTombe(3);
                    frame.Lancer(saissiseur.CollectQuilleTomber());
                }
                partie.AddFrame(frame);//ajout du frame à la partie
                Console.WriteLine(partie.GetScore());//affichage du score à la fin de chaque frame
            }
        }



        /// <summary>
        /// Faire des lancers avec des frames spécifiques
        /// </summary>
        /// <param name="partie"></param>
        /// <param name="saissiseur"></param>
        /// <param name="frame"></param>
        private static void LancerFrame(Partie partie, Saissiseur saissiseur, Frame frame)
        {
            Afficheur.AfficheNumFrame(frame.Numero);

            Afficheur.InviteQuilleTombe(1);
            frame.Lancer(saissiseur.CollectQuilleTomber());

            if (!frame.IsStrike)
            {
                Afficheur.InviteQuilleTombe(2);
                frame.Lancer(saissiseur.CollectQuilleTomber());
            }
            //Faire le troisième du dernier frame lancer si le premier est un strike ou le deuxième est un spare
            if (frame.Numero == 10 && (frame.IsStrike || frame.IsSpare))
            {
                Afficheur.InviteQuilleTombe(3);
                frame.Lancer(saissiseur.CollectQuilleTomber());
            }
            partie.AddFrame(frame);//ajout du frame à la partie
            Console.WriteLine(partie.GetScore());//affichage du score à la fin de chaque frame
            partie.AddFrame(frame);


        }
        #endregion
    }
}
