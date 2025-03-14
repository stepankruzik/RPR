using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hra
{
    internal class Hrac
    {
        public enum SpecializaceType { Kouzelník, Berserker, Inženýr, Cizák }
        public enum Oblicij { VelkýNos, Ušoplesk, MakeUp }
        public enum Vlasy { Drdol, Culík, Pleška }
        public enum BarvaVlasů { Kaštanová, Blond, Červená }

        private Oblicij _oblicij;
        private Vlasy _vlasy;
        private BarvaVlasů _barvaVlasu;

        public SpecializaceType Specializace { get; set; }
        public int XP { get; private set; }

        public Hráč(string jmeno, SpecializaceType specializace, Oblicij oblicij, Vlasy vlasy, BarvaVlasů barva)
        : base(jmeno)
        {
            Specializace = specializace;
            _oblicij = oblicij;
            _vlasy = vlasy;
            _barvaVlasu = barva;
        }

        public void PridejXP(int hodnota)
        {
            
        }

        public override string ToString()
        {
            
        }
    }
}
