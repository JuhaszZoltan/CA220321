using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA220321
{
    internal class Program
    {
        static void Main()
        {
            var szavanna = new Szavanna(40, 20);
            szavanna.Benepesites();

            szavanna.Terulet[4, 10] = new Teszt();
            //TODO: MINDENHOL 'sor't kicserélni 'oszlop'ra, mert így stzar

            szavanna.Megjelenites();
        }
    }

    internal class Teszt : IVanHelye
    {
        public (int O, int S) Hely { get; set; }
    }
}
