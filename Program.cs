using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OrkHorda
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Azeroth Azeroth = new Azeroth();
            OrkHorda Horda = new OrkHorda();



            for (int i = 1; i <= 350; i++)
                Azeroth.Horda.HozzaadOrkHarcos("Ork harcos " + i,
                    rnd.Next(100),
                    rnd.NextDouble() * (70 - 30) + 30,
                    (Fegyver)rnd.Next(Enum.GetNames(typeof(Fegyver)).Length),
                    rnd.Next(41));
            for (int i = 1; i <= 50; i++)
                Azeroth.Horda.HozzaadOrkSaman("Ork sámán " + i,
                    rnd.Next(100),
                    rnd.NextDouble() * (70 - 30) + 30,
                    (TermeszetiEro)rnd.Next(Enum.GetNames(typeof(TermeszetiEro)).Length),
                    rnd.NextDouble() < 0.2);

            for (int i = 1; i <= 50; i++)
                Azeroth.Horda.HozzaadOrkParaszt("Ork paraszt " + i,
                    rnd.Next(100),
                    rnd.NextDouble() * (70 - 30) + 30
                    );

            Console.WriteLine("\nAz ork horda tanácsának {0} tagja van.",
                Horda.TanacstagokSzama);

            //List<OrkHarcos> baltasok = Horda.AdottFegyverrelZuzok(Fegyver.Balta);
            //OrkHarcos bena = baltasok.First();
            //foreach (OrkHarcos harcos in baltasok)
            //{
            //    if (bena.Pancel > harcos.Pancel)
            //        bena = harcos;
            //}
            //
            //Console.WriteLine("A leggyengébb baltás ork:\n");
            //Console.WriteLine(bena);

            OrkParaszt Paraszt = Azeroth.Horda.EloParaszt.First();
            OrkHarcos Harcos = Azeroth.Horda.EloHarcosok.First();
            OrkSaman Saman = Azeroth.Horda.EloSamanok.First();

            Console.WriteLine(Paraszt.Regenerálódik(Azeroth.Etelek[0]));
            Console.WriteLine(Harcos.Regenerálódik(Azeroth.Etelek[1]));
            Console.WriteLine(Saman.Regenerálódik(Azeroth.Etelek[2]));

            Console.ReadLine();
        }
    }
}
