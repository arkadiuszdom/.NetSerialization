using System;
using System.Collections.Generic;
using System.Text;

namespace Zad1
{
    class WypelnianieStalymi: IWypelnianieDanymi
    {
        public void Wypelnij(DanePowiazania powiazanie)
        {
            List<Wykaz> czytelnicy = new List<Wykaz>
            {
                new Wykaz("Jan", "Kowalski"),
                new Wykaz("Piotr", "Nowak"),
                new Wykaz("Adam", "Wiśniewski"),
                new Wykaz("Jakub", "Kamiński")
            };

            foreach (var czytelnik in czytelnicy)
            {
                powiazanie.ElementyWykazu.Add(czytelnik);
            }

            List<Katalog> ksiazki = new List<Katalog>
            {
                new Katalog("Pan_Tadeusz", "Adam_Mickiewicz", "O_szlachcie"),
                new Katalog("Ferdydurke", "Witold_Gombrowicz", "O_maskach"),
                new Katalog("Zbrodnia_i_kara", "Fiodor_Dostojewski", "O_morderstwie"),
                new Katalog("Jądro_ciemności", "Joseph_Conrad", "O_Afryce")
            };

            foreach (var ksiazka in ksiazki)
            {
                powiazanie.PozycjeKatalogowe.Add(ksiazka.Klucz,ksiazka);
            }


            List<OpisStanu> egzemplarze = new List<OpisStanu>
            {
                new OpisStanu(ksiazki[0], "Lekko_zniszczona", new DateTime(2017, 9, 3, 12, 00, 00)),
                new OpisStanu(ksiazki[0], "W_dobrym_stanie", new DateTime(2016, 6, 2, 12, 00, 00)),
                new OpisStanu(ksiazki[2], "W_stanie_idealnym", new DateTime(2012, 8, 4, 12, 00, 00)),
                new OpisStanu(ksiazki[3], "Mocno_zniszczona", new DateTime(2018, 9, 3, 12, 00, 00))
            };

            foreach (var egzemplarz in egzemplarze)
            {
                powiazanie.OpisyStanu.Add(egzemplarz);
            }

            
            powiazanie.Wypozyczenia.Add(new Zdarzenie(egzemplarze[0], czytelnicy[0], new DateTime(2017, 9, 3, 12, 00, 00), new DateTime(2017, 7, 3, 12, 00, 00)));
            powiazanie.Wypozyczenia.Add(new Zdarzenie(egzemplarze[1], czytelnicy[0], new DateTime(2017, 6, 3, 12, 00, 00), new DateTime(2017, 9, 3, 12, 00, 00)));
            powiazanie.Wypozyczenia.Add(new Zdarzenie(egzemplarze[2], czytelnicy[0], new DateTime(2017, 6, 3, 12, 00, 00)));
            powiazanie.Wypozyczenia.Add(new Zdarzenie(egzemplarze[0], czytelnicy[1], new DateTime(2017, 9, 3, 12, 00, 00), new DateTime(2017, 10, 3, 12, 00, 00)));
            powiazanie.Wypozyczenia.Add(new Zdarzenie(egzemplarze[1], czytelnicy[1], new DateTime(2017, 9, 3, 14, 00, 00)));
            powiazanie.Wypozyczenia.Add(new Zdarzenie(egzemplarze[0], czytelnicy[2], new DateTime(2017, 11, 5, 12, 00, 00)));
        }
    }
}
