using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BowlingLib.Model
{
    /// <summary>
    /// Classe Model Joueur
    /// </summary>
    public class Joueur : IEquatable<Joueur>
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

        public Joueur(long id,string pseudo) : this(pseudo)
        {
            this.id = id;
        }

        public string Pseudo
        {
            get { return pseudo; }
           private set 
            {

                pseudo = value;
                if (string.IsNullOrWhiteSpace(pseudo) || pseudo.Length < 3)
                {
                    throw new ArgumentException("Le pseudo ne peut pas être vide");
                }
            }
        }

       public bool Equals(Joueur other)
       {
            return Pseudo.Equals(other.Pseudo);
        }
 
        public void setNom(string nom)
        {
            Pseudo = nom;
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(obj, null)) return false;
            if(ReferenceEquals(obj, this)) return true;
            if(GetType() != obj.GetType()) return false;
            return Equals(obj as Joueur);
        }

        public override int GetHashCode()
        {
            return Pseudo.GetHashCode();
        }
       /* public override int GetHashCode()
        {
            return HashCode.Combine(id, Id, Pseudo);
        }*/
    }
}
