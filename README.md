# Casopisi
1.	Uvod
1.1	Svrha aplikacije 

Kroz vježbu kolegija Razvoj poslovnih aplikacija radit će se jednostavna aplikacija za casopisa koja podržava unos, uređivanje, brisanje, pretragu i opis casopisa u bazi. Aplikacija također, treba omogućiti brisanje i prikaz detalja pojedinog casopisa. Svaki unos podataka kroz aplikaciju treba uključivati provjeru valjanosti i za brisanje podataka je potrebna posebna potvrda korisnika. 
1.2	Korisnici aplikacije

Aplikaciji će moći pristupiti svi korisnici koji imaju internet i internet preglednik te žele pristupiti svim bitnim informacijama o casopisima na jednom centraliziranom mjestu. 
1.3	Koristi (benefiti) od aplikacije

Stvorit će se jedna centralna baza podataka o filmovima dostupna svima. Korisnici kada budu htjeli potražiti informacije o filmovima neće više morati pretraživati putem Google-a i koristiti više izbora za dobivanje informacija o nekom filmu jer će kroz aplikaciju moći dobiti sve potrebne informacije na jednom mjestu. Aplikacija će biti dostupna putem interneta, zahvaljujući tome korisnik ima mogućnost korištenja aplikacije u bilo koje vrijeme. 
2.	Zahtjevi
2.1	Funkcijski zahtjevi

Aplikacija mora omogućiti spremanje, uređivanje, pretraživanje, prikaz, traženje i brisanje casopisa u bazi podataka. 
2.2	Sistemski, hardverski i mrežni zahtjevi

Budući da će aplikacija biti razvijena u ASP.NET Core MVC-u ona treba biti smještena na Microsoft Web poslužitelju (eng. server). Preporučuju se sljedeće hardverske specifikacije:
Minimum četverojezgreni procesor 2.2 GHz
Minimum 30GB RAM memorije
Minimum 1TB prostora
Operativni sustav Windows server 2019. 

2.2.1 Web server
Preporučuje se korištenje Windows Azure-a za hostanje aplikacije.
Windows Azure može hostatii bilo koju ASP.NET Core MVC aplikaciju, uključujući i našu predloženu aplikaciju u ovom dokumentu.Instaliranje je vrlo jednostavno jer je Microsoft odgovoran za dodavanje resursa na poslužitelju za vrijeme visokog prometa. 
Troškovi su minimalni, oni ovise o količini podataka koji se prikazuju posjetiteljima te održavanje hardvera nije uključeno u njih.

2.2.2 Baze podataka
Preporučuje se korištenje SQL SERVER baze podataka unutar Windows Azure-a za temeljnu bazu podataka aplikacije. Što se tiče Web poslužitelja, ova preporuka osigurava visoku dostupnost za bazu podataka s dobrim omjerom vrijednosti za uložen novac. To posebno ima smisla ako je I Web aplikacija hostana na Windows Azure-u.
2.3	Sigurnost
<Kako će se u sustavu zaštititi osobni podaci korisnika (lozinke ili drugo) ako se koriste?>

U kasnijem razvoju aplikacije razvit će se sigurna identifikacija i zaštićena autentikacija gdje korisnička imena i lozinke ne smiju biti spremljena u obična tekstualna polja i datoteke, a ostali podaci korisnika kao što su adresa, telefonski brojevi, brojevi kreditnih kartica neće biti dostupni anonimnim pristupom.
2.4	Korisnički zahtjevi
<Ovdje navesti detaljni popis korisničkih zahtjeva – preporučeno u tablici, i to po vrstama korisnika - koje će vrste korisnika biti omogućene, što od operacija treba moći svaka vrsta korisnika napraviti, tj. tko će moći unositi, tko ispravljati, tko brisati, gdje će se spremati podaci, koja su izvješća potrebna, itd.>
2.5	Slučajevi (scenariji) korištenja (use-case dijagrami) 
<Ovdje umetnuti use-case dijagrame napravljene u UML jeziku u programu Astah Community. Dijagrame raditi prema Tablici korisničkih zahtjeva, ali povezivati aktivnosti>

Sljedeći slučajevi korištenja opisuju scenarije u kojima korisnici web aplikacije koriste predloženu aplikaciju za upravljanje filmovima. U tim slučajevima korištenja su uključene osnovne operacije, stoga ih ne treba smatrati konačnim. Kako napreduje razvoj dodatna funkcionalnost može biti dodana prema odluci SCRUM mastera.

