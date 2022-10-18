using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clobrdo
{
    public class Figurka
    {
        
        public string Oznaceni { get; init; }
        
        public Figurka(string oznaceni)
        {
            this.Oznaceni = oznaceni;
        }
        public void Vypis()
        {
            Console.Write(this.Oznaceni);
        }
    }
}
