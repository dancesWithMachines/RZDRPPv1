using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachunkowość
{
    class Program
    {
        static Logika logika = new Logika();
        static Zmienne zmienne = new Zmienne();
       
        static void Main(string[] args)
        {
            Console.WriteLine("Rozwiązywator zadaniowy do rachunkowościowych problemów przypadłościowych");
            int wattodo;
            for (; ; )
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Co chcesz zrobić? \n 1)Dodać konto \n 2)Dodać saldo \n 3)Zrobić transfer \n 4)Wypisać konta \n 5)Generuj zestawienie obrotów i sald\n 6)Wypisz przykłady kont aktywnych \n 7)Wypisz przykłady kont pasywnych ");
                Console.Write("Wybór: ");
                Console.ForegroundColor = ConsoleColor.Red;
                wattodo = Int32.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                switch (wattodo)
                {
                    case 1:
                        dodawanieKonta();
                        break;
                    case 2:
                        dodajSaldo();
                        break;
                    case 3:
                        przelew();
                        break;
                    case 4:
                        logika.wypiszKonta();
                        break;
                    case 5:
                        logika.generujZestawienie();
                        break;
                    case 6:
                        pokazAktywne();
                        break;
                    case 7:
                        pokazPasywne();
                        break;
                    default:
                        Console.WriteLine("Błąd");
                        break;
                }

            }
        }

        static public void dodawanieKonta()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" 1)Dodaj konto ze schematu \n 2)Dodaj konto ręcznie");
            Console.Write("Wybór: ");
            Console.ForegroundColor = ConsoleColor.Red;
            int i;
            string nazwaKonta ="";
            i = Int32.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            switch (i)
            {
                case 1:
                    int rodzaj;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Podaj typ:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" 1)Aktywne");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" 2)Pasywne");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Wybór: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    rodzaj = Int32.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (rodzaj == 1)
                    {
                        Console.WriteLine("Wybierz rodzaj: ");
                        for (int j = 0; j < zmienne.kontaAktywne.Length; j++)
                        {
                            int tmp = j + 1;
                            Console.WriteLine(" " + tmp + ")" + zmienne.kontaAktywne[j]);
                        }
                        int a;
                        Console.Write("Wybór: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        a = Int32.Parse(Console.ReadLine());
                        a--;
                        logika.dodajKontoZFormatu("akt", a);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Wybrano: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(zmienne.kontaAktywne[a]);
                        nazwaKonta = zmienne.kontaAktywne[a];

                    }
                    else if (rodzaj == 2)
                    {
                        Console.WriteLine("Wybierz rodzaj: ");
                        for (int j = 0; j < zmienne.kontaPasywne.Length; j++)
                        {
                            int tmp = j + 1;
                            Console.WriteLine(" " + tmp + ")" + zmienne.kontaPasywne[j]);
                        }
                        int b;
                        Console.Write("Wybór: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        b = Int32.Parse(Console.ReadLine());
                        b--;
                        logika.dodajKontoZFormatu("pas", b);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Wybrano: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(zmienne.kontaPasywne[b]);
                        nazwaKonta = zmienne.kontaPasywne[b];
                    }
                    else
                        Console.WriteLine("Błąd");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2:
                    string nazwa;
                    int typ;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Podaj nazwe konta: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    nazwa = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Podaj typ:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" 1)Aktywne");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" 2)Pasywne");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Wybór: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    typ = Int32.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (typ == 1)
                    {
                        logika.dodajKontoRecznie(nazwa, "akt");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Dodano: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(nazwa);
                    }
                    else if (typ == 2)
                    {
                        logika.dodajKontoRecznie(nazwa, "pas");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Dodano: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(nazwa);
                    }
                    else
                        Console.WriteLine("Błąd");
                    nazwaKonta = nazwa;
                    break;
                default:
                    Console.WriteLine("Nie wybrano");
                    break;
            }
            if (nazwaKonta != "")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Podaj saldo początkowe, lub wpisz 0 by pominąć");
                Console.Write("Saldo początkowe: ");
                Console.ForegroundColor = ConsoleColor.Red;
                double kwota = Double.Parse(Console.ReadLine());
                if (kwota != 0)
                {
                    logika.dodajSaldo(nazwaKonta, kwota, "(sp)");
                }
            }
        }

        static void pokazAktywne()
        {
            for (int j = 0; j < zmienne.kontaAktywne.Length; j++)
            {
                int tmp = j + 1;
                Console.WriteLine(" " + tmp + ")" + zmienne.kontaAktywne[j]);
            }
        }

        static void pokazPasywne()
        {
            for (int j = 0; j < zmienne.kontaPasywne.Length; j++)
            {
                int tmp = j + 1;
                Console.WriteLine(" " + tmp + ")" + zmienne.kontaPasywne[j]);
            }
        }


        static void przelew()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Przelew z konta: ");
            Console.ForegroundColor = ConsoleColor.Red;
            string konto1 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Na konto: ");
            Console.ForegroundColor = ConsoleColor.Red;
            string konto2 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Kwota: ");
            Console.ForegroundColor = ConsoleColor.Red;
            double kwota = Double.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Numer operacji: ");
            Console.ForegroundColor = ConsoleColor.Red;
            string numer = Console.ReadLine();
            numer = "("+ numer + ")";
            logika.zrobTransfer(konto1, konto2, kwota, numer);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void dodajSaldo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Nazwa konta: ");
            Console.ForegroundColor = ConsoleColor.Red;
            string konto1 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Kwota: ");
            Console.ForegroundColor = ConsoleColor.Red;
            double kwota = Double.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Numer operacji: ");
            Console.ForegroundColor = ConsoleColor.Red;
            string numer = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            numer = "(" + numer + ")";
            logika.dodajSaldo(konto1, kwota, numer);
        }

        
    }
}
