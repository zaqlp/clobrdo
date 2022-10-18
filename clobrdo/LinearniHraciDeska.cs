using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clobrdo
{
    internal class LinearniHraciDeska : HraciDeska
    {
        public override int MaximalniPocetHracu
        {
            get
            {
                return int.MaxValue;
            }
        }
        List<Policko> policka = new();
        public LinearniHraciDeska(int pocetPolicek)
        {
            policka.Add(new StartovniPolicko());
            for (int i = 0; i < pocetPolicek -2; i++)
            {
                var policko = new StandardniPolicko();
                policka.Add(policko);
            }
            var domecek = new Domecek();
            policka.Add(domecek);
        }
        public override void PolozFigurkuNaStart(Figurka figurka)
        {
            if (policka[0] is not StartovniPolicko)
            {
                throw new InvalidOperationException("Něco je špatně, prvni policko neni startovni");
            }
            policka[0].PolozFigurku(figurka);
        }

        public override bool JeFigurkaVDomecku(Figurka figurka)
        {
            var domecek = policka.Last();
            if (domecek is not Domecek)
            {
                throw new InvalidOperationException ( "Neco je spatne posledni policko neni domecek" );
            }
            return domecek.JeTamFigurka(figurka);

            
        }
        public override bool CilJeDomecek(Figurka figurka, int pocetPolicek)
        {
            var pocatecniPolicko = DejPolicko(figurka);
            var indexPocatecnihoPolicka = policka.IndexOf(pocatecniPolicko);
            var indexCile = indexPocatecnihoPolicka + pocetPolicek;
            if (indexCile > policka.Count - 1)
            {

                
                return false;
            }
            var cilovePolicko = policka[indexCile];
            if (cilovePolicko is Domecek)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool JeTamFigurkaKVyhozeni(Figurka figurka, int pocetPolicek)
        {
            var pocatecniPolicko = DejPolicko(figurka);
            var indexPocatecnihoPolicka = policka.IndexOf(pocatecniPolicko);
            var indexCile = indexPocatecnihoPolicka + pocetPolicek;
            if (indexCile > policka.Count - 1)
            {

                
                return false;
            }
            var cilovePolicko = policka[indexCile];
            var vyhozenaFigurka = cilovePolicko.DejFigurkuKVyhozeni();
            if (vyhozenaFigurka != null)
            { 
                return true;
            }
            else
            {
                return false;
            }
           
            }
        public override bool PosunFigurku(Figurka figurka, int pocetPolicek)
        {
            var pocatecniPolicko = DejPolicko(figurka);
            var indexPocatecnihoPolicka = policka.IndexOf(pocatecniPolicko);
            var indexCile = indexPocatecnihoPolicka + pocetPolicek; 
            if (indexCile > policka.Count - 1)
            {
                
                Console.WriteLine("Figurka musi trefit domecek presne, zustava na miste");
                return false;
            }
            var cilovePolicko = policka[indexCile];
            var vyhozenaFigurka = cilovePolicko.DejFigurkuKVyhozeni();
            if (vyhozenaFigurka != null)
            {
                
                cilovePolicko.ZvedniFigurku(vyhozenaFigurka);

                var startovniPolicko = policka.First();
                startovniPolicko.PolozFigurku(vyhozenaFigurka);
            }
            pocatecniPolicko.ZvedniFigurku(figurka);
            cilovePolicko.PolozFigurku(figurka);
            return true;
        }
        public override int JakDalekoPolickaOdStartu(Figurka figurka, int PocetPolicek)
        {
            var pocatecniPolicko = DejPolicko(figurka);
            var indexPocatecnihoPolicka = policka.IndexOf(pocatecniPolicko);
            var indexCile = indexPocatecnihoPolicka + PocetPolicek;
            if (indexCile > policka.Count - 1)
            {
                return -1;
            }
            else
            {
                return policka.IndexOf(pocatecniPolicko);
            }
        }
        public Policko? DejPolicko(Figurka figurka)
        {
            return policka.FirstOrDefault(policko => policko.JeTamFigurka(figurka));
        }
        public override void Vypis()
        {
            foreach(var policko in policka)
            {
                policko.Vypis();
            }
            Console.WriteLine();
        }
    }
}
