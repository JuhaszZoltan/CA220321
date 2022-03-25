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

        public ICella[,] Terulet { get; set; }
        public List<Allat> Allatok
        {
            get
            {
                var allatok = new List<Allat>();
                foreach (var c in Terulet)
                {
                    if (c is Allat) allatok.Add(c as Allat);
                }
                return allatok;
            }
        }
        public Szavanna(int sorokSzama, int oszlopokSzama)
        {
            this.Terulet = new ICella[oszlopokSzama, sorokSzama];
            for (int s = 0; s < Terulet.GetLength(0); s++)
            {
                for (int o = 0; o < Terulet.GetLength(1); o++)
                {
                    Terulet[s, o] = new Fu(s, o);
                }
            }
        }
        public void Benepesites()
        {
            for (int i = 0; i < 200; )
            {
                int s = rnd.Next(Terulet.GetLength(0));
                int o = rnd.Next(Terulet.GetLength(1));

                if (Terulet[s, o] is Fu)
                {
                    if (rnd.Next(100) < 65)
                    {
                        new Novenyevo(
                            hely: (s, o),
                            szavanna: this);
                    }
                    else new Ragadozo(
                        hely: (s, o),
                        szavanna: this);
                    i++;
                }
            }

        }
        public void Megjelenites()
        {
            for (int s = 0; s < Terulet.GetLength(0); s++)
            {
                for (int o = 0; o < Terulet.GetLength(1); o++)
                {
                    if (Terulet[s, o] is Ragadozo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("R");
                    }
                    else if (Terulet[s, o] is Teszt)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("T");
                    }
                    else if (Terulet[s, o] is Novenyevo)
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
