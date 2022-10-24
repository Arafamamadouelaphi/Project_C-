using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp
{
    /// <summary>
    /// Classe pour gerer la saisie
    /// </summary>
    public class Saissiseur
    {
        #region Méthodes
        /// <summary>
        /// Récuperer le choix de l'utilisateur
        /// </summary>
        /// <returns></returns>
        public int CollecterReponseMenu()
        {
            while (true)
            {
                try
                {
                    int retour = int.Parse(Console.ReadLine());
                    return retour;
                }
                catch (Exception)
                {
                    Afficheur.AfficherErreur("de Saisie veuillez recommencer");
                }
            }
        }
        
        /// <summary>
        /// Recupérer le nom
        /// </summary>
        /// <returns></returns>
        public string CollecteNom()
        {
            string nom = Console.ReadLine();
            return nom;
        }
        
        /// <summary>
        /// Recupérer le nombre
        /// </summary>
        /// <returns></returns>
        public int CollecteNbr()
        {
            return CollectQuilleTomber();
        }
    
    
        /// <summary>
        /// Récuperer le nombre de qulles tombé
        /// </summary>
        /// <returns></returns>
        public int CollectQuilleTomber()
        {
            while (true)
            {
                try
                {
                    int nbr = int.Parse(Console.ReadLine());
                    return nbr;
                }
                catch (Exception)
                {
                    Afficheur.AfficherErreur("de Saisie veuillez recommencer");
                }
            }
        }
        #endregion
    }
}
