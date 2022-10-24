using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp
{
    public class Afficheur
    {   
        public void AfficherMenu()
        {
            System.Console.WriteLine("Choisissez le mode de jeux :");
            System.Console.WriteLine("1 - Solo ? ");
            System.Console.WriteLine("2 - Indivuduelle?");
            System.Console.WriteLine("3- Equipe?");

        }
        public static void AfficherErreur(String message)
        {
            Console.WriteLine($"erreur {message}");
        }

        public void AfficheNumFrame(int i)
        {
            Console.WriteLine($"Frame {i}");
        }

        public void InviteNom(string type)
        {
            Console.WriteLine($"veillez entrez le nom {type} ");
        }

        public void InviteNrb(string type)
        {
            Console.WriteLine($"veillez entrez le nombre de {type}");
        }

        public void InviteQuilleTombe(int i)
        {
            Console.WriteLine($"Entrez le nombre de quilles tombés du lancer {i}");
        }
    }
}
