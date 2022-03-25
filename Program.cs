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

            szavanna.Terulet[10, 4] = new Teszt();

            szavanna.Megjelenites();
        }
    }

    internal class Teszt : IVanHelye
    {
        public (int S, int O) Hely { get; set; }
    }
}