2.5.1. Slučaj korištenja 1: Pregled filmova	
Kada posjetitelj stranice pregledava Filmove koji se nalaze u web aplikaciji, odvijaju se sljedeći koraci:
1.	Posjetitelj dolazi na početnu stranicu web mjesta kao anonimni korisnik ili klikne na link Početna stranica u izborniku ako se nalazio na drugoj stranici na istom web mjestu.
2.	Početna stranica prikazuje osnovni opis web aplikacije i sadrži gumbe za prikaz, pretraživanje i dodavanje novih filmova. 
3.	Prikaz osnovnih informacija o razvojnom timu moguće je dobiti putem stranica O nama i Kontakt.
4.	Ako anonimni korisnik želi vidjeti sve Filmove u bazi, mora kliknuti na link Popis filmova u glavnom izborniku ili gumb prikaži na Početnoj stranici.
5.	Web aplikacija prikazuje popis filmova. Za svaki Film se prikazuje Naziv filma, Datum izlaska filma, Žanr te Cijena.
6.	Ako anonimni korisnik želi pretraživati Filmove u bazi po Žanru i Nazivu, mora kliknuti na link Tražilica filmova u glavnom izborniku.
7.	 Ako anonimni korisnik želi vidjeti detalje Filma, mora kliknuti na link Detalji za taj Casopis.
8.	Web aplikacija prikazuje detalje odabranog filma –Naziv filma, Datum izlaska filma, Žanr te Cijenu.
2.5.2.	Slučaj korištenja 2: Dodavanje novog Filma
Svi korisnici trebaju moći dodati novi Film. Kada korisnik dodaje novi Film, sljedeći koraci se odvijaju:
1.	Korisnik klikne na gumb Unos na Početnoj stranici ili na link Novi film na stranicama Popis filmova ili Tražilica casopisa.
2.	Korisnik upisuje podatke o novom casopisu.
3.	Korisnik klikne na gumb Spremi.
4.	Ako su upisani podaci ispravni, web aplikacija sprema Film u bazu i vraća korisnika na stranicu Popis casopisa.
2.5.3.	 Slučaj korištenja 3: Uređivanje casopisa

Kada korisnik uređuje Film, sljedeći koraci se odvijaju:
1.	Korisnik klikne na link Uredi u popisu filmova na stranicama Popis filmova ili  Tražilica casopisa.
2.	Korisnik mijenja postojeće podatke o filmu.
3.	Korisnik klikne gumb Spremi promjene.
4.	Ako su upisani podaci točni, web aplikacija sprema promjene u bazi i prikazuje stranicu za Popis filmova.

2.5.4.	Slučaj korištenja 4: Brisanje Filma
Kad korisnik briše Filmove iz baze podataka web aplikacije, sljedeći koraci se odvijaju:

1.	Korisnik klikne na link Obriši u popisu casopisima na stranicama Popis filmova ili  Tražilica casopisa.
2.	Web aplikacija zahtijeva potvrdu o brisanju casopis.
3.	Ako korisnik potvrđuje brisanje, Casopis je uklonjen iz baze.
4.	Web aplikacija prikazuje stranicu Popis casopisa.
2.6.	Dijagrami klasa 
<Ovdje umetnuti dijagrame klasa napravljene u UML jeziku u programu Astah Community. Dijagrami trebaju biti na fizičkoj razini (sadržavati nazive klasa, nazive svojstava, tipove svojstava, nazive i tipove metoda, kao i veze između klasa>

Klasa Movie je potrebna kako bi se u aplikaciji evidentirali matični podaci za svaki film. Svojstva koja opisuju neki film su: ID (identifikator filma), Title (naslov filma, tekstualni podatak), Genre (žanr, tekstualni podatak), Price (cijena, decimalni broj), ReleaseDate (datum izdavanja, datumskog tipa). 
Kako bi se podaci o filmovima mogli spremiti u bazu podataka, potrebno je napraviti klasu MovieDBContext koja koristi klasu Movie kao model za izradu tablice u bazi pomoću Entity frameworka pa zbog toga i nasljeđuje klasu DbContext. Nakon toga treba pristupiti razvoju kontrolera MovieController koji mora naslijediti baznu klasu Controller s pripadajućim metodama za manipulaciju nad bazom.  

