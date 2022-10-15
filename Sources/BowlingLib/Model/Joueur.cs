using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.Model
{
    public class Joueur 
    {
        private string pseudo;
        private readonly long id;
        public long Id
        {
            get { return id; }
        }

        public Joueur(string pseudo)
        {
            this.Pseudo = pseudo;
        }

        public string Pseudo
        {
            get { return pseudo; }
            set 
            {

                pseudo = value;
                if (pseudo == null || pseudo == "" || pseudo.Length < 3)
                {
                    throw new ArgumentException("Le pseudo ne peut pas être vide");
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Joueur joueur &&
                   pseudo == joueur.pseudo &&
                   Pseudo == joueur.Pseudo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(pseudo, id, Id, Pseudo);
        }
    }
}
