using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210426
{
    struct TesztKerdes
    {
        public string Kerdes { get; set; }
        public string[] ValaszLehetosegek { get; set; }
        public char Megoldas { get; set; }

        //0 == A
        //1 == B
        //2 == C

        public TesztKerdes(string kerdes, string[] valaszLehetosegek, char megoldas)
        {
            Kerdes = kerdes;
            ValaszLehetosegek = valaszLehetosegek;
            Megoldas = megoldas;
        }
    }
}
