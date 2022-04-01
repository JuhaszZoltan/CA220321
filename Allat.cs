using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA220321
{
    internal abstract class Allat : ICella
    {
        public int Eletkor { get; set; }
        public int MaxEletkor { get; set; }
        public int Ehseg { get; set; }
        public bool Nem { get; set; }
        public bool El { get; set; }
        public (int S, int O) Hely
        {
            get
            {
                for (int s = 0; s < this.Szavanna.Terulet.GetLength(0); s++)
                {
                    for (int o = 0; o < this.Szavanna.Terulet.GetLength(1); o++)
                    {
                        if (this.Szavanna.Terulet[s, o] == this)
                            return (s, o);
                    }
                }
                return (-1, -1);
            }
        }
        protected int EveSzaporodott { get; set; } = 0;
        public abstract bool Ivarerett { get; }
        public Szavanna Szavanna { get; set; }

        private List<ICella> KornyezoMezok
        {
            get
            {
                var kornyezoMezok = new List<ICella>();

                var ko = this.Hely.S == 0 ? 0 : this.Hely.S - 1;
                var ks = this.Hely.O == 0 ? 0 : this.Hely.O - 1;
                var vo = this.Hely.S == this.Szavanna.Terulet.GetLength(0) - 1
                    ? this.Szavanna.Terulet.GetLength(0) - 1
                    : this.Hely.S + 1;
                var vs = this.Hely.O == this.Szavanna.Terulet.GetLength(1) - 1
                    ? this.Szavanna.Terulet.GetLength(1) - 1
                    : this.Hely.O + 1;

                for (int s = ko; s <= vo; s++)
                {
                    for (int o = ks; o <= vs; o++)
                    {
                        if (s != this.Hely.O || o != this.Hely.S)
                        {
                            kornyezoMezok.Add(this.Szavanna.Terulet[s, o]);
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

        public bool Mozog((int s, int o) hova)
        {
            if (this.Szavanna.Terulet[hova.s, hova.o] is Fu)
            {
                int uresedo_s = this.Hely.S;
                int uresedo_o = this.Hely.O;
                this.Szavanna.Terulet[hova.s, hova.o] = this;
                this.Szavanna.Terulet[uresedo_s, uresedo_o] = new Fu(uresedo_s,uresedo_o);
                return true;
            }
            return false;
        }

        public Allat(int h_sor, int h_oszlop, Szavanna szavanna)
        {
            this.Szavanna = szavanna;
            this.Szavanna.Terulet[h_sor, h_oszlop] = this;
        }
    }
}
