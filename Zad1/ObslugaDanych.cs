using System;
using System.Windows;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
//using Newtonsoft.Json;

namespace Zad1
{
    class ObslugaDanych
    {
        public DaneRepozytorium DaneRepozytorium { private get; set; }


        public ObslugaDanych(DaneRepozytorium daneRepozytorium)
        {
            DaneRepozytorium = daneRepozytorium;
        }

        public void WriteToFile(string path, IKonwersjaDanych konwerter)
        {
            File.WriteAllText(path, konwerter.Serializuj(DaneRepozytorium.DanePowiazania));
        }
        public void ReadFromFile(string path, IKonwersjaDanych konwerter)
        {
            konwerter.Deserializuj(DaneRepozytorium.DanePowiazania,File.ReadAllText(path));
        }


        public string WyswietlKatalog()
        {
            string wynik = "Pozycje katalogowe:\n";
            foreach (var item in DaneRepozytorium.GetAllKatalog())
            {
                wynik += item.Value.ToString() + '\n';
            }
            return wynik;
        }
        public string WyswietlZdarzenia()
        {
            string wynik = "Wypozyczenia:\n";
            foreach (var item in DaneRepozytorium.DanePowiazania.Wypozyczenia)
            {
                wynik += item.ToString() + '\n';
            }
            return wynik;
        }
        public string WyswietlOpisyStanu()
        {
            string wynik = "Opisy stanu:\n";
            foreach (var item in DaneRepozytorium.DanePowiazania.OpisyStanu)
            {
                wynik += item.ToString() + '\n';
            }
            return wynik;
        }
        public string WyswietlElementyWykazu()
        {
            string wynik = "Elementy wykazu:\n";
            foreach (var item in DaneRepozytorium.GetAllWykaz())
            {
                wynik += item.ToString() + '\n';
            }
            return wynik;
        }

        public string WyswietlDaneRepozytorium()
        {
            return WyswietlElementyWykazu() + "\n" + WyswietlKatalog() + "\n" + WyswietlOpisyStanu() + "\n" + WyswietlZdarzenia();
        }
        public void DodajWypozyczenie(OpisStanu egzemplarz, Wykaz wypozyczajacy)
        {
            DaneRepozytorium.AddZdarzenie(new Zdarzenie(egzemplarz, wypozyczajacy, DateTime.Now));
        }
        public Zdarzenie PobierzWypozyczenie(OpisStanu egzemplarz)
        {
            for (int i = 0; i < DaneRepozytorium.GetAllZdarzenie().Count; i++)
            {
                if (DaneRepozytorium.GetZdarzenie(i).Egzemplarz == egzemplarz)
                    return DaneRepozytorium.GetZdarzenie(i);
            }
            return null;
        }
        public Zdarzenie PobierzWypozyczenie(Wykaz wypozyczajacy)
        {
            for (int i = 0; i < DaneRepozytorium.GetAllZdarzenie().Count; i++)
            {
                if (DaneRepozytorium.GetZdarzenie(i).Wypozyczajacy == wypozyczajacy)
                    return DaneRepozytorium.GetZdarzenie(i);
            }
            return null;
        }
        public void UsunWypozyczenie(OpisStanu egzemplarz)
        {
            for (int i = 0; i < DaneRepozytorium.GetAllZdarzenie().Count; i++)
            {
                if (DaneRepozytorium.GetZdarzenie(i).Egzemplarz == egzemplarz)
                {
                    DaneRepozytorium.DeleteZdarzenie(DaneRepozytorium.GetZdarzenie(i));
                    break;
                }
            }
        }
        public void UsunWypozyczenie(Wykaz wypozyczajacy)
        {
            for (int i = 0; i < DaneRepozytorium.GetAllZdarzenie().Count; i++)
            {
                if (DaneRepozytorium.GetZdarzenie(i).Wypozyczajacy == wypozyczajacy)
                {
                    DaneRepozytorium.DeleteZdarzenie(DaneRepozytorium.GetZdarzenie(i));
                    break;
                }
            }
        }
        public void UaktualnijWypozyczenie(OpisStanu egzemplarz, Zdarzenie wypozyczenie)
        {
            for (int i = 0; i < DaneRepozytorium.GetAllZdarzenie().Count; i++)
            {
                if (DaneRepozytorium.GetZdarzenie(i).Egzemplarz == egzemplarz)
                    DaneRepozytorium.UpdateZdarzenie(i, wypozyczenie);
            }
        }
        public void UaktualnijWypozyczenie(Wykaz wypozyczajacy, Zdarzenie wypozyczenie)
        {
            for (int i = 0; i < DaneRepozytorium.GetAllZdarzenie().Count; i++)
            {
                if (DaneRepozytorium.GetZdarzenie(i).Wypozyczajacy == wypozyczajacy)
                    DaneRepozytorium.UpdateZdarzenie(i, wypozyczenie);
            }
        }

        public string WyszukajFraze(string fraza)
        {
            string text = "Wyniki wyszukiwania:\n";
            for (int i = 0; i < DaneRepozytorium.GetAllZdarzenie().Count; i++)
            {
                if (DaneRepozytorium.GetZdarzenie(i).ToString().Contains(fraza))
                    text += "Wypozyczenie[" + i + "]: " + DaneRepozytorium.GetZdarzenie(i).ToString() + '\n';
            }
            for (int i = 0; i < DaneRepozytorium.GetAllWykaz().Count; i++)
            {
                if (DaneRepozytorium.GetWykaz(i).ToString().Contains(fraza))
                    text += "ElementyWykazu[" + i + "]: " + DaneRepozytorium.GetWykaz(i).ToString() + '\n';
            }
            for (int i = 0; i < DaneRepozytorium.GetAllOpisStanu().Count; i++)
            {
                if (DaneRepozytorium.GetOpisStanu(i).ToString().Contains(fraza))
                    text += "OpisyStanu[" + i + "]: " + DaneRepozytorium.GetAllOpisStanu()[i].ToString() + '\n';
            }
            foreach (var item in DaneRepozytorium.GetAllKatalog())
            {
                if (item.ToString().Contains(fraza))
                    text += "PozycjeKatalogowe[" + item.Key + "]: " + item.ToString() + '\n';
            }
            if (text == "Wyniki wyszukiwania:\n")
                return "Brak dopasowan";
            return text;
        }

    }
}
