using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtar
{
    class Kolcsonzes
    {
        public int KolcsonID { get; set; }
        public int KolcsonTagID { get; set; }
        public int KolcsonKonyvID { get; set; }
        public string Kezdes { get; set; }
        public string Visszahozta { get; set; }

        public Kolcsonzes(string sor)
        {
                string[] asd = sor.Split(';');
                KolcsonID = int.Parse(asd[0]);
                KolcsonTagID = int.Parse(asd[1]);
                KolcsonKonyvID = int.Parse(asd[2]);
                Kezdes = asd[3];
                Visszahozta = asd[4];
        }
    }
}
