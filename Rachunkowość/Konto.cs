using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachunkowość
{
    public class Konto
    {
        public string nazwa;
        public string typ;
        public List<double> dt; 
        public List<double> ct;
        public List<string> dtNo;
        public List<string> ctNo;
        public Konto(string nazwa, string typ)
        {
            this.nazwa = nazwa;
            this.typ = typ;
            dt = new List<double>();
            ct = new List<double>();
            dtNo = new List<string>();
            ctNo = new List<string>();
        }

        public void addDt(string no, double kw)
        {
            dt.Add(kw);
            dtNo.Add(no);
        }

        public void addCt(string no, double kw)
        {
            ct.Add(kw);
            ctNo.Add(no);
        }

        public double getDtSum()
        {
            double balance = 0;
            foreach (double numer in dt)
            {
                balance += numer;
            }
            return balance;
        }

        public double getCtSum()
        {
            double balance = 0;
            foreach (double numer in ct)
            {
                balance += numer;
            }
            return balance;
        }

        public double getFinalBalance()
        {
            double balance = 0;
            foreach (double numer in dt)
            {
                balance += numer;
            }
            foreach (double numer in ct)
            {
                balance -= numer;
            }
            return balance;
        }


    }
}
