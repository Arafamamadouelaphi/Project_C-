
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
    public class EquipeDbDataManager : IDataManager<Equipe>
    {
        #region Méthodes
        public async Task<bool> Add(Equipe _equipe)
        {
            bool result = false;
            using (var context = new BowlingContext())
            {
                EquipeEntity entity = new EquipeEntity
                {
                    Id = _equipe.Id,
                    Nom = _equipe.Nom,
                    
                };

                for(int i = 0; i<_equipe.Joueurs.Count; i++)
                {
                    JoueurEntity joueur = new JoueurEntity
                    {
                        Id = _equipe.Joueurs[i].Id,
                        Pseudo = _equipe.Joueurs[i].Pseudo,
                        //Equipe = entity                       

                    };

                    entity.Joueurs.Add(joueur);
                }

                context.Equipes.Add(entity);
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<bool> Delete(Equipe _equipe)
        {
            bool result = false;
            using (var context = new BowlingContext())
            {
                EquipeEntity entity = context.Equipes.Find(_equipe.Id);
                context.Equipes.Remove(entity);
                result =await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<IEnumerable<Equipe>> GetAll()
        {
            using (var context = new BowlingContext())
            {
                return await  context.Equipes.Select(e => new Equipe 
                (
                    e.Id,
                    e.Nom,
                    e.Joueurs.Select(j => new Joueur(j.Id, j.Pseudo)).ToArray()
                )).ToListAsync();
            }
        }

        public async Task<Equipe> GetDataWithName(string name)
        {
            using (var context = new BowlingContext())
            {
                return await context.Equipes.Where(e => e.Nom == name).Select(e => new Equipe
                (
                    e.Id,
                    e.Nom,
                    e.Joueurs.Select(j => new Joueur(j.Id, j.Pseudo)).ToArray()
                )).FirstOrDefaultAsync();
            }
        }

        public async Task< bool> Update(Equipe data)
        {
            bool result = false;
            using (var context = new BowlingContext())
            {
                EquipeEntity entity =  context.Equipes.Find(data.Id);
                entity.Nom = data.Nom;
                entity.Joueurs = data.Joueurs.Select(j => new JoueurEntity
                {
                    Id = j.Id,
                    Pseudo = j.Pseudo
                }).ToList();
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }
        #endregion
    }
}
