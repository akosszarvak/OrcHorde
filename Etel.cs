using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OrkHorda
{
    public class Etel
    {
        public Etel(string Nev, int Kaloria)
        {
            this.Nev = Nev;
            this.Kaloria = Kaloria;
        }
        public string Nev { get; set; }
        public int Kaloria { get; set; }
    }
}
