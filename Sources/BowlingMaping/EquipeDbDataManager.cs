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
    public class EquipeDbDataManager : IDataManager<Equipe>
    {
        public bool Add(Equipe _equipe)
        {
            bool result = false;
            using (var context = new BowlingContext())
            {
                EquipeEntity entity = new EquipeEntity
                {
                    Id = _equipe.Id,
                    Nom = _equipe.Nom,
                    Joueurs = _equipe.Joueurs.Select(j => new JoueurEntity
                    {
                        Id = j.Id,
                        Pseudo = j.Pseudo
                    }).ToList()
                };
                context.Equipes.Add(entity);
                result = context.SaveChanges() == 1;
            }
            return result;
        }

        public bool Delete(Equipe _equipe)
        {
            bool result = false;
            using (var context = new BowlingContext())
            {
                EquipeEntity entity = context.Equipes.Find(_equipe.Id);
                context.Equipes.Remove(entity);
                result = context.SaveChanges() == 1;
            }
            return result;
        }

        public IEnumerable<Equipe> GetAll()
        {
            using (var context = new BowlingContext())
            {
                return context.Equipes.Select(e => new Equipe
                (
                    e.Id,
                    e.Nom,
                    e.Joueurs.Select(j => new Joueur(j.Id, j.Pseudo)).ToArray()
                )).ToList();
            }
        }

        public Equipe GetDataWithName(string name)
        {
            using (var context = new BowlingContext())
            {
                return context.Equipes.Where(e => e.Nom == name).Select(e => new Equipe
                (
                    e.Id,
                    e.Nom,
                    e.Joueurs.Select(j => new Joueur(j.Id, j.Pseudo)).ToArray()
                )).FirstOrDefault();
            }
        }

        public bool Update(Equipe data)
        {
            bool result = false;
            using (var context = new BowlingContext())
            {
                EquipeEntity entity = context.Equipes.Find(data.Id);
                entity.Nom = data.Nom;
                entity.Joueurs = data.Joueurs.Select(j => new JoueurEntity
                {
                    Id = j.Id,
                    Pseudo = j.Pseudo
                }).ToList();
                result = context.SaveChanges() == 1;
            }
            return result;
        }
    }
}
