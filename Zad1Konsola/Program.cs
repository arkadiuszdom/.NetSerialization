using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad1;

namespace Zad1Konsola
{
    class Program
    {
        static void Main(string[] args)
        {
            DaneRepozytorium daneRepozytorium = new DaneRepozytorium();
            ObslugaDanych obslugaDanych = new ObslugaDanych(daneRepozytorium);

            IKonwersjaDanych konwerter;

            konwerter = new KonwersjaJson();
            obslugaDanych.WriteToFile("data.json", konwerter);
            obslugaDanych.ReadFromFile("data.json", konwerter);
            Console.Write(obslugaDanych.WyswietlDaneRepozytorium());

            konwerter = new KonwersjaWlasna();
            obslugaDanych.WriteToFile("data.txt", konwerter);
            obslugaDanych.ReadFromFile("data.txt", konwerter);
            Console.Write(obslugaDanych.WyswietlDaneRepozytorium());

            Console.ReadKey();
        }
    }
}
