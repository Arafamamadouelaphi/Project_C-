using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.Model
{
    public class Partie
    {

        public Joueur Joueur { get; set; }

        public List<Frame> Frames { get; set; }

        public Partie(Joueur joueur)
        {
            this.Joueur = joueur;
            Frames = new List<Frame>();
        }

        public void AddFrame(Frame frame)
        {
            Frames.Add(frame);
        }

        public int? GetScore()
        {
            int? score = 0;
            for (int i = 0; i < Frames.Count; i++)
            {
                score += Frames[i].QuillesTombees;
                if (i<Frames.Count-1)
                {
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
            }
            return score;
        }
    }
}
