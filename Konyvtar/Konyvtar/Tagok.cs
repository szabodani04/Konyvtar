using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtar
{
    class Tagok
    {
        public int Tag { get; set; }
        public string Nev { get; set; }
        public string Szul { get; set; }
        public string Iranyitoszam { get; set; }
        public string Varos { get; set; }
        public string Utca { get; set; }

        public Tagok(string sor)
        {
                string[] asd = sor.Split(';');
                Tag = int.Parse(asd[0]);
                Nev = asd[1];
                Szul = asd[2];
                Iranyitoszam = asd[3];
                Varos = asd[4];
                Utca = asd[5];
        }
    }
}
