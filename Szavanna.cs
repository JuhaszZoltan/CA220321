using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA220321
{
    internal class Szavanna
    {
        private static Random rnd = new Random();

        public IVanHelye[,] Terulet { get; set; }
        public Szavanna(int sorokSzama, int oszlopokSzama)
        {
            this.Terulet = new IVanHelye[oszlopokSzama, sorokSzama];
            for (int o = 0; o < Terulet.GetLength(0); o++)
            {
                for (int s = 0; s < Terulet.GetLength(1); s++)
                {
                    Terulet[o, s] = new Fu();
                }
            }
        }
        public void Benepesites()
        {
            for (int i = 0; i < 200; )
            {
                int o = rnd.Next(Terulet.GetLength(0));
                int s = rnd.Next(Terulet.GetLength(1));

                if (Terulet[o, s] is Fu)
                {
                    if (rnd.Next(100) < 65)
                    {
                        Terulet[o, s] = new Novenyevo();
                    }
                    else Terulet[o, s] = new Ragadozo();
                    i++;
                }
            }

        }
        public void Megjelenites()
        {
            for (int o = 0; o < Terulet.GetLength(0); o++)
            {
                for (int s = 0; s < Terulet.GetLength(1); s++)
                {
                    if (Terulet[o, s] is Ragadozo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("R");
                    }
                    else if (Terulet[o, s] is Teszt)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("T");
                    }
                    else if (Terulet[o, s] is Novenyevo)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("N");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(".");
                    }
                }
                Console.Write('\n');
            }
            Console.ResetColor();
        }
    }
}
