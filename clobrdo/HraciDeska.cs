using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clobrdo
{
    public abstract class HraciDeska
    {
        public abstract int MaximalniPocetHracu { get;}


        public abstract void PolozFigurkuNaStart(Figurka figurka);

        public abstract bool JeFigurkaVDomecku (Figurka figurka);

        public abstract bool PosunFigurku(Figurka figurka, int PocetPolicek);

        public abstract bool CilJeDomecek(Figurka figurka, int PocetPolicek);

        public abstract bool JeTamFigurkaKVyhozeni(Figurka figurka, int PocetPolicek);

        public abstract int JakDalekoPolickaOdStartu(Figurka figurka, int PocetPolicek);

        public abstract void Vypis();
        
    }
}
