using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clobrdo
{
    internal class Hra
    {
        List<Hrac> hraci = new();
        HraciDeska hraciDeska;
        public string vyherce;
        public void PridejHrace(Hrac hrac)
        {
            if (hraci.Count< hraciDeska.MaximalniPocetHracu)
            {
                for (int i = 0; i < 4; i++)
                {
                    Figurka figurka = new Figurka($"{hrac.Jmeno[0]}{i +1}");
                    hrac.PridejFigurku(figurka);
                    hraciDeska.PolozFigurkuNaStart(figurka);
                }
                hraci.Add(hrac);

            }
            else
            {
                throw new Exception($"Hrac {hrac.Jmeno} nelze přidat hraci deska je plna");
            }
            
        }
        public Hra(HraciDeska hraciDeska)
        {
            this.hraciDeska = hraciDeska;
        }
        public void Start()
        {
            var kostka = new Kostka(6);
            while (true)
            {
                if (JeDohrano())
                {
                    Console.WriteLine($"Mame vítěze, hra skončila {vyherce}");
                    break;  

                }
                foreach (var hrac in hraci)
                {
                    Console.WriteLine($"Hraje hrac {hrac.Jmeno}");
                    int hod = kostka.Hod();
                    //TODO herni strategie
                    bool figurkyvyzkouseny = false;
                    Figurka figurka;
                    int pocetfigurek =0;
                    bool posunnalezen = false;
                    while (!figurkyvyzkouseny)
                    {
                        figurka = hrac.Figurky[pocetfigurek];
                        if (hraciDeska.CilJeDomecek(figurka, hod))
                        {
                            hraciDeska.PosunFigurku(figurka, hod);
                            posunnalezen = true;
                            break;
                            
                        }
                        
                        if (pocetfigurek+1 == hrac.Figurky.Count)
                        {
                            figurkyvyzkouseny = true;
                        }
                        pocetfigurek++;

                    }
                    if (!posunnalezen)
                    {
                        pocetfigurek = 0;
                        figurkyvyzkouseny = false;

                        while (!figurkyvyzkouseny)
                        {
                            figurka = hrac.Figurky[pocetfigurek];
                            if (hraciDeska.JeTamFigurkaKVyhozeni(figurka, hod))
                            {
                                hraciDeska.PosunFigurku(figurka, hod);
                                posunnalezen = true;
                                break;

                            }

                            if (pocetfigurek+1 == hrac.Figurky.Count)
                            {
                                figurkyvyzkouseny = true;
                            }
                            pocetfigurek++;

                        }
                    }
                    if (!posunnalezen)
                    {
                        pocetfigurek = 0;
                        figurkyvyzkouseny = false;
                        List<int>? vzdalenostOdStartu = new();
                        while (!figurkyvyzkouseny)
                        {

                            figurka = hrac.Figurky[pocetfigurek];
                            vzdalenostOdStartu.Add(hraciDeska.JakDalekoPolickaOdStartu(figurka, hod));

                            if (pocetfigurek+1 == hrac.Figurky.Count)
                            {
                                figurkyvyzkouseny = true;
                                posunnalezen = true;
                            }
                            pocetfigurek++;

                        }
                        figurka = hrac.Figurky[vzdalenostOdStartu.IndexOf(vzdalenostOdStartu.Max())];

                        hraciDeska.PosunFigurku(figurka, hod);
                    }
                    

                    
                    hraciDeska.Vypis();

                }



            }
            Console.WriteLine("Konec vseho");
        }
        private bool  JeDohrano()
        {
            foreach (var hrac in hraci)
            {
                if (hrac.Figurky.All(figurka => hraciDeska.JeFigurkaVDomecku(figurka)))
                {
                    vyherce =hrac.Jmeno;
                    return true;
                }
            }
            return false;
        }
    }
}
