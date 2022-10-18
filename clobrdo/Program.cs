using clobrdo;

HraciDeska hraciDeska = new LinearniHraciDeska(pocetPolicek:10);
Hra hra = new Hra(hraciDeska);

Hrac hracRobert = new Hrac("Robert");
Hrac hracKarel= new Hrac("Karel");
Hrac hracZbynek = new Hrac("Zbynek");

hra.PridejHrace(hracRobert);
hra.PridejHrace(hracKarel);
hra.PridejHrace(hracZbynek);

hra.Start();