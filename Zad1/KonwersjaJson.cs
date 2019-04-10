using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zad1
{
    class KonwersjaJson : IKonwersjaDanych
    {
        public void Deserializuj(DanePowiazania powiazanie, string dane)
        {
            powiazanie = JsonConvert.DeserializeObject<DanePowiazania>(dane);
        }

        public string Serializuj(DanePowiazania powiazanie)
        {
            return JsonConvert.SerializeObject(powiazanie, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

        }
    }
}
