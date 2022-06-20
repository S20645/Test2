using System;
using System.Collections.Generic;

namespace probne_kolokwium.Entities.Models
{
    public class Zamowienie
    {
        public int IdZamowienia { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime DataRealizacji { get; set; }
        public string Uwagi { get; set; }
        public int IdKlient { get; set; }
        public int IdPracownik { get; set; }
        public virtual Klient Klient { get; set; }
        public virtual Pracownik Pracownik { get; set; }
        public virtual ICollection<ZamowienieWyrobCukierniczy> ZamowieniaWyrobCukierniczy { get; set; }
    }
}
