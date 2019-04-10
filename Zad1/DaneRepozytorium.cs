using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Zad1
{
    class DaneRepozytorium
    {
        public DanePowiazania DanePowiazania { get; set; }

        public IWypelnianieDanymi WypelnianieDanymi { private get; set; }

        public DaneRepozytorium()
        {
            DanePowiazania = new DanePowiazania();
            WypelnianieDanymi = new WypelnianieStalymi();
            WypelnianieDanymi.Wypelnij(DanePowiazania);
        }

        public void AddKatalog(Katalog katalog)
        {
            DanePowiazania.PozycjeKatalogowe.Add(katalog.Klucz, katalog);
        }

        public Katalog GetKatalog(Guid id)
        {
            Katalog katalog;
            if (DanePowiazania.PozycjeKatalogowe.TryGetValue(id, out katalog))
                return katalog;
            else
                return null;
        }

        public Dictionary<Guid, Katalog> GetAllKatalog()
        {
            return DanePowiazania.PozycjeKatalogowe;
        }

        public bool UpdateKatalog(Guid id, Katalog katalog)
        {
            if (katalog.Klucz != id)
                throw new System.ArgumentException("UpdateKatalog: Blad");
            if(DanePowiazania.PozycjeKatalogowe.ContainsKey(id))
            {
                DanePowiazania.PozycjeKatalogowe[id] = katalog;
                return true;
            }
            return false;            
               
        }

        public bool DeleteKatalog(Katalog katalog)
        {
            return DanePowiazania.PozycjeKatalogowe.Remove(katalog.Klucz);
        }


        public void AddWykaz(Wykaz wykaz)
        {
            DanePowiazania.ElementyWykazu.Add(wykaz);
        }

        public Wykaz GetWykaz(int pozycja)
        {
            if (pozycja >= DanePowiazania.ElementyWykazu.Count || pozycja < 0)
                return null;
            else
                return DanePowiazania.ElementyWykazu[pozycja];
        }

        public List<Wykaz> GetAllWykaz()
        {
            return DanePowiazania.ElementyWykazu;
        }

        public bool UpdateWykaz(int pozycja, Wykaz wykaz)
        {
            
            if (pozycja >= DanePowiazania.ElementyWykazu.Count || pozycja < 0)
                return false;

            DanePowiazania.ElementyWykazu[pozycja] = wykaz;
            return true;
        }

        public bool DeleteWykaz(Wykaz wykaz)
        {
            return DanePowiazania.ElementyWykazu.Remove(wykaz);
        }

        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            DanePowiazania.Wypozyczenia.Add(zdarzenie);
        }

        public Zdarzenie GetZdarzenie(int pozycja)
        {
            if (pozycja >= DanePowiazania.Wypozyczenia.Count || pozycja < 0)
                return null;
            else
                return DanePowiazania.Wypozyczenia[pozycja];
        }

        public ObservableCollection<Zdarzenie> GetAllZdarzenie()
        {
            return DanePowiazania.Wypozyczenia;
        }

        public bool UpdateZdarzenie(int pozycja, Zdarzenie zdarzenie)
        {
            
            if (pozycja >= DanePowiazania.Wypozyczenia.Count || pozycja < 0)
                return false;

            DanePowiazania.Wypozyczenia[pozycja] = zdarzenie;
            return true;
        }

        public bool DeleteZdarzenie(Zdarzenie zdarzenie)
        {
            return DanePowiazania.Wypozyczenia.Remove(zdarzenie);
        }

        public void AddOpisStanu(OpisStanu opisStanu)
        {
            DanePowiazania.OpisyStanu.Add(opisStanu);
        }

        public OpisStanu GetOpisStanu(int pozycja)
        {
            if (pozycja >= DanePowiazania.OpisyStanu.Count || pozycja < 0)
                return null;
            else
                return DanePowiazania.OpisyStanu[pozycja];
        }

        public List<OpisStanu> GetAllOpisStanu()
        {
            return DanePowiazania.OpisyStanu;
        }

        public bool UpdateOpisStanu(int pozycja, OpisStanu opisStanu)
        {
            if (pozycja >= DanePowiazania.ElementyWykazu.Count || pozycja < 0)
                return false;

            DanePowiazania.OpisyStanu[pozycja] = opisStanu;
            return true;
        }

        public bool DeleteOpisStanu(OpisStanu opisStanu)
        {
            return DanePowiazania.OpisyStanu.Remove(opisStanu);
        }
    }
}
