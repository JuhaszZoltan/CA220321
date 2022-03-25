using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA220321
{
    internal class Fu : ICella
    {
        public (int S, int O) Hely { get; set; }

        public Fu(int sor, int oszlop)
        {
            this.Hely = (sor, oszlop);
        }
    }
}
