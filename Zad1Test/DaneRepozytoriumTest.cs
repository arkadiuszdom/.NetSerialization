using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Zad1;

namespace Zad1Test
{
    [TestClass]
    public class DaneRepozytoriumTest
    {
        //dane
        DaneRepozytorium daneRepozytorium;
        Katalog katalog1, katalog2;
        Wykaz wykaz1, wykaz2;
        OpisStanu opis1, opis2;
        Zdarzenie zdarzenie1, zdarzenie2;
        int lElementow;
        ObslugaDanych obslugaDanych;
        IWypelnianieDanymi wypelnianieStalymi, wypelnianieLosowymiDanymi;

        [TestInitialize]
        public void Startup()
        {
            daneRepozytorium = new DaneRepozytorium();

            katalog1 = new Katalog("Test Tytul", "Test Autor", "Test Opis");
            katalog2 = new Katalog("Test Tytul2", "Test Autor2", "Test Opis2");
            daneRepozytorium.DanePowiazania.PozycjeKatalogowe.Add(katalog1.Klucz, katalog1);

            wykaz1 = new Wykaz("Jan", "Kowalski");
            wykaz2 = new Wykaz("Piotr", "Nowak");
            daneRepozytorium.DanePowiazania.ElementyWykazu.Add(wykaz1);

            opis1 = new OpisStanu(katalog1, "Mocno zniszczona", new DateTime(2018, 9, 3, 12, 00, 00));
            opis2 = new OpisStanu(katalog2, "W stanie idealnym", new DateTime(2012, 8, 4, 12, 00, 00));
            daneRepozytorium.DanePowiazania.OpisyStanu.Add(opis1);

            zdarzenie1 = new Zdarzenie(opis1, wykaz1, new DateTime(2017, 6, 3, 12, 00, 00), new DateTime(2017, 9, 3, 12, 00, 00));
            zdarzenie2 = new Zdarzenie(opis2, wykaz2, new DateTime(2017, 6, 3, 12, 00, 00));
            daneRepozytorium.DanePowiazania.Wypozyczenia.Add(zdarzenie1);

            obslugaDanych = new ObslugaDanych(daneRepozytorium);
            wypelnianieStalymi = new WypelnianieStalymi();
            wypelnianieLosowymiDanymi = new WypelnianieLosowymiDanymi();
        }
        //WypelnianieStalymi
        [TestMethod]
        public void WypelnijStalymiTest()
        {

            int liczbaElementyWykazu = daneRepozytorium.DanePowiazania.ElementyWykazu.Count;
            int liczbaPozycjeKatalogowe = daneRepozytorium.DanePowiazania.PozycjeKatalogowe.Count;
            int liczbaWypozyczenia = daneRepozytorium.DanePowiazania.Wypozyczenia.Count;
            int liczbaOpisyStanu = daneRepozytorium.DanePowiazania.OpisyStanu.Count;
            wypelnianieStalymi.Wypelnij(daneRepozytorium.DanePowiazania);
            Assert.AreEqual(liczbaElementyWykazu + 4, daneRepozytorium.DanePowiazania.ElementyWykazu.Count);
            Assert.AreEqual(liczbaPozycjeKatalogowe + 4, daneRepozytorium.DanePowiazania.PozycjeKatalogowe.Count);
            Assert.AreEqual(liczbaWypozyczenia + 6, daneRepozytorium.DanePowiazania.Wypozyczenia.Count);
            Assert.AreEqual(liczbaOpisyStanu + 4, daneRepozytorium.DanePowiazania.OpisyStanu.Count);

        }
        [TestMethod]
        public void WypelnijLosowymiDanymiTest()
        {
            int liczbaElementyWykazu = daneRepozytorium.DanePowiazania.ElementyWykazu.Count;
            int liczbaPozycjeKatalogowe = daneRepozytorium.DanePowiazania.PozycjeKatalogowe.Count;
            int liczbaWypozyczenia = daneRepozytorium.DanePowiazania.Wypozyczenia.Count;
            int liczbaOpisyStanu = daneRepozytorium.DanePowiazania.OpisyStanu.Count;
            wypelnianieLosowymiDanymi.Wypelnij(daneRepozytorium.DanePowiazania);
            Assert.AreEqual(liczbaElementyWykazu + 50, daneRepozytorium.DanePowiazania.ElementyWykazu.Count);
            Assert.AreEqual(liczbaPozycjeKatalogowe + 50, daneRepozytorium.DanePowiazania.PozycjeKatalogowe.Count);
            Assert.AreEqual(liczbaWypozyczenia + 50, daneRepozytorium.DanePowiazania.Wypozyczenia.Count);
            Assert.AreEqual(liczbaOpisyStanu + 50, daneRepozytorium.DanePowiazania.OpisyStanu.Count);
        }
        [TestMethod]
        public void WypelnijLosowymiDanymiWydajnoscTest()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 1000; i++)
                wypelnianieLosowymiDanymi.Wypelnij(daneRepozytorium.DanePowiazania);

