using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OrkHorda
{
   public class OrkHarcos : Ork
    {
        public OrkHarcos(int Id, string Nev, int Eletero)
            : this(Id, Nev, Eletero, 30)
        {
        }
        public OrkHarcos(int Id, string Nev, int Eletero, double Sebzes)
            : base(Id, Nev, Eletero, Sebzes)
        {
            this.Nev = (rnd.Next(101) < 70 ? "Rettegett " : "Koponyazúzó ")
                + this.Nev;
        }
        public OrkHarcos(int Id, string Nev, int Eletero, double Sebzes,
            Fegyver Fegyver, int Pancel)
            : this(Id, Nev, Eletero, Sebzes)
        {
            this.Fegyver = Fegyver;
            this.Pancel = Pancel;
        }

        public Fegyver Fegyver { get; set; }
        public static string FegyverNev(Fegyver Fegyver)
        {
            switch (Fegyver)
            {
                case Fegyver.Balta:
                    return "Balta";
                case Fegyver.Kalapacs:
                    return "Kalapács";
                case Fegyver.KeteluFejsze:
                    return "Kétélű fejsze";
                default:
                    throw new Exception("Nem definiált fegyver");
            }
        }
        public void FegyverCsere(Fegyver Fegyver)
        {
            this.Fegyver = Fegyver;
        }

        private int pancel;
        public int Pancel
        {
            set
            {
                if (value >= 0 && value <= 40)
                    pancel = value;
                else throw new Exception("Hibás páncél: " + value);
            }
            get { return pancel; }
        }


        new public string Eszik(Etel Etel)
        {
            return string.Format("{0} kihúzza fegyverét ellenségéből, leteríti azt a véres földre, "+
                "ráül a fejére, majd annak hátán sietve elfogyasztja a(z) {1} -t", Nev, Etel.Nev);
        }
        new public string Regenerálódik(Etel Etel)
        {
            string s = "";
            s += Eszik(Etel) + "\n";
            s += string.Format("{0} életereje {1} értékről", Nev, Eletero);
            Gyogyul(Etel.Kaloria);
            s += string.Format(" {0} értékre növekedett\n", Eletero);
            s += Pihen(2) + "\n";
            return s;
        }
        public override string ToString()
        {
            string minta = "Fegyver: {0}\n" +
                "Páncél: {1}\n";
            return base.ToString() +
                string.Format(minta,
                FegyverNev(Fegyver),
                Pancel);
        }
    }
}
