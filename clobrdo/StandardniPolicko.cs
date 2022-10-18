using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clobrdo
{
    public class StandardniPolicko : Policko
    {
        Figurka figurka;
        public override void PolozFigurku(Figurka figurka)
        {
            if (JeObsazeno())
            {
                throw new InvalidOperationException("Policko je obsazeno");
            }
            this.figurka = figurka;
        }
        public override bool JeObsazeno()
        {
            return (this.figurka != null);
        }
        public override bool JeTamFigurka(Figurka figurka)
        {
            return (this.figurka == figurka);
        }
        public override Figurka DejFigurkuKVyhozeni()
        {
            return figurka;
        }
        public override void ZvedniFigurku(Figurka figurka)
        {
            if (this.figurka != figurka)
            {
                throw new InvalidOperationException("Figurka na tomto políčku není.");
            }
            this.figurka = null;
        }
        public override void Vypis()
        {
            Console.Write("[");
            if (figurka != null)
            {
                figurka.Vypis();
            }
            
            Console.Write("]");

        }
    }


}
