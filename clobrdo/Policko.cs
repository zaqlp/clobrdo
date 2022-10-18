using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clobrdo
{
    public abstract class Policko
    {
        public abstract void PolozFigurku(Figurka figurka);
        public abstract bool JeObsazeno();
        public abstract bool JeTamFigurka(Figurka figurka);

        public abstract Figurka DejFigurkuKVyhozeni();
        public abstract void ZvedniFigurku(Figurka figurka);
        public abstract void Vypis();
    }
}
