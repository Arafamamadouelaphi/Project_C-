using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.Model
{
    public class Frame
    {
        const int MAX_QUILLE = 10;
        public int Numero {
            get
            { return numero; }
            set
            {
                this.numero = value;

            }
        }
        private int numero;


        public int QuillesRestantes 
        { get
            {
                return quillesRestantes;
            }
            set
            {
                this.quillesRestantes = value;
            }
        }
        private int quillesRestantes;

        public int QuillesTombees 
        {
            get
            {
                return QuillesTombees;
            } 
            set
            {
                this.QuillesTombees = value;
            }
        }
        private int quillesTombees;

        public bool IsStrike { 
            get {
                return isStrike;
            } 
            set{
                this.isStrike = value;
               } 
        }
        private bool isStrike;

        public bool IsSpare 
        { 
            get 
            {
                return isPark;
            } 
            set
            {
                this.isPark = value;
            } 
        }
        private bool isPark;

        public bool IsFinished
        {
            get
            { 
                return isFinished; 
            } 
            set 
            {
                this.isFinished = value;
            }

        }
        private bool isFinished;

        public Lancer Lancer1 
        {
            get
            { 
                return lancer1; 
            }
            set 
            { 
                this.lancer1 = value;
            }
        }
        private Lancer lancer1;

        public Lancer Lancer2
        {
            get { return lancer2; }
            set { this.lancer2 = value; }
        }
        private Lancer lancer2;
        public Lancer Lancer3
        {
            get { return lancer3; }
            set { this.lancer3 = value; }
        }
        private Lancer lancer3;

        public Frame(int numero)
        {
            this.Numero = numero;
            this.QuillesRestantes = MAX_QUILLE;
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
                    if (quillesTombees == MAX_QUILLE)
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
                        if (quillesTombees == MAX_QUILLE)
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
                        if (quillesTombees + this.Lancer1.QuillesTombees == MAX_QUILLE)
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
                        if (quillesTombees == MAX_QUILLE)
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
                        if (quillesTombees + this.Lancer2.QuillesTombees == MAX_QUILLE)
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
                        if (quillesTombees + this.Lancer2.QuillesTombees == MAX_QUILLE)
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
                if (quillesTombees == MAX_QUILLE)
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
