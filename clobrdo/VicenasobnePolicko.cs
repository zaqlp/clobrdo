using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clobrdo
{
    public class VicenasobnePolicko: Policko
    {
       protected List<Figurka> figurky = new ();
      public override void PolozFigurku(Figurka figurka)
    {
        figurky.Add(figurka);
            
    }
        public override bool JeObsazeno()
        {
            return false;
        }

        public override bool JeTamFigurka(Figurka figurka)
        {
            return figurky.Contains(figurka);
            //Contains Jestli tam je
        }
        public override Figurka DejFigurkuKVyhozeni()
        {
            return null;
        }
        public override void ZvedniFigurku(Figurka figurka)
        {
            figurky.Remove(figurka);
        }
        public override void Vypis()
        {
            Console.Write("[");
            foreach (var figurka in figurky)
            {
                figurka.Vypis();
            }

            Console.Write("]");
        }
    }
}
