using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OrkHorda
{
    public class Azeroth
    {
        //singletonná tenni Azerothot
        //Hordát levédeni

        public Azeroth()
        {
            Horda = new OrkHorda();
            Horda.Azeroth = this;

            Etelek = new List<Etel>()
            {
                new Etel("Hamuban sült kenyér", 2),
            new Etel("Emberi agyvelő", 11),
            new Etel("Varázsgomba gyökér", 4)
            };
        }


        public OrkHorda Horda { get; set; }
        public List<Etel> Etelek { get; set; }
    }
}
