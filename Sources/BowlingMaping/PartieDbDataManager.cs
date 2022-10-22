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
    public class PartieDbDataManager : IPartieDbDataManager
    {

        /// <summary>
        /// Ajoute une partie Dans la base de données
        /// </summary>
        /// <param name="_partie"></param>
        /// <returns></returns>
        public bool Add(Partie _partie)
        {
            bool result = false;
            using (var context = new BowlingContext())
            {
                PartieEntity entity = new PartieEntity
                {
                    Id = _partie.Id,
                    Date = _partie.Date,
                    JoueurId = _partie.Joueur.Id,
                    Score = _partie.Score
                };
                context.Parties.Add(entity);
                result = context.SaveChanges() == 1;
            }
            return result;
        }

        /// <summary>
        /// Supprime une partie de la base de données
        /// </summary>
        /// <param name="_partie"></param>
        /// <returns></returns>
        public bool Delete(Partie _partie)
        {
            bool result = false;
            using (var context = new BowlingContext())
            {
                PartieEntity entity = context.Parties.Find(_partie.Id);
                context.Parties.Remove(entity);
                result = context.SaveChanges() == 1;
            }
            return result;
        }

        /// <summary>
        /// Modifie une partie dans la base de données
        /// </summary>
        /// <param name="_partie"></param>
        /// <returns></returns>
        public bool Update(Partie _partie)
        {
            bool result = false;
            using (var context = new BowlingContext())
            {
                PartieEntity entity = context.Parties.Find(_partie.Id);
                entity.Date = _partie.Date;
                entity.JoueurId = _partie.Joueur.Id;
                entity.Score = _partie.Score;
                result = context.SaveChanges() == 1;
            }
            return result;
        }

        /// <summary>
        /// Retourne une partie de la base de données en fonction de son nom
        /// </summary>
        /// <param name="_partie"></param>
        /// <returns></returns>
        public Partie GetDataWithName(string name)
        {
            Partie result = null;
            using (var context = new BowlingContext())
            {
                PartieEntity entity = context.Parties.Find(name);
                Joueur joueur = new Joueur(entity.Joueur.Id, entity.Joueur.Pseudo);
                List<Frame> frames = new List<Frame>();
                foreach (FrameEntity frameEntity in entity.Frames)
                {
                    Frame frame = new Frame(frameEntity.Id, frameEntity.Numero, frameEntity.Lancer1, frameEntity.Lancer2, frameEntity.Lancer3);
                    frames.Add(frame);
                }
                result = new Partie(entity.Id, joueur, frames, entity.Date, entity.Score);
            }
            return result;
        }

        /// <summary>
        /// Retourne Toutes les parties en base de donné
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Partie> GetAll()
        {
            List<Partie> result = new List<Partie>();
            using (var context = new BowlingContext())
            {
                foreach (PartieEntity entity in context.Parties.OrderBy(item => item.Date))
                {
                    Joueur joueur = new Joueur(entity.Joueur.Id, entity.Joueur.Pseudo);
                    List<Frame> frames = new List<Frame>();
                    foreach (FrameEntity frameEntity in entity.Frames)
                    {
                        Frame frame = new Frame(frameEntity.Id, frameEntity.Numero, frameEntity.Lancer1, frameEntity.Lancer2, frameEntity.Lancer3);
                        frames.Add(frame);
                    }
                    result.Add(new Partie(entity.Id, joueur, frames, entity.Date, entity.Score));
                }
            }
            return result;
        }


        public IEnumerable<Partie> GetAllWithDate(DateTime date)
        {
            List<Partie> result = new List<Partie>();
            using (var context = new BowlingContext())
            {
                foreach (PartieEntity entity in context.Parties.OrderBy(item => item.Date))
                {
                    if (entity.Date == date)
                    {
                        Joueur joueur = new Joueur(entity.Joueur.Id, entity.Joueur.Pseudo);
                        List<Frame> frames = new List<Frame>();
                        foreach (FrameEntity frameEntity in entity.Frames)
                        {
                            Frame frame = new Frame(frameEntity.Id, frameEntity.Numero, frameEntity.Lancer1, frameEntity.Lancer2, frameEntity.Lancer3);
                            frames.Add(frame);
                        }
                        result.Add(new Partie(entity.Id, joueur, frames, entity.Date, entity.Score));
                    }
                }
            }
            return result;
        }

    }
}
