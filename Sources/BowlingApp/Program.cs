using BowlingApp;
using BowlingLib.Model;
using BowlingMaping;
using Business;
using System;

namespace HelloWorldApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int choix=0;
            while (choix <= 3)
            {
                Afficheur afficheur = new Afficheur();
                Saissiseur saissiseur = new Saissiseur();
                afficheur.AfficherMenu();
                choix = saissiseur.CollecterReponseMenu();
                switch (choix)
                {
                    case 1:
                        Match.JeuSolo(saissiseur, afficheur);
                        break;
                    case 2:
                        Match.JeuIndividuel(saissiseur, afficheur);
                        break;
                    case 3:
                        Match.JeuxEnEquipe(saissiseur, afficheur);
                        break;
                }
            }
        }
    }
}
