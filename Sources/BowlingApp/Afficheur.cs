using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp
{
    /// <summary>
    /// Classe pour gerer l'affichage en console
    /// </summary>
    public class Afficheur
    {
        #region Méthodes
        
        /// <summary>
        /// Afficher le menu de l'application
        /// </summary>
        public static void AfficherMenu()
        {
            System.Console.WriteLine("Choisissez le mode de jeux :");
            System.Console.WriteLine("1 - Solo ? ");
            System.Console.WriteLine("2 - Indivuduelle?");
            System.Console.WriteLine("3- Equipe?");

        }

        /// <summary>
        /// Afficher les erreur de saisie
        /// </summary>
        /// <param name="message"></param>
        public static void AfficherErreur(String message)
        {
            Console.WriteLine($"erreur {message}");
        }

        /// <summary>
        /// Affiche le numéro de frame
        /// </summary>
        /// <param name="i"></param>
        public static void AfficheNumFrame(int i)
        {
            Console.WriteLine($"Frame {i}");
        }

        public static void InviteNom(string type)
        {
            Console.WriteLine($"veillez entrez le nom {type} ");
        }

        public static void InviteNrb(string type)
        {
            Console.WriteLine($"veillez entrez le nombre de {type}");
        }

        public static void InviteQuilleTombe(int i)
        {
            Console.WriteLine($"Entrez le nombre de quilles tombés du lancer {i}");
        }

        public static void InviteNomJoueur(string pseudo)
        {
            Console.WriteLine($"Tour  {pseudo}");
        }
        #endregion
    }
}
