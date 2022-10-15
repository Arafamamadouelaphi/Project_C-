using BowlingEF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingEF.Context
{
    public class BowlingContext : DbContext
    {
        public DbSet<JoueurEntity> Joueurs { get; set; }
        public DbSet<EquipeEntity> Equipes { get; set; }
        public DbSet<PartieEntity> Parties { get; set; }
        public DbSet<FrameEntity> Frames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bowling.db");
        }

    }
}
