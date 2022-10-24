using BowlingApp;
using BowlingLib.Model;
using BowlingMaping;
using Business;
using System;

namespace HelloWorldApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int choix=0;
            while (choix <= 3)
            {
                Saissiseur saissiseur = new Saissiseur();
                Afficheur.AfficherMenu();
                choix = saissiseur.CollecterReponseMenu();
                switch (choix)
                {
                    case 1:
                        Match.JeuSolo(saissiseur);
                        break;
                    case 2:
                        Match.JeuIndividuel(saissiseur);
                        break;
                    case 3:
                        Match.JeuxEnEquipe(saissiseur);
                        break;
                }
            }
        }
    }
}
