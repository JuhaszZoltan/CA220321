using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA220321
{
    internal class Ragadozo : Allat
    {
        public override bool Ivarerett => Eletkor >= 2;

        public override bool Eszik()
        {
            if (!this.KornyezoMezok.Any(m => m is Novenyevo))
            {
                Ehseg += 1;
                return false;
            }

            var kornyezoNovenyevok = this.KornyezoMezok.Where(m => m is Novenyevo)
                .ToList();

            var aldozat = kornyezoNovenyevok[_rnd.Next(kornyezoNovenyevok.Count)];

            (aldozat as Novenyevo).El = false;

            Szavanna.Terulet[aldozat.Hely.S, aldozat.Hely.O] 
                = new Fu(aldozat.Hely.S, aldozat.Hely.O);

            this.Ehseg = 0;
            return true;
        }

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
                    maxEletkor: _rnd.Next(9, 13),
                    nem: _rnd.Next(100) < 50);
            }
        }

        public Ragadozo(
            (int sor, int oszlop) hely,
            Szavanna szavanna,
            int maxEletkor,
            bool nem) :
            base(hely.sor, hely.oszlop, szavanna, maxEletkor, nem) { }
    }
}
