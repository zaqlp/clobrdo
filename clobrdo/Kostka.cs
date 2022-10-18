using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clobrdo
{
    public class Kostka
    {
        int pocetSten;
        public Kostka(int pocetSten)
        {
            this.pocetSten = pocetSten;
        }
        public int Hod()
        {
            var hod = Random.Shared.Next(1, pocetSten);
            Console.WriteLine($"Kostka hodila {hod}.");
                return hod;
            
        }
    }
}
