using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA220321
{
    internal abstract class Allat : IVanHelye
    {
        public int Eletkor { get; set; }
        public int MaxEletkor { get; set; }
        public int Ehseg { get; set; }
        public bool Nem { get; set; }
        public bool El { get; set; }
        public (int O, int S) Hely { get; set; }
        protected int EveSzaporodott { get; set; } = 0;
        public abstract bool Ivarerett { get; }
        public Szavanna Szavanna { get; set; }
        public void Oregszik()
        {
            throw new NotImplementedException();
        }

        private List<IVanHelye> KornyezoMezok
        {
            get
            {
                var kornyezoMezok = new List<IVanHelye>();

                var ko = this.Hely.O == 0 ? 0 : this.Hely.O - 1;
                var ks = this.Hely.S == 0 ? 0 : this.Hely.S - 1;
                var vo = this.Hely.O == this.Szavanna.Terulet.GetLength(0) - 1
                    ? this.Szavanna.Terulet.GetLength(0) - 1
                    : this.Hely.O + 1;
                var vs = this.Hely.S == this.Szavanna.Terulet.GetLength(1) - 1
                    ? this.Szavanna.Terulet.GetLength(1) - 1
                    : this.Hely.S + 1;

                for (int o = ko; o <= vo; o++)
                {
                    for (int s = ks; s <= vs; s++)
                    {
                        if (o != this.Hely.O || s != this.Hely.S)
                        {
                            kornyezoMezok.Add(this.Szavanna.Terulet[o, s]);
                        }
                    }
                }
                return kornyezoMezok;
            }
        }

        private List<Allat> KornyezoHimek
        {
            get
            {
                var kornyezoHimek = new List<Allat>();
                foreach (var m in KornyezoMezok)
                {
                    if (m is Allat
                        && m.GetType() == this.GetType()
                        && (m as Allat).Nem
                        && (m as Allat).Ivarerett)
                        kornyezoHimek.Add(m as Allat);
                }
                return kornyezoHimek;
            }
        }

        protected bool TudSzulni
        {
            get
            {
                if (this.Nem) return false;
                if (this.Ehseg > 0) return false;
                if (!this.Ivarerett) return false;
                if (this.EveSzaporodott == 0) return false;
                if (!this.KornyezoMezok.Any(e => e is Fu)) return false;
                if (this.KornyezoHimek.Count == 0) return false;

                return true;
            }
        }

        public abstract Allat Szul();
        public abstract bool Eszik();

        public void Mozog()
        {
            throw new NotImplementedException();
        }
    }
}
