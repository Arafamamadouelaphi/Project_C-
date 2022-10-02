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
        public ReadOnlyCollection<Frame> Frames;
        public Joueur Joueur { get; private set; }

        private List<Frame> frames;

        public Partie(Joueur joueur)
        {
            this.Joueur = joueur;
            Frames = new ReadOnlyCollection<Frame>(frames);
        }

        public void AddFrame(Frame frame)
        {
            frames.Add(frame);
        }

        public int? GetScore()
        {
            int? score = 0;
            for (int i = 0; i < Frames.Count; i++)
            {
                score += Frames[i].QuillesTombees;
                if (Frames[i].IsStrike)
                {
                    score += Frames[i + 1].QuillesTombees;
                    if (Frames[i + 1].IsStrike && i < Frames.Count - 2)
                    {
                        score += Frames[i + 2].QuillesTombees;
                    }
                }
                else if (Frames[i].IsSpare)
                {
                    score += Frames[i + 1].Lancer1.QuillesTombees;
                }
            }
            return score;
        }
    }
}
