using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingEF.Entities
{
    /// <summary>
    /// Classe de gestion des equipes
    /// </summary>
    public class EquipeEntity
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public ICollection<JoueurEntity> Joueurs { get; set; }
        public EquipeEntity()
        {
            Joueurs = new List<JoueurEntity>();
        }
    }
}
