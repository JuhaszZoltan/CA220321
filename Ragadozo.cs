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
            throw new NotImplementedException();
        }

        public override Allat Szul()
        {
            throw new NotImplementedException();
        }

        public Ragadozo((int sor, int oszlop) hely, Szavanna szavanna) 
            : base(hely.sor, hely.oszlop, szavanna)
        {

        }
    }
}
