using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Zad1;

namespace Zad1Test
{
    [TestClass]
    public class ObslugaDanychTest
    {
        //dane
        ObslugaDanych obslugaDanych;
        DaneRepozytorium daneRepozytorium;
        Katalog katalog1, katalog2;
        Wykaz wykaz1, wykaz2;
        OpisStanu opis1, opis2;
        Zdarzenie zdarzenie1, zdarzenie2;
        IKonwersjaDanych konwerter;
        string daneOryginalne;
        string sciezka;

        [TestInitialize]
        public void Startup()
        {
            daneRepozytorium = new DaneRepozytorium();

            katalog1 = new Katalog("Test_Tytul", "Test_Autor", "Test_Opis");
            katalog2 = new Katalog("Test_Tytul2", "Test_Autor2", "Test_Opis2");
            daneRepozytorium.DanePowiazania.PozycjeKatalogowe.Add(katalog1.Klucz, katalog1);

            wykaz1 = new Wykaz("Jan", "Kowalski");
            wykaz2 = new Wykaz("Piotr", "Nowak");
            daneRepozytorium.DanePowiazania.ElementyWykazu.Add(wykaz1);

            opis1 = new OpisStanu(katalog1, "Mocno_zniszczona", new DateTime(2018, 9, 3, 12, 00, 00));
            opis2 = new OpisStanu(katalog2, "W_stanie_idealnym", new DateTime(2012, 8, 4, 12, 00, 00));
            daneRepozytorium.DanePowiazania.OpisyStanu.Add(opis1);

            zdarzenie1 = new Zdarzenie(opis1, wykaz1, new DateTime(2017, 6, 3, 12, 00, 00), new DateTime(2017, 9, 3, 12, 00, 00));
            zdarzenie2 = new Zdarzenie(opis2, wykaz2, new DateTime(2017, 6, 3, 12, 00, 00));
            daneRepozytorium.DanePowiazania.Wypozyczenia.Add(zdarzenie1);


            obslugaDanych = new ObslugaDanych(daneRepozytorium);

            sciezka = "dane.txt";

            daneOryginalne = obslugaDanych.WyswietlDaneRepozytorium();
        }

        [TestMethod]
        public void WyswietlKatalogTest()
        {
            obslugaDanych.WyswietlKatalog();
            obslugaDanych.WyswietlKatalog();
        }

        [TestMethod]
        public void KonwejsaJsonTest()
        {
            
            konwerter = new KonwersjaJson();
            obslugaDanych.WriteToFile(sciezka, konwerter);
            obslugaDanych.ReadFromFile(sciezka, konwerter);

            Assert.AreEqual(daneOryginalne, obslugaDanych.WyswietlDaneRepozytorium());
        }
        [TestMethod]
        public void KonwejsaWlasnaTest()
        {
            
            konwerter = new KonwersjaWlasna();
            obslugaDanych.WriteToFile(sciezka, konwerter);
            obslugaDanych.ReadFromFile(sciezka, konwerter);

            Assert.AreEqual(daneOryginalne, obslugaDanych.WyswietlDaneRepozytorium());

        }
    }
}
