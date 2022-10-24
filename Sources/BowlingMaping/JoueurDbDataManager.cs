using BowlingEF.Context;
using BowlingEF.Entities;
using BowlingLib.Model;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingMaping
{
    public class JoueurDbDataManager : IDataManager<Joueur>
    {
        /// <summary>
        /// Ajoute un joueur à la liste des joueurs
        /// </summary>
        /// <param name="_joueur"></param>
        /// <returns></returns>
        public bool Add(Joueur _joueur)
        {
            bool result = false;
            using (var context = new BowlingContext())
            {
                JoueurEntity entity=new JoueurEntity
                {
                    Id = _joueur.Id,
                    Pseudo = _joueur.Pseudo,
                };
                context.Joueurs.Add(entity);
                result = context.SaveChanges() == 1;
            }
            return result;
        }

        /// <summary>
        /// Supprime un joueur de la liste des joueurs
        /// </summary>
        /// <param name="_joueur"></param>
        /// <returns></returns>
        public bool Delete(Joueur _joueur)
        {
            bool result = false;
           
           
           try{
                using (var context = new BowlingContext())
                {
                    JoueurEntity entity = context.Joueurs.Find(_joueur.Id);
                    context.Joueurs.Remove(entity);
                    result = context.SaveChanges() == 1;
                }
                return result;

           }catch (SqlException)
            {
                WriteLine("Votre base de données n'existe pas.");
            }
           
            
        }

        /// <summary>
        /// recupère tous les joueurs de la Base de données
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Joueur> GetAll()
        {
            using (var context = new BowlingContext())
            {
                List<Joueur> joueurs = new List<Joueur>();
                foreach (var item in context.Joueurs)
                    joueurs.Add(new Joueur(item.Id, item.Pseudo));
                return joueurs;
            }
        }

        /// <summary>
        /// recupère un joueur de la Base de données par son pseudo
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Joueur GetDataWithName(string name)
        {
            using (var context = new BowlingContext())
            {
                Joueur _joueur = null;
                
                var query = from joueur in context.Joueurs
                            where joueur.Pseudo == name
                            select joueur;
                foreach (var item in query)
                    _joueur = new Joueur(item.Id, item.Pseudo);
                return _joueur;
            }
        }

        public bool Update(Joueur _joueur)
        {
            bool result = false;
            using (var context = new BowlingContext())
            {
                JoueurEntity entity = context.Joueurs?.Find(_joueur.Id);
                entity.Pseudo = _joueur.Pseudo;
                result = context.SaveChanges() == 1;
            }
            return result;
        }
        
    }
}
