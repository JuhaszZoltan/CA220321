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
            var tesztalany = new Teszt((ts, to), szavanna, 10, true);
            //szavanna.Terulet[ts, to] = tesztalany;


            for (int i = 0; i < 30; i++)
            {
                szavanna.Megjelenites();
                //Console.Write("\n\nsor: ");
                //int sor = int.Parse(Console.ReadLine());
                //Console.Write("oszlop: ");
                //int oszlop = int.Parse(Console.ReadLine());

                System.Threading.Thread.Sleep(500);
                Console.Clear();
                (szavanna.Terulet[tesztalany.Hely.S, tesztalany.Hely.O] as Allat).Mozog();
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

        public override void Szul()
        {
            throw new NotImplementedException();
        }

        public Teszt(
            (int sor, int oszlop) hely,
            Szavanna szavanna,
            int maxEletkor,
            bool nem) :
            base(hely.sor, hely.oszlop, szavanna, maxEletkor, nem)
        {

        }
    }
}
