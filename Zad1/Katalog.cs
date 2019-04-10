using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zad1
{
    class Katalog
    {
        public Guid Klucz { get; set; }
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public string Opis { get; set; }

        public Katalog(string tytul, string autor, string opis)
        {
            Klucz = Guid.NewGuid();
            Tytul = tytul;
            Autor = autor;
            Opis = opis;
        }

        [JsonConstructor]
        public Katalog(string klucz, string tytul, string autor, string opis)
        {
            Klucz = Guid.Parse(klucz);
            Tytul = tytul;
            Autor = autor;
            Opis = opis;
        }
        public override String ToString()
        {
            return "Klucz: " + Klucz.ToString() + " Tytul: " + Tytul.ToString() + " Autor: " + Autor.ToString() + " Opis: " + Opis.ToString();
        }
    }
}
