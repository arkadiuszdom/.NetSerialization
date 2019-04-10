using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("Zad1Test")]
[assembly: InternalsVisibleTo("Zad1Konsola")]
namespace Zad1{

    class DanePowiazania
    {
        public List<Wykaz> ElementyWykazu { get; private set; }

        public Dictionary<Guid, Katalog> PozycjeKatalogowe { get; private set; }

        public ObservableCollection<Zdarzenie> Wypozyczenia { get; private set; }

        public List<OpisStanu> OpisyStanu { get; set; }


        public DanePowiazania()
        {
            ElementyWykazu = new List<Wykaz>();
            PozycjeKatalogowe = new Dictionary<Guid, Katalog>();
            Wypozyczenia = new ObservableCollection<Zdarzenie>();
            Wypozyczenia.CollectionChanged += WypozyczeniaZmianaIlosciowa;
            OpisyStanu = new List<OpisStanu>();
        }
        static void WypozyczeniaZmianaIlosciowa(object wysylacz, NotifyCollectionChangedEventArgs zdarzenie)
        {
            string text="";
            if (zdarzenie.Action.ToString() == "Add"  && zdarzenie.NewItems != null)
            {
                

                foreach (var item in zdarzenie.NewItems)
                {
                    text += "Dodano: " + item + '\n';
                }
            }

            if (zdarzenie.Action.ToString() == "Remove" && zdarzenie.OldItems != null)
            {

                foreach (var item in zdarzenie.OldItems)
                {
                    text += "Usunieto: " + item + '\n';
                }
            }
        }

    }
}
 