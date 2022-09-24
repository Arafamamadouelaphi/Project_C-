using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.Model
{
    public class Frame
    {
        private int numero;
        private int score;
        private int quillesRestantes;
        private int quillesTombees;
        private bool isStrike;
        private bool isSpare;
        private bool isFinished;
        private Lancer lancer1;
        private Lancer lancer2;
        private Lancer lancer3;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public int QuillesRestantes
        {
            get { return quillesRestantes; }
            set { quillesRestantes = value; }
        }

        public int QuillesTombees
        {
            get { return quillesTombees; }
            set { quillesTombees = value; }
        }

        public bool IsStrike
        {
            get { return isStrike; }
            set { isStrike = value; }
        }

        public bool IsSpare
        {
            get { return isSpare; }
            set { isSpare = value; }
        }

        public bool IsFinished
        {
            get { return isFinished; }
            set { isFinished = value; }
        }

        public Lancer Lancer1
        {
            get { return lancer1; }
            set { lancer1 = value; }
        }

        public Lancer Lancer2
        {
            get { return lancer2; }
            set { lancer2 = value; }
        }

        public Lancer Lancer3
        {
            get { return lancer3; }
            set { lancer3 = value; }
        }

        public Frame(int numero)
        {
            this.numero = numero;
            this.quillesRestantes = 10;
            this.isFinished = false;
            this.isStrike = false;
            this.isSpare = false;
        }

        public void Lancer(int quillesTombees)
        {
            if (quillesTombees > quillesRestantes)
            {
                throw new ArgumentException("Le nombre de quilles tombees doit etre inferieur au nombre de quilles restantes");
            }
            if (quillesTombees < 0)
            {
                throw new ArgumentException("Le nombre de quilles tombees doit et etre positif");
            }

            if (this.numero == 10)
            {
                if (this.lancer1 == null)
                {
                    this.lancer1 = new Lancer(quillesTombees);
                    this.quillesRestantes -= quillesTombees;
                    this.quillesTombees += quillesTombees;
                    if (quillesTombees == 10)
                    {
                        this.isStrike = true;
                    }
                }
                else if (this.lancer2 == null)
                {
                    this.lancer2 = new Lancer(quillesTombees);
                    this.quillesRestantes -= quillesTombees;
                    this.quillesTombees += quillesTombees;
                    if (this.isStrike)
                    {
                        if (quillesTombees == 10)
                        {
                            this.isStrike = true;
                        }
                        else
                        {
                            this.isStrike = false;
                        }
                    }
                    else
                    {
                        if (quillesTombees + this.lancer1.QuillesTombees == 10)
                        {
                            this.isSpare = true;
                        }
                    }
                }
                else if (this.lancer3 == null)
                {
                    this.lancer3 = new Lancer(quillesTombees);
                    this.quillesRestantes -= quillesTombees;
                    this.quillesTombees += quillesTombees;
                    if (this.isStrike)
                    {
                        if (quillesTombees == 10)
                        {
                            this.isStrike = true;
                        }
                        else
                        {
                            this.isStrike = false;
                        }
                    }
                    else if (this.isSpare)
                    {
                        if (quillesTombees + this.lancer2.QuillesTombees == 10)
                        {
                            this.isSpare = true;
                        }
                        else
                        {
                            this.isSpare = false;
                        }
                    }
                    else
                    {
                        if (quillesTombees + this.lancer2.QuillesTombees == 10)
                        {
                            this.isSpare = true;
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Le nombre de lancers est deja atteint");
                }
            }
            else
            {
                if (this.lancer1 == null)
                {
                    this.lancer1 = new Lancer(quillesTombees);
                }
                else if (this.lancer2 == null)
                {
                    this.lancer2 = new Lancer(quillesTombees);
                }
                else
                {
                    throw new ArgumentException("Le nombre de lancers est deja atteint");
                }
                this.quillesRestantes -= quillesTombees;
                this.quillesTombees += quillesTombees;
                if (quillesTombees == 10)
                {
                    this.isStrike = true;
                }
                else if (this.quillesRestantes == 0)
                {
                    this.isSpare = true;
                }
            }
            if (this.quillesRestantes == 0 || this.lancer2 != null)
            {
                this.isFinished = true;
            }
        }
    }
}
