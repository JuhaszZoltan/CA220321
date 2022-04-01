using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA220321
{
    internal class Novenyevo : Allat
    {
        public override bool Ivarerett => Eletkor >= 1;

        public override bool Eszik() => true;

        public override void Szul()
        {
            if (TudSzulni)
            {
                var kornyezoUresHelyek = this.KornyezoMezok.Where(m => m is Fu)
                    .ToList();
                var helyAhovaSzul = kornyezoUresHelyek[_rnd.Next(kornyezoUresHelyek.Count)].Hely;

                new Novenyevo(
                    hely: helyAhovaSzul,
                    szavanna: this.Szavanna,
                    maxEletkor: _rnd.Next(11, 15),
                    nem: _rnd.Next(100) < 50);
            }
        }



        public Novenyevo(
            (int sor, int oszlop) hely,
            Szavanna szavanna, int maxEletkor, bool nem) :
            base(hely.sor, hely.oszlop, szavanna, maxEletkor, nem)
        { 

        }
    }
}
