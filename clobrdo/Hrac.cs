using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clobrdo
{
    internal class Hrac
    {
        public string Jmeno { get; init; }

        public List<Figurka> Figurky { get; } = new();
        public Hrac (string jmeno)
        {
            this.Jmeno = jmeno;
        }
        public void PridejFigurku(Figurka figurka)
        {
            Figurky.Add(figurka);
        }
       

    }
}
