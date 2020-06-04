using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachunkowość
{
    public class Logika
    {
        int szerokosc = 30;
        List<Konto> konta;
        Zmienne zmienne;
        public Logika()
        {
            konta = new List<Konto>();
            zmienne = new Zmienne();
        }

        public void dodajKontoZFormatu (string typ, int numer)
        {
            switch (typ)
            {
                case "akt":
                    //for (int i = 0; i < zmienne.kontaAktywne.Length; i++)
                    //{
                    //    Console.WriteLine(zmienne.kontaAktywne[i] + " -" + i);
                    //} 
                    konta.Add(new Konto(zmienne.kontaAktywne[numer],typ));
                    break;
                case "pas":
                    //for (int i = 0; i < zmienne.kontaPasywne.Length; i++)
                    //{
                    //    Console.WriteLine(zmienne.kontaPasywne[i] + " -" + i);
                    //} 
                    konta.Add(new Konto(zmienne.kontaPasywne[numer], typ));
                    break;
                default:
                    // code block
                    break;
            }
        }

        public void dodajKontoRecznie (string nazwa, string typ)
        {
            konta.Add(new Konto(nazwa, typ));
        }

        public void wypiszKonta ()
        {
            foreach (Konto konto in konta)
            {
                Console.WriteLine();
                Console.Write(konto.nazwa + " - ");
                if (konto.typ == "akt")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("AKTYWNE");
                }
                else if (konto.typ == "pas")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("PASYWNE");
                }
                else
                    Console.WriteLine("POMOCNICZE");
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i <= szerokosc; i++)
                    Console.Write("-");
                if (konto.dt.Count > konto.ct.Count)
                {
                    for (int i = 0; i < konto.dt.Count; i++)
                    {
                        Console.WriteLine();
                        Console.Write(konto.dtNo[i] + " " + konto.dt[i]);
                        Console.SetCursorPosition(szerokosc / 2, Console.CursorTop);
                        Console.Write('|');
                        try
                        {
                            Console.Write(konto.ctNo[i] + " " + konto.ct[i]);
                        }
                        catch (Exception ex) { }
                    }
                }
                else
                {
                    for (int i = 0; i < konto.ct.Count; i++)
                    {
                        Console.WriteLine();
                        try
                        {
                            Console.Write(konto.dtNo[i] + " " + konto.dt[i]);
                        }
                        catch (Exception ex) { }
                        Console.SetCursorPosition(szerokosc / 2, Console.CursorTop);
                        Console.Write('|');
                        Console.Write(konto.ctNo[i] + " " + konto.ct[i]);
                    }
                }
                Console.WriteLine();
                rozdziel();
                Console.Write(konto.getDtSum());
                Console.SetCursorPosition(szerokosc / 2, Console.CursorTop);
                Console.Write('|');
                Console.WriteLine(konto.getCtSum());
                if (konto.getFinalBalance() < 0)
                {
                    Console.Write("SK) " + konto.getFinalBalance()*-1);
                    Console.SetCursorPosition(szerokosc / 2, Console.CursorTop);
                    Console.WriteLine('|');
                }
                else
                {
                    Console.SetCursorPosition(szerokosc / 2, Console.CursorTop);
                    Console.Write('|');
                    Console.WriteLine("SK) " + konto.getFinalBalance());
                }
                rozdziel();
                if (konto.getDtSum() > konto.getCtSum())
                {
                    Console.Write(konto.getDtSum());
                    Console.SetCursorPosition(szerokosc / 2, Console.CursorTop);
                    Console.Write('|');
                    Console.WriteLine(konto.getDtSum());
                }
                else
                {
                    Console.Write(konto.getCtSum());
                    Console.SetCursorPosition(szerokosc / 2, Console.CursorTop);
                    Console.Write('|');
                    Console.WriteLine(konto.getCtSum());
                }
                Console.WriteLine();


            }
        }

        public void dodajSaldo(string nazwa,double saldo, string numer)
        {
            foreach (Konto konto in konta)
            {
                if (konto.nazwa.ToUpper().Contains(nazwa.ToUpper()))
                {
                    if (konto.typ == "akt")
                    {
                        konto.addDt(numer, saldo);
                    }
                    else
                    {
                        konto.addCt(numer, saldo);
                    }
                }

            }
        }

        public void zrobTransfer(string kontoZ, string kontoDo, double kwota, string numer)
        {
            foreach (Konto konto1 in konta)
            {
                if (konto1.nazwa.ToUpper().Contains(kontoZ.ToUpper()))
                {
                    foreach (Konto konto2 in konta)
                    {
                        if (konto2.nazwa.ToUpper().Contains(kontoDo.ToUpper()))
                        {
                            if (konto1.typ == "akt" && konto2.typ == "akt")
                            {
                                konto1.addCt(numer, kwota);
                                konto2.addDt(numer, kwota);
                            }
                            else if (konto1.typ == "akt" && konto2.typ == "pas")
                            {
                                konto1.addCt(numer, kwota);
                                konto2.addDt(numer, kwota);
                            }
                            else if (konto1.typ == "pas" && konto2.typ == "akt")
                            {
                                konto1.addCt(numer, kwota);
                                konto2.addDt(numer, kwota);
                            }
                            else
                            {
                                konto1.addDt(numer, kwota);
                                konto2.addCt(numer, kwota);
                            }
                        }
                    }
                }
            }
        }

        public void rozdziel()
        {
            for (int i = 0; i <= szerokosc; i++)
                Console.Write("-");
            Console.WriteLine();
        }
        public void rozdzielLong()
        {
            for (int i = 0; i <= 80; i++)
                Console.Write("-");
            Console.WriteLine();
        }

        public void generujZestawienie()
        {
            Console.Write("\nLP.");
            Console.SetCursorPosition(4, Console.CursorTop);
            Console.Write("|Nazwa konta");
            Console.SetCursorPosition(40, Console.CursorTop);
            Console.Write("|Obroty");
            Console.SetCursorPosition(60, Console.CursorTop);
            Console.Write("|Salda");
            Console.SetCursorPosition(80, Console.CursorTop);
            Console.WriteLine("|");
            Console.SetCursorPosition(4, Console.CursorTop);
            Console.Write("|");
            Console.SetCursorPosition(40, Console.CursorTop);
            Console.Write("|Dt");
            Console.SetCursorPosition(50, Console.CursorTop);
            Console.Write("|Ct");
            Console.SetCursorPosition(60, Console.CursorTop);
            Console.Write("|Dt");
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.Write("|Ct");
            Console.SetCursorPosition(80, Console.CursorTop);
            Console.WriteLine("|");
            rozdzielLong();
            double oDt = 0;
            double oCt = 0;
            double sDt = 0;
            double sCt = 0;
            for (int i = 0; i < konta.Count; i++)
            {
                Console.Write(i);
                Console.SetCursorPosition(4, Console.CursorTop);
                Console.Write("|" + konta[i].nazwa);
                Console.SetCursorPosition(40, Console.CursorTop);
                Console.Write("|");
                if (konta[i].getDtSum() != 0)
                    Console.Write(konta[i].getDtSum());
                Console.SetCursorPosition(50, Console.CursorTop);
                Console.Write("|");
                if (konta[i].getCtSum() != 0)
                    Console.Write(konta[i].getCtSum());
                Console.SetCursorPosition(60, Console.CursorTop);
                Console.Write("|");
                if (konta[i].getFinalBalance() > 0)
                    Console.Write(konta[i].getFinalBalance());
                Console.SetCursorPosition(70, Console.CursorTop);
                Console.Write("|");
                if (konta[i].getFinalBalance() < 0)
                    Console.Write(konta[i].getFinalBalance()*-1);
                Console.SetCursorPosition(80, Console.CursorTop);
                Console.WriteLine("|");
                rozdzielLong();
                oDt += konta[i].getDtSum();
                oCt += konta[i].getCtSum();
                if (konta[i].getFinalBalance() > 0)
                    sDt += konta[i].getFinalBalance();
                else
                    sCt += konta[i].getFinalBalance()*-1;
            }
            Console.Write("Razem");
            Console.SetCursorPosition(40, Console.CursorTop);
            Console.Write("|" + oDt);
            Console.SetCursorPosition(50, Console.CursorTop);
            Console.Write("|" + oCt);
            Console.SetCursorPosition(60, Console.CursorTop);
            Console.Write("|" + sDt);
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.Write("|" + sCt);
            Console.SetCursorPosition(80, Console.CursorTop);
            Console.WriteLine("|");
        }
    }
}
