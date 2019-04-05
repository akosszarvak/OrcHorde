using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OrkHorda
{
  public  class OrkSaman : Ork
    {
        public OrkSaman(int Id, string Nev, int Eletero)
            : this(Id, Nev, Eletero, 30)
        {
        }
        public OrkSaman(int Id, string Nev, int Eletero, double Sebzes)
            : base(Id, Nev, Eletero, Sebzes)
        {
            this.Nev = "Tiszteletreméltó "
                + this.Nev;
        }
        public OrkSaman(int Id, string Nev, int Eletero, double Sebzes,
            TermeszetiEro TermeszetiEro, bool TanacsTag)
            : this(Id, Nev, Eletero, Sebzes)
        {
            this.TermeszetiEro = TermeszetiEro;
            this.TanacsTag = TanacsTag;
        }

        public TermeszetiEro TermeszetiEro { get; set; }
        public static string TermeszetiEroNev(TermeszetiEro TermeszetiEro)
        {
            switch (TermeszetiEro)
            {
                case TermeszetiEro.Tuz:
                    return "Tűz";
                case TermeszetiEro.Viz:
                    return "Víz";
                case TermeszetiEro.Jeg:
                    return "Jég";
                case TermeszetiEro.Szel:
                    return "Szél";
                case TermeszetiEro.Fold:
                    return "Föld";
                default:
                    throw new Exception("Nem definiált természeti erő");
            }
        }

        private bool tanacsTag;
        public bool TanacsTag
        {
            set
            {
                if (!tanacsTag)
                    tanacsTag = value;
            }
            get { return tanacsTag; }
        }

        public override string Eszik(Etel Etel)
        {
            return base.Eszik(Etel) + ", majd elpakol maga után";
        }

        new public string Regenerálódik(Etel Etel)
        {
            string s = "";
            s += Eszik(Etel) + "\n";
            s += string.Format("{0} életereje {1} értékről", Nev, Eletero);
            Gyogyul(Etel.Kaloria);
            s += string.Format(" {0} értékre növekedett\n", Eletero);
            s += Pihen(0) + "\n";
            return s;
        }

        public override string ToString()
        {
            string minta = "Természeti erő: {0}\n" +
                "{1}agja az ork tanácsnak\n";
            return base.ToString() +
                string.Format(minta,
                TermeszetiEroNev(TermeszetiEro),
                TanacsTag ? "T" : "Nem t");
        }
    }
}
