using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachunkowość
{
    class Zmienne
    {
        public string[] kontaAktywne = new string[] 
        {
            "Srodki trwale",
            "Materialy",
            "Towary",
            "Kasa",
            "Rachunek biezacy",
            "Papiery wartościowe przeznaczone do obrotu",
            "Nalezności od odbiorcow",
            "Wyroby gotowe",
            "Wartosci niematerialne i prawne",
            "Pozostale nalezności od pracownikow"
        };

        public string[] kontaPasywne = new string[]
        {
            "Kapital zakladowy",
            "Kapital zapasowy",
            "Kredyt bankowy / kredyty bankowe",
            "Zobowiazania wobec dostawcow",
            "Zobowiazania z tytułu wynagrodzen",
            "Zobowiazania w obec budzetow",
            "Kapital rezerwowy",
            "Kredyty bankowe",
            "Kapital podstawowy",
            "Umorzenie srodkow trwalych",//!!!!!!!!!!!!!
            "Rozrachunki z budzetami"   //!!!!!!!!!!!!!!
            
        };

        string[] kontaPomocnicze = new string[]
        {
            "Materiały podstawowe",
            "Materiały pomocnicze",
            "Paliwo",
            "Części zamienne",
            "Inne materiały"
        };
    }
}
