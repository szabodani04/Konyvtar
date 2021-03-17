using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtar
{
    class Konyvek
    {
        public int KonyvID { get; set; }
        public string Cim { get; set; }
        public string Szerzo { get; set; }
        public string Kiadas { get; set; }
        public string Kiado { get; set; }
        public bool Vanekolcsonben { get; set; }


        public Konyvek(string sor)
        {
            string[] asd = sor.Split(';');
            KonyvID = int.Parse(asd[0]);
            Szerzo = asd[1];
            if (Szerzo == "")
            {
                Szerzo = "";
            }
            Kiadas = (asd[3]);
            Cim = asd[2];
            Kiado = asd[4];
            Vanekolcsonben = Convert.ToBoolean(asd[5]);
        }
    }
}
