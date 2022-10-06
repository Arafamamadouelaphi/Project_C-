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

        public int Id { get; set; }
    }
}
