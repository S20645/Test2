using System.Collections.Generic;

namespace probne_kolokwium.Entities.Models
{
    public class WyrobCukierniczy
    {
        public int IdWyrobuCukierniczego { get; set; }
        public string Nazwa { get; set; }
        public double CenaZaSzt { get; set; }
        public string Typ { get; set; }
        public virtual ICollection<ZamowienieWyrobCukierniczy> ZamowieniaWyrobCukierniczy { get; set; }
    }
}
