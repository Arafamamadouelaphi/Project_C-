using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp
{
    public class Saissiseur
    {

        public int CollecterReponseMenu()
        {
            while (true)
            {
                try
                {
                    int retour = int.Parse(Console.ReadLine());
                    return retour;
                }
                catch (Exception e)
                {
                    Afficheur.AfficherErreur("de Saisie veuillez recommencer");
                }
            }
        }

        public string CollecteNom()
        {
            string nom = Console.ReadLine();
            return nom;
        }
        public int CollecteNbr()
        {
            return CollectQuilleTomber();
        }
    
    

        public int CollectQuilleTomber()
        {
            while (true)
            {
                try
                {
                    int nbr = int.Parse(Console.ReadLine());
                    return nbr;
                }
                catch (Exception e)
                {
                    Afficheur.AfficherErreur("de Saisie veuillez recommencer");
                }
            }
        }
     }
}
