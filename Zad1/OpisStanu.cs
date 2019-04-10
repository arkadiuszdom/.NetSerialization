using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zad1
{
    class OpisStanu
    {
        public Katalog Egzemplarz { get; set; }
        public string Opis { get; set; }

        public DateTime DataZakupu { get; set; }
        //dataZakupu= new DateTime(2008, 6, 1, 7, 47, 0); 

        [JsonConstructor]
        public OpisStanu(Katalog egzemplarz, string opis, DateTime dataZakupu)
        {
            Egzemplarz = egzemplarz;
            Opis = opis;
            DataZakupu = dataZakupu;
        }
        public OpisStanu(Katalog egzemplarz, string opis, string dataZakupu)
        {
            Egzemplarz = egzemplarz;
            Opis = opis;
            DataZakupu = DateTime.ParseExact(dataZakupu, "yyyy-MM-dd_HH:mm", null);
        }
        public override String ToString()
        {
            return "Egzemplarz: " + Egzemplarz.ToString() + " " + KrotkiToString();
        }

        public string KrotkiToString()
        {
            return "Opis: " + Opis.ToString() + " Data_zakupu: " + DataZakupu.ToString("yyyy-MM-dd") + "_" + DataZakupu.ToString("HH:mm");
        }
    }
}
