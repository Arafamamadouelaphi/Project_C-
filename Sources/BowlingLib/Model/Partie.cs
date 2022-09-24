using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.Model
{
    public class Partie
    {
        private Joueur joueur;
        private List<Frame> frames;

        public Joueur Joueur
        {
            get { return joueur; }
            set { joueur = value; }
        }

        public List<Frame> Frames
        {
            get { return frames; }
            set { frames = value; }
        }

        public Partie(Joueur joueur)
        {
            this.joueur = joueur;
            frames = new List<Frame>();
        }

        public void AddFrame(Frame frame)
        {
            frames.Add(frame);
        }

        public int GetScore()
        {
            int score = 0;
            foreach (Frame frame in frames)
            {
                score += frame.Score;
            }
            return score;
        }

        public int GetScore(int frameNumber)
        {
            int score = 0;
            for (int i = 0; i < frameNumber; i++)
            {
                score += frames[i].Score;
            }
            return score;
        }
    }
}
