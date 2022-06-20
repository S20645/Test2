﻿using System.Collections.Generic;

namespace probne_kolokwium.Entities.Models
{
    public class Pracownik
    {
        public int IdPracownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public virtual ICollection<Zamowienie> Zamowienia { get; set; }
    }
}
