using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OrkHorda
{
   public class Ork
    {
        protected static Random rnd = new Random();

        private Ork(int Id)
        {
            this.Id = Id;
            this.Eletero = 100;
            this.Sebzes = 30;
        }
        public Ork(int Id, string Nev, int Eletero)
            : this(Id)
        {
            this.Nev = Nev;
            this.Eletero = Eletero;
        }
        public Ork(int Id, string Nev, int Eletero, double Sebzes)
            : this(Id, Nev, Eletero)
        {
            this.Sebzes = Sebzes;
        }

        private int id;
        public int Id
        {
            private set
            {
                if (value >= 1) id = value;
                else throw new Exception("Hibás azonosító: " + value);
            }
            get { return id; }
        }

        private string nev;
        public string Nev
        {
            protected set
            {
                if (value != null && value.Length >= 5)
                    nev = value;
                else throw new Exception("Hibás név: " + value);
            }
            get { return nev; }
        }

        private int eletero;
        public int Eletero
        {
            set
            {
                if (value <= 100)
                    eletero = value;
                else throw new Exception("Hibás életerő: " + value);
            }
            get { return eletero; }
        }

        private double sebzes;
        public double Sebzes
        {
            private set
            {
                if (value >= 30 && value < 70)
                    sebzes = value;
                else throw new Exception("Hibás sebzés: " + value);
            }
            get { return sebzes; }
        }

        public bool Halott
        {
            get { return eletero <= 0; }
        }

        public virtual string Eszik(Etel Etel)
        {
            return string.Format("{0} leul, megterít és kényelmesen elfogyasztja a(z) {1}-t ", Nev, Etel.Nev);
        }

        public void Gyogyul(int Ertek)
        {
            this.Eletero = this.Eletero + Ertek <= 100 ? this.Eletero = Ertek : 100;
        }

        public string Pihen(int Ido)
        {
            string s = "";
            if(Ido >= 0)
            {
                s += "Z";
            for (int i = 1; i < Ido; i++)
            {
                s += "z";
            }
            s += "...";
        }
            return s;
        }

        public string Regenerálódik(Etel Etel)
        {
            string s = "";
            s += Eszik(Etel) + "\n";
            s += string.Format("{0} életereje {1} értékről", Nev, Eletero);
            Gyogyul(Etel.Kaloria);
            s += string.Format(" {0} értékre növekedett\n", Eletero);
            s += Pihen(3) + "\n";
            return s;
        }
        public override string ToString()
        {
            string minta = 
                "Azonosító: {0}\n"+
                "Név: {1}\n"+
                "Életerő: {2}\n"+
                "Sebzés: {3:0.##}\n"+
                "{4} ork\n";
            return string.Format(minta,
                Id,
                Nev,
                Eletero,
                Sebzes,
                Halott ? "Halott" : "Élő");
        }
    }
}
