using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    class KonwersjaWlasna : IKonwersjaDanych
    {

        public string Serializuj(DanePowiazania powiazanie)
        {
            string wykaz = "", katalog = "", zdarzenie = "", opisStanu = "";
            //string wynik = "Pozycje katalogowe:\n";
            for (int i = 0; i < powiazanie.ElementyWykazu.Count; i++)
            {
                wykaz += "Indeks: " + i + " " + powiazanie.ElementyWykazu[i].ToString() + ",";
            }

            foreach (var item in powiazanie.PozycjeKatalogowe)
            {
                katalog += "Indeks: " + item.Key + " " + item.Value.ToString() + ",";
            }
            int j = 0, k = 0;
            Guid tempGuid = new Guid();
            for (int i = 0; i < powiazanie.OpisyStanu.Count; i++)
            {


                foreach (var item in powiazanie.PozycjeKatalogowe)
                {
                    if (powiazanie.OpisyStanu[i].Egzemplarz.Klucz == item.Key)
                    {
                        tempGuid = item.Key;
                        break;
                    }

                }

                opisStanu += "Indeks: " + i + " Egzemplarz: " + tempGuid + " " + powiazanie.OpisyStanu[i].KrotkiToString() + ",";
            }

            for (int i = 0; i < powiazanie.Wypozyczenia.Count; i++)
            {

                for (j = 0; j < powiazanie.OpisyStanu.Count; j++)
                {
                    if (powiazanie.Wypozyczenia[i].Egzemplarz.Egzemplarz.Klucz == powiazanie.OpisyStanu[j].Egzemplarz.Klucz)
                        break;
                }
                if (j == powiazanie.OpisyStanu.Count)
                    j = 0;

                for (k = 0; k < powiazanie.ElementyWykazu.Count; k++)
                {
                    if (powiazanie.Wypozyczenia[i].Wypozyczajacy == powiazanie.ElementyWykazu[k])
                        break;
                }
                if (k == powiazanie.ElementyWykazu.Count)
                    k = 0;

                zdarzenie += "Indeks: " + i + " Egzemplarz: " + j + " Wypozyczajacy: " + k + " " + powiazanie.Wypozyczenia[i].KrotkiToString() + ",";
            }



            return wykaz + ";" + katalog + ";" + opisStanu + ";" + zdarzenie + ";";
        }

        public void Deserializuj(DanePowiazania powiazanie, string dane)
        {
            List<Wykaz> elementyWykazu = new List<Wykaz>();
            Dictionary<Guid, Katalog> pozycjeKatalogowe = new Dictionary<Guid, Katalog>();
            List<OpisStanu> opisyStanu = new List<OpisStanu>();
            ObservableCollection<Zdarzenie> wypozyczenia = new ObservableCollection<Zdarzenie>();

            string[] listy = dane.Split(';');
            string[] pola;


            foreach (var wykaz in listy[0].Split(','))
            {
                pola = wykaz.Split(' ');
                if (pola.Length != 6)
                    break;
                elementyWykazu.Add(new Wykaz(pola[3], pola[5]));

            }
            /*foreach (var wykaz in elementyWykazu)
            {
                Console.Write(wykaz.ToString());
            }*/

            foreach (var katalog in listy[1].Split(','))
            {
                pola = katalog.Split(' ');
                if (pola.Length != 10)
                    break;
                pozycjeKatalogowe.Add(Guid.Parse(pola[3]), new Katalog(pola[3], pola[5], pola[7], pola[9]));

            }
            /*foreach (var katalog in pozycjeKatalogowe)
            {
                Console.Write(katalog.Value.ToString());
            }*/

            foreach (var opisStanu in listy[2].Split(','))
            {
                pola = opisStanu.Split(' ');
                if (pola.Length != 8)
                    break;
                opisyStanu.Add(new OpisStanu(pozycjeKatalogowe[Guid.Parse(pola[3])], pola[5], pola[7]));

            }
            /*foreach (var opisStanu in opisyStanu)
            {
                Console.Write(opisStanu.ToString());
            }*/

            foreach (var wypozyczenie in listy[3].Split(','))
            {
                pola = wypozyczenie.Split(' ');                
                if (pola.Length !=10)
                    break;
                wypozyczenia.Add(new Zdarzenie(opisyStanu[Int32.Parse(pola[3])], elementyWykazu[Int32.Parse(pola[5])], pola[7], pola[9]));

            }
            /*
            foreach (var wypozyczenie in wypozyczenia)
            {
                Console.Write(wypozyczenie.ToString());
            }*/
        }
    }
}
