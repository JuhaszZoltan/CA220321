using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA220321
{
    internal class Program
    {
        static Random rnd = new Random();

        static void Main()
        {
            var szavanna = new Szavanna(40, 20);
            szavanna.Benepesites();

            int ts = rnd.Next(szavanna.Terulet.GetLength(0));
            int to = rnd.Next(szavanna.Terulet.GetLength(1));
            var tesztalany = new Teszt((ts, to), szavanna);
            //szavanna.Terulet[ts, to] = tesztalany;


            for (int i = 0; i < 10; i++)
            {
                szavanna.Megjelenites();
                Console.Write("\n\nsor: ");
                int sor = int.Parse(Console.ReadLine());
                Console.Write("oszlop: ");
                int oszlop = int.Parse(Console.ReadLine());
                Console.Clear();
                (szavanna.Terulet[tesztalany.Hely.S, tesztalany.Hely.O] as Allat).Mozog((sor, oszlop));
            }

            Console.ReadKey();

        }
    }

    internal class Teszt : Allat
    {
        public override bool Ivarerett => throw new NotImplementedException();

        public override bool Eszik()
        {
            throw new NotImplementedException();
        }

        public override Allat Szul()
        {
            throw new NotImplementedException();
        }

        public Teszt((int sor, int oszlop) hely, Szavanna szavanna)
            : base(hely.sor, hely.oszlop, szavanna)
        {

        }
    }
}
