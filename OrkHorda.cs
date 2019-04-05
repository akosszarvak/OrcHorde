using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OrkHorda
{
   public class OrkHorda
    {
        private int id = 1;

        public Azeroth Azeroth { get; set; }
        public OrkHorda()
        {
            orkok = new List<Ork>();
        }


        private List<Ork> orkok;
        public List<Ork> Orkok
        {
            get
            {
                return new List<Ork>(orkok);
                 
                //List<Ork> temp = new List<Ork>();
                //foreach (Ork ork in orkok)
                //    temp.Add(ork);
                //return temp;
            }
        }
        public List<Ork> EloOrkok
        {
            get
            {
                List<Ork> temp = new List<Ork>();
                foreach (Ork ork in orkok)
                {
                    if (!ork.Halott)
                        temp.Add(ork);
                }
                return temp;
            }
        }
        public List<OrkSaman> EloSamanok
        {
            get
            {
                List<OrkSaman> temp = new List<OrkSaman>();
                foreach (Ork ork in EloOrkok)
                {
                    if (ork is OrkSaman)
                        temp.Add(ork as OrkSaman);
                }
                return temp;
            }
        }
        public List<OrkHarcos> EloHarcosok
        {
            get
            {
                List<OrkHarcos> temp = new List<OrkHarcos>();
                foreach (Ork ork in EloOrkok)
                {
                    if (ork is OrkHarcos)
                        temp.Add(ork as OrkHarcos);
                }
                return temp;
            }
        }


        public List<OrkParaszt> EloParaszt
        {
            get
            {
                List<OrkParaszt> temp = new List<OrkParaszt>();
                foreach (Ork ork in EloOrkok)
                {
                    if (ork is OrkParaszt)
                        temp.Add(ork as OrkParaszt);
                }
                return temp;
            }
        }
        public void HozzaadOrkHarcos(string Nev, int Eletero, 
            double Sebzes, Fegyver Fegyver, int Pancel)
        {
            orkok.Add(new OrkHarcos(id, Nev, Eletero, Sebzes, Fegyver, Pancel));
            id++;
        }
        public void HozzaadOrkSaman(string Nev, int Eletero, double Sebzes,
            TermeszetiEro TermeszetiEro, bool TanacsTag)
        {
            orkok.Add(new OrkSaman(id, Nev, Eletero, Sebzes, TermeszetiEro, TanacsTag));
            id++;
        }

        public void HozzaadOrkParaszt(string Nev, int Eletero,
            double Sebzes)
        {
            orkok.Add(new OrkParaszt(id, Nev, Eletero, Sebzes));
            id++;
        }

        public int TanacstagokSzama
        {
            get
            {
                return EloSamanok.Where(s => s.TanacsTag).Count();
                //int db = 0;
                //foreach (OrkSaman saman in EloSamanok)
                //{
                //    if (saman.TanacsTag)
                //        db++;
                //}
                //return db;
            }
        }
        public List<OrkHarcos> AdottFegyverrelZuzok(Fegyver Fegyver)
        {
            return EloHarcosok.Where(harcos => harcos.Fegyver == Fegyver).ToList();

            //List<OrkHarcos> temp = new List<OrkHarcos>();
            //foreach (OrkHarcos harcos in EloHarcosok)
            //{
            //    if (harcos.Fegyver == Fegyver)
            //        temp.Add(harcos);
            //}
            //return temp;
        }
    }
}
