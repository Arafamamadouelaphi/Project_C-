using BowlingEF.Context;
using BowlingEF.Entities;
using BowlingLib.Model;
using Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingMaping
{
    /// <summary>
    /// Classe de gestion des données des joueurs
    /// </summary>
    public class JoueurDbDataManager : IDataManager<Joueur>
    {
        #region Méthodes
        /// <summary>
        /// Ajoute un joueur à la liste des joueurs
        /// </summary>
        /// <param name="_joueur"></param>
        /// <returns></returns>
        public async Task<bool> Add(Joueur _joueur)
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
                result =await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        /// <summary>
        /// Supprime un joueur de la liste des joueurs
        /// </summary>
        /// <param name="_joueur"></param>
        /// <returns></returns>
        public async Task< bool> Delete(Joueur _joueur)
        {
            bool result = false;
           
           
          
                using (var context = new BowlingContext())
                {
                    JoueurEntity entity = context.Joueurs.Find(_joueur.Id);
                    context.Joueurs.Remove(entity);
                    result = await context.SaveChangesAsync() == 1;
                }
                return result;
 
           
            
        }

        /// <summary>
        /// recupère tous les joueurs de la Base de données
        /// </summary>
        /// <returns></returns>
        public  async Task<IEnumerable<Joueur>> GetAll()
        {
            using (var context = new BowlingContext())
            {
                List<Joueur> joueurs = new  List<Joueur>();
                foreach (var item in await context.Joueurs.ToListAsync())
                    joueurs.Add(new Joueur(item.Id, item.Pseudo));
                return joueurs;
            }
        }

        /// <summary>
        /// recupère un joueur de la Base de données par son pseudo
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Joueur> GetDataWithName(string name)
        {
            using (var context = new BowlingContext())
            {
                Joueur _joueur = null;

                var query = await context.Joueurs.FirstOrDefaultAsync(n => n.Pseudo == name);
                _joueur = new Joueur(query.Id, query.Pseudo);
                return _joueur;
            }
        }

        public async Task<bool> Update(Joueur _joueur)
        {
            bool result = false;
            using (var context = new BowlingContext())
            {
                JoueurEntity entity = context.Joueurs?.Find(_joueur.Id);
                if (entity!=null)
                {
                    entity.Pseudo = _joueur.Pseudo;
                    result = await context.SaveChangesAsync() == 1;
                }
            }
            return result;
        }
        #endregion

    }
}
