using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zad1
{
    class Zdarzenie
    {

        public OpisStanu Egzemplarz { get; set; }
        public Wykaz Wypozyczajacy { get; set; }


        //dataZakupu= new DateTime(2008, 6, 1, 7, 47, 0); 
        public DateTime DataWypozyczenia { get; set; }
        public DateTime? DataZwrotu { get; set; }

        [JsonConstructor]
        public Zdarzenie(OpisStanu egzemplarz, Wykaz wypozyczajacy, DateTime dataWypozyczenia, DateTime? dataZwrotu)
        {
            Egzemplarz = egzemplarz;
            Wypozyczajacy = wypozyczajacy;
            DataWypozyczenia = dataWypozyczenia;
            DataZwrotu = dataZwrotu;
        }
        public Zdarzenie(OpisStanu egzemplarz, Wykaz wypozyczajacy, DateTime dataWypozyczenia, DateTime dataZwrotu)
        {
            Egzemplarz = egzemplarz;
            Wypozyczajacy = wypozyczajacy;
            DataWypozyczenia = dataWypozyczenia;
            DataZwrotu = dataZwrotu;
        }
        public Zdarzenie(OpisStanu egzemplarz, Wykaz wypozyczajacy, string dataWypozyczenia, string dataZwrotu)
        {
            Egzemplarz = egzemplarz;
            Wypozyczajacy = wypozyczajacy;
            DataWypozyczenia = DateTime.ParseExact(dataWypozyczenia, "yyyy-MM-dd_HH:mm", null);
            if (dataZwrotu != "null")
                DataZwrotu = DateTime.ParseExact(dataZwrotu, "yyyy-MM-dd_HH:mm", null);
            else
                DataZwrotu = null;

        }

        public Zdarzenie(OpisStanu egzemplarz, Wykaz wypozyczajacy, DateTime dataWypozyczenia)
        {
            Egzemplarz = egzemplarz;
            Wypozyczajacy = wypozyczajacy;
            DataWypozyczenia = dataWypozyczenia;

        }
        public override String ToString()
        {
            string info = "Egzemplarz: " + Egzemplarz.ToString() + " Wypozyczajcy: " + Wypozyczajacy.ToString() + " " + KrotkiToString();

            return info;
        }

        public string KrotkiToString()
        {
            string info = "Data_wypozyczenia: " + DataWypozyczenia.ToString("yyyy-MM-dd") + "_" + DataWypozyczenia.ToString("HH:mm") + " Data_zwrotu: ";
            if (DataZwrotu != null)
                return info + DataZwrotu.Value.ToString("yyyy-MM-dd") + "_"+ DataZwrotu.Value.ToString("HH:mm");
            return info + "null";
        }


    }
}