            stopwatch.Stop();
            Console.WriteLine("Czas przeznaczony na wypelnienie 10000 losowymi daymi: ", stopwatch.Elapsed);

            stopwatch.Reset();
            stopwatch.Start();

            for (int i = 0; i < 50000; i++)
                wypelnianieLosowymiDanymi.Wypelnij(daneRepozytorium.DanePowiazania);

            stopwatch.Stop();
            Console.WriteLine("Czas przeznaczony na wypelnienie 500000 losowymi daymi: ", stopwatch.Elapsed);
        }

        [TestMethod]
        public void SerializeTest()
        {

            /*string a = JsonConvert.SerializeObject(daneRepozytorium.GetAllWykaz());
            Console.WriteLine(a);
            List <Wykaz> wy = new List<Wykaz>();
            wy = JsonConvert.DeserializeObject<List<Wykaz>>(a);
            Console.WriteLine(JsonConvert.SerializeObject(wy));*/
            string a = JsonConvert.SerializeObject(daneRepozytorium.DanePowiazania, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            Console.WriteLine(a);
            DanePowiazania dane = new DanePowiazania();
            dane = JsonConvert.DeserializeObject<DanePowiazania>(a);
            Console.WriteLine(JsonConvert.SerializeObject(dane));
            //Assert.AreEqual(a, JsonConvert.SerializeObject(dane));

        }

        //Katalog
        [TestMethod]
        public void AddKatalogTest()
        {
            Console.WriteLine("test");
            obslugaDanych.WyswietlKatalog();
            int lElementow;
            lElementow = daneRepozytorium.DanePowiazania.PozycjeKatalogowe.Count;
            daneRepozytorium.AddKatalog(katalog2);
            Assert.AreEqual(lElementow+1, daneRepozytorium.DanePowiazania.PozycjeKatalogowe.Count);
            Assert.AreEqual(katalog1, daneRepozytorium.DanePowiazania.PozycjeKatalogowe[katalog1.Klucz]);
        }

        [TestMethod]
        public void GetKatalogTest()
        {
            Assert.AreEqual(katalog1, daneRepozytorium.GetKatalog(katalog1.Klucz));
            Assert.IsNull(daneRepozytorium.GetKatalog(katalog2.Klucz));
        }

        [TestMethod]
        public void GetAllKatalogTest()
        {
            Assert.AreEqual(daneRepozytorium.GetAllKatalog(), daneRepozytorium.DanePowiazania.PozycjeKatalogowe);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "UpdateKatalog: Blad")]
        public void UpdateKatalogTest()
        {

            daneRepozytorium.UpdateKatalog(katalog1.Klucz, katalog2);
            Assert.IsFalse(daneRepozytorium.UpdateKatalog(katalog2.Klucz, katalog1));
            katalog2.Klucz = katalog1.Klucz;
            Assert.IsTrue(daneRepozytorium.UpdateKatalog(katalog1.Klucz, katalog2));
            Assert.AreEqual(katalog2, daneRepozytorium.GetKatalog(katalog1.Klucz));
        }

        [TestMethod]
        public void DeleteKatalogTest()
        {
            Assert.IsFalse(daneRepozytorium.DeleteKatalog(katalog2));
            Assert.IsTrue(daneRepozytorium.DeleteKatalog(katalog1));
            Assert.IsNull(daneRepozytorium.GetKatalog(katalog1.Klucz));
        }

        //Wykaz
        [TestMethod]
        public void AddWykazTest()
        {
            lElementow = daneRepozytorium.DanePowiazania.ElementyWykazu.Count;
            daneRepozytorium.AddWykaz(wykaz2);
            Assert.AreEqual(lElementow + 1, daneRepozytorium.DanePowiazania.ElementyWykazu.Count);
            Assert.AreEqual(wykaz1, daneRepozytorium.DanePowiazania.ElementyWykazu[lElementow-1]);
        }
        
        [TestMethod]
        public void GetWykazTest()
        {
            lElementow = daneRepozytorium.DanePowiazania.ElementyWykazu.Count;
            Assert.AreEqual(wykaz1, daneRepozytorium.GetWykaz(lElementow-1));
            Assert.IsNull(daneRepozytorium.GetWykaz(lElementow));
        }

        [TestMethod]
        public void GetAllWykazTest()
        {
            Assert.AreEqual(daneRepozytorium.GetAllWykaz(), daneRepozytorium.DanePowiazania.ElementyWykazu);
        }

        [TestMethod]
        public void UpdateWykazTest()
        {
            lElementow = daneRepozytorium.DanePowiazania.ElementyWykazu.Count;
            daneRepozytorium.UpdateWykaz(lElementow-1, wykaz2);
            Assert.IsFalse(daneRepozytorium.UpdateWykaz(lElementow, wykaz1));           
            Assert.AreEqual(wykaz2, daneRepozytorium.GetWykaz(lElementow-1));
        }

        [TestMethod]
        public void DeleteWykazTest()
        {
            lElementow = daneRepozytorium.DanePowiazania.ElementyWykazu.Count;
            Assert.IsFalse(daneRepozytorium.DeleteWykaz(wykaz2));
            Assert.IsTrue(daneRepozytorium.DeleteWykaz(wykaz1));
            Assert.IsNull(daneRepozytorium.GetWykaz(lElementow-1));
        }

        //OpisStanu
        [TestMethod]
        public void AddOpisStanuTest()
        {
            lElementow = daneRepozytorium.DanePowiazania.OpisyStanu.Count;
            daneRepozytorium.AddOpisStanu(opis2);
            Assert.AreEqual(lElementow + 1, daneRepozytorium.DanePowiazania.OpisyStanu.Count);
            Assert.AreEqual(opis1, daneRepozytorium.DanePowiazania.OpisyStanu[lElementow - 1]);
        }

        [TestMethod]
        public void GetOpisStanuTest()
        {
            lElementow = daneRepozytorium.DanePowiazania.OpisyStanu.Count;
            Assert.AreEqual(opis1, daneRepozytorium.GetOpisStanu(lElementow-1));
            Assert.IsNull(daneRepozytorium.GetOpisStanu(lElementow));
        }

        [TestMethod]
        public void GetAllOpisStanuTest()
        {
            Assert.AreEqual(daneRepozytorium.GetAllOpisStanu(), daneRepozytorium.DanePowiazania.OpisyStanu);
        }

        [TestMethod]       
        public void UpdateOpisStanuTest()
        {
            lElementow = daneRepozytorium.DanePowiazania.OpisyStanu.Count;
            daneRepozytorium.UpdateOpisStanu(lElementow-1, opis2);
            Assert.IsFalse(daneRepozytorium.UpdateOpisStanu(lElementow, opis1));           
            Assert.AreEqual(opis2, daneRepozytorium.GetOpisStanu(lElementow-1));
        }

        [TestMethod]
        public void DeleteOpisStanuTest()
        {
            lElementow = daneRepozytorium.DanePowiazania.OpisyStanu.Count;
            Assert.IsFalse(daneRepozytorium.DeleteOpisStanu(opis2));
            Assert.IsTrue(daneRepozytorium.DeleteOpisStanu(opis1));
            Assert.IsNull(daneRepozytorium.GetOpisStanu(lElementow-1));
        }

        //Zdarzenie
        [TestMethod]
        public void AddZdarzenieTest()
        {
            int lElementow;
            lElementow = daneRepozytorium.DanePowiazania.Wypozyczenia.Count;
            daneRepozytorium.AddZdarzenie(zdarzenie2);
            Assert.AreEqual(lElementow + 1, daneRepozytorium.DanePowiazania.Wypozyczenia.Count);
            Assert.AreEqual(zdarzenie1, daneRepozytorium.DanePowiazania.Wypozyczenia[lElementow - 1]);
        }

        [TestMethod]
        public void GetZdarzenieTest()
        {
            lElementow = daneRepozytorium.DanePowiazania.Wypozyczenia.Count;
            Assert.AreEqual(zdarzenie1, daneRepozytorium.GetZdarzenie(lElementow-1));
            Assert.IsNull(daneRepozytorium.GetZdarzenie(lElementow));
        }

        [TestMethod]
        public void GetAllZdarzenieTest()
        {
            Assert.AreEqual(daneRepozytorium.GetAllZdarzenie(), daneRepozytorium.DanePowiazania.Wypozyczenia);
        }

        [TestMethod]
        public void UpdateZdarzenieTest()
        {
            lElementow = daneRepozytorium.DanePowiazania.Wypozyczenia.Count;
            daneRepozytorium.UpdateZdarzenie(lElementow-1, zdarzenie2);
            Assert.IsFalse(daneRepozytorium.UpdateZdarzenie(lElementow, zdarzenie1));           
            Assert.AreEqual(zdarzenie2, daneRepozytorium.GetZdarzenie(lElementow-1));
        }

        [TestMethod]
        public void DeleteZdarzenieTest()
        {
            lElementow = daneRepozytorium.DanePowiazania.Wypozyczenia.Count;
            Assert.IsFalse(daneRepozytorium.DeleteZdarzenie(zdarzenie2));
            Assert.IsTrue(daneRepozytorium.DeleteZdarzenie(zdarzenie1));
            Assert.IsNull(daneRepozytorium.GetZdarzenie(lElementow-1));
        }



    }
}
