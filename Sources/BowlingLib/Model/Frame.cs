using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.Model
{
    public class Frame
    {
        public int Numero { get; set; }


        public int QuillesRestantes { get; set; }

        public int QuillesTombees { get; set; }

        public bool IsStrike { get; set; }

        public bool IsSpare { get; set; }

        public bool IsFinished { get; set; }

        public Lancer Lancer1 { get; set; }

        public Lancer Lancer2 { get; set; }

        public Lancer Lancer3 { get; set; }

        public Frame(int numero)
        {
            this.Numero = numero;
            this.QuillesRestantes = 10;
            this.IsFinished = false;
            this.IsStrike = false;
            this.IsSpare = false;
        }

        public void Lancer(int quillesTombees)
        {
            if (quillesTombees > QuillesRestantes)
            {
                throw new ArgumentException("Le nombre de quilles tombees doit etre inferieur au nombre de quilles restantes");
            }
            if (quillesTombees < 0)
            {
                throw new ArgumentException("Le nombre de quilles tombees doit et etre positif");
            }

            if (this.Numero == 10)
            {
                if (this.Lancer1 == null)
                {
                    this.Lancer1 = new Lancer(quillesTombees);
                    this.QuillesRestantes -= quillesTombees;
                    this.QuillesTombees += quillesTombees;
                    if (quillesTombees == 10)
                    {
                        this.IsStrike = true;
                    }
                }
                else if (this.Lancer2 == null)
                {
                    this.Lancer2 = new Lancer(quillesTombees);
                    this.QuillesRestantes -= quillesTombees;
                    this.QuillesTombees += quillesTombees;
                    if (this.IsStrike)
                    {
                        if (quillesTombees == 10)
                        {
                            this.IsStrike = true;
                        }
                        else
                        {
                            this.IsStrike = false;
                        }
                    }
                    else
                    {
                        if (quillesTombees + this.Lancer1.QuillesTombees == 10)
                        {
                            this.IsSpare = true;
                        }
                    }
                }
                else if (this.Lancer3 == null)
                {
                    this.Lancer3 = new Lancer(quillesTombees);
                    this.QuillesRestantes -= quillesTombees;
                    this.QuillesTombees += quillesTombees;
                    if (this.IsStrike)
                    {
                        if (quillesTombees == 10)
                        {
                            this.IsStrike = true;
                        }
                        else
                        {
                            this.IsStrike = false;
                        }
                    }
                    else if (this.IsSpare)
                    {
                        if (quillesTombees + this.Lancer2.QuillesTombees == 10)
                        {
                            this.IsSpare = true;
                        }
                        else
                        {
                            this.IsSpare = false;
                        }
                    }
                    else
                    {
                        if (quillesTombees + this.Lancer2.QuillesTombees == 10)
                        {
                            this.IsSpare = true;
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
                if (this.Lancer1 == null)
                {
                    this.Lancer1 = new Lancer(quillesTombees);
                }
                else if (this.Lancer2 == null)
                {
                    this.Lancer2 = new Lancer(quillesTombees);
                }
                else
                {
                    throw new ArgumentException("Le nombre de lancers est deja atteint");
                }
                this.QuillesRestantes -= quillesTombees;
                this.QuillesTombees += quillesTombees;
                if (quillesTombees == 10)
                {
                    this.IsStrike = true;
                }
                else if (this.QuillesRestantes == 0)
                {
                    this.IsSpare = true;
                }
            }
            if (this.QuillesRestantes == 0 || this.Lancer2 != null)
            {
                this.IsFinished = true;
            }
        }
    }
}
