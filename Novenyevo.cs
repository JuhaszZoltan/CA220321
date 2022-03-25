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

        public override Allat Szul()
        {
            throw new NotImplementedException();
        }

        public Novenyevo((int sor, int oszlop) hely, Szavanna szavanna) :
            base(hely.sor, hely.oszlop, szavanna)
        { 

        }
    }
}
