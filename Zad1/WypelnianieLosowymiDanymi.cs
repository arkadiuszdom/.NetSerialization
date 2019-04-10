using System;
using System.Collections.Generic;
using System.Text;

namespace Zad1
{
    class WypelnianieLosowymiDanymi : IWypelnianieDanymi
    {
        public void Wypelnij(DanePowiazania powiazanie)
        {
            const int N=50;
            Random rand = new Random();
            DateTime date;
            List<string> imiona = new List<string>()
            {
                "Jan", "Adam", "Piotr", "Patryk", "Łukasz",
                "Aleksander", "Janusz", "Mariusz", "Marek"
            };

            List<string> nazwiska = new List<string>()
            {
                "Kowalski", "Nowak", "Wiśniewski", "Lewandowski",
                "Dąbrowski", "Woźniak", "Kwiatkowski", "Jankowski"
            };
            
            List<string> tytuly = new List<string>()
            {
                "Pan_Tadeusz", "Ferdydurke", "Władca_Pierścieni", "Jądro_Ciemności"
            };

            List<string> opisy = new List<string>()
            {
                "Przygodowa", "Fantasy", "Science_fiction", "Romans", "Obyczajowa"
            };

            List<string> opisyStanu = new List<string>()
            {
                "W_stanie_idealnym", "W_dobrym_stanie", "Średnio_zniszczona",
                "Mocno_zniszczona", "Bardzo_zniszczona"
            };
            //List<Guid> kluczeKatalogu = new List<Guid>();
            for (int i = 0; i < N; i++)
            {
                powiazanie.ElementyWykazu.Add(new Wykaz(imiona[rand.Next(0, imiona.Count)], nazwiska[rand.Next(0, nazwiska.Count)]));
                Katalog katalog = new Katalog(tytuly[rand.Next(0, tytuly.Count)],
                    imiona[rand.Next(0, imiona.Count)] + " " + nazwiska[rand.Next(0, nazwiska.Count)],
                    opisy[rand.Next(0, opisy.Count)]);
                powiazanie.PozycjeKatalogowe.Add(katalog.Klucz,katalog);
                //kluczeKatalogu.Add(katalog.Klucz);

                powiazanie.OpisyStanu.Add(new OpisStanu(katalog,
                    opisyStanu[rand.Next(0,opisyStanu.Count)],
                    new DateTime(2000 + rand.Next(0,18),rand.Next(1, 13), rand.Next(1, 29), rand.Next(0, 24), rand.Next(0,60), 0)));

                

                
            }
            for (int i = 0; i < N; i++)
            {
                date = new DateTime(2000 + rand.Next(0, 18), rand.Next(1, 13), rand.Next(1, 29), rand.Next(0, 24), rand.Next(0, 60), 0);
                if (rand.Next(0, 2) == 0)
                {
                    powiazanie.Wypozyczenia.Add(new Zdarzenie(powiazanie.OpisyStanu[rand.Next(0, powiazanie.OpisyStanu.Count)],
                    powiazanie.ElementyWykazu[rand.Next(0, powiazanie.ElementyWykazu.Count)],
                    date, date + new System.TimeSpan(rand.Next(0, 120), rand.Next(0, 24), rand.Next(0, 60), 0)
                    ));
                }
                else
                {
                    powiazanie.Wypozyczenia.Add(new Zdarzenie(powiazanie.OpisyStanu[rand.Next(0, powiazanie.OpisyStanu.Count)],
                    powiazanie.ElementyWykazu[rand.Next(0, powiazanie.ElementyWykazu.Count)],
                    date)
                    );
                }
            }
        }
    }
}
