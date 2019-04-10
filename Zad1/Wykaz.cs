using System;

namespace Zad1
{
    class Wykaz
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public Wykaz(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }
        public override String ToString()
        {
            return "Imie: " + Imie.ToString() + " Nazwisko: " + Nazwisko.ToString();
        }
    }
}
