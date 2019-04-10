using System;
using System.Collections.Generic;
using System.Text;

namespace Zad1
{
    interface IKonwersjaDanych
    {
        string Serializuj(DanePowiazania powiazanie);
        void Deserializuj(DanePowiazania powiazanie, string dane);

    }
}
