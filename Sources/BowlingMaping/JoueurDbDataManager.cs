using BowlingEF.Context;
using BowlingEF.Entities;
using BowlingLib.Model;
using Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                try
                {
                    //Mapping entre la classe joueur et la classe joueurEntity
                    JoueurEntity entity = new JoueurEntity
                    {
                        Id = _joueur.Id,
                        Pseudo = _joueur.Pseudo,
                    };

                    //Parcourt de la liste des parties d'un joueur
                    for (int i = 0; i < _joueur.Parties.Count; i++)
                    {
                        //Mapping entre les parties d'un joueur et les partieEntity d'une partieEntity
                        PartieEntity partieEntity = new PartieEntity
                        {
                            Joueur = entity,
                            Date = _joueur.Parties[i].Date,
                            Score = _joueur.Parties[i].Score

                        };

                        //Parcourt de la liste des frames d'une partie
                        for (int j = 0; j < _joueur.Parties[i].Frames.Count; j++)
                        {
                            //Mapping entre les frames d'une partie et les frameEntity d'une partieEntity
                            FrameEntity frameEntity = new FrameEntity
                            {
                                Id = _joueur.Parties[i].Frames[j].Id,
                                Lancer1 = _joueur.Parties[i].Frames[j].Lancer1.QuillesTombees,
                                Lancer2 = (_joueur.Parties[i].Frames[j].Lancer2 == null) ? 0 : _joueur.Parties[i].Frames[j].Lancer2.QuillesTombees,
                                Lancer3 = (_joueur.Parties[i].Frames[j].Lancer3 == null) ? 0 : _joueur.Parties[i].Frames[j].Lancer3.QuillesTombees,//si Lancer3 est null il prend la valeur Zero
                                Partie = partieEntity
                            };
                            partieEntity.Frames.Add(frameEntity);
                        }
                        entity.PartieEntities.Add(partieEntity);
                    }
                    context.Joueurs.Add(entity);
                    result = await context.SaveChangesAsync() == 1;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw;
                }
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
