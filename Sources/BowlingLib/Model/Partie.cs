using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.Model
{
    public class Partie
    {
        //public ReadOnlyCollection<Frame> Frames;
        public Joueur Joueur { get; private set; }
        public object Id { get; set; }

        public List<Frame> Frames;

        /// <summary>
        ///  Constructeur
        /// </summary>
        /// <param name="joueur"></param>
        public Partie(Joueur joueur)
        {
            this.Joueur = joueur;
            Frames = new List<Frame>();
        }

        /// <summary>
        /// Ajoute un frame à la partie
        /// </summary>
        /// <param name="frame"></param>
        public void AddFrame(Frame frame)
        {
            Frames.Add(frame);
        }


        /// <summary>
        /// Calcule le score de la partie
        /// </summary>
        /// <returns>le Score d'une partie</returns>
        public int? GetScore()
        {
            int? score = 0;
            for (int i = 0; i < Frames.Count; i++)
            {
                score += Frames[i].QuillesTombees;
                if (Frames[i].IsStrike && i < Frames.Count - 1)
                {
                    score += Frames[i + 1].QuillesTombees;
                    if (Frames[i + 1].IsStrike && i < Frames.Count - 2)
                    {
                        score += Frames[i + 2].QuillesTombees;
                    }
                }
                else if (Frames[i].IsSpare && i < Frames.Count - 1)
                {
                    score += Frames[i + 1].Lancer1.QuillesTombees;
                }
            }
            return score;
        }
    }
}
