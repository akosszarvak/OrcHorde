using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OrkHorda
{
    public class OrkParaszt : Ork
    {
         public OrkParaszt(int Id, string Nev, int Eletero)
            : this(Id, Nev, Eletero, 30)
        {
        }
        public OrkParaszt(int Id, string Nev, int Eletero, double Sebzes)
            : base(Id, Nev, Eletero, Sebzes)
        {
            this.Nev = (rnd.Next(101) < 70 ? "Ordas " : "Hülye ")
                + this.Nev;
        }
    }
}
