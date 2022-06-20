namespace probne_kolokwium.Entities.Models
{
    public class ZamowienieWyrobCukierniczy
    {
        public int IdWyrobuCukierniczego { get; set; }
        public int IdZamowienia { get; set; }
        public int Ilosc { get; set; }
        public string Uwagi { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
        public virtual WyrobCukierniczy WyrobCukierniczy { get; set; }
    }
}
