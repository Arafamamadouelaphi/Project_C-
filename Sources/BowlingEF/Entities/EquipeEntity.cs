using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingEF.Entities
{
    //classe EquipeEntity représentant la table Equipe de la base de données
    public class EquipeEntity
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public List<JoueurEntity> Joueurs { get; set; }
        public EquipeEntity()
        {
            Joueurs = new List<JoueurEntity>();
        }
    }
}
