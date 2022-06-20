using Microsoft.EntityFrameworkCore;
using probne_kolokwium.Entities.Models;

namespace probne_kolokwium.Entities
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Klient> Klient { get; set; }
        public DbSet<Pracownik> Pracownik { get; set; }
        public DbSet<WyrobCukierniczy> WyrobCukierniczy { get; set; }
        public DbSet<ZamowienieWyrobCukierniczy> ZamowienieWyrobCukierniczy { get; set; }
        public DbSet<Zamowienie> Zamowienie { get; set; }
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klient>(e =>
            {
                e.ToTable("Klient");
                e.HasKey(e => e.IdKlient);

                e.Property(e => e.Imie).HasMaxLength(100).IsRequired();
                e.Property(e => e.Nazwisko).HasMaxLength(100).IsRequired();

                e.HasData(
                    new Klient
                    {
                        IdKlient = 1,
                        Imie = "Michal",
                        Nazwisko = "Kowalski"
                    }
                );
            });

            modelBuilder.Entity<Pracownik>(e =>
            {
                e.ToTable("Pracownik");
                e.HasKey(e => e.IdPracownik);

                e.Property(e => e.Imie).HasMaxLength(100).IsRequired();
                e.Property(e => e.Nazwisko).HasMaxLength(100).IsRequired();

                e.HasData(
                    new Pracownik
                    {
                        IdPracownik = 1,
                        Imie = "Mateusz",
                        Nazwisko = "Kowalski"
                    }
                );
            });

            modelBuilder.Entity<Zamowienie>(e =>
            {
                e.ToTable("Zamowienie");
                e.HasKey(e => e.IdZamowienia);

                e.Property(e => e.DataPrzyjecia).IsRequired();
                e.Property(e => e.Uwagi).HasMaxLength(300);

                e.HasOne(e => e.Klient).WithMany(e => e.Zamowienia).HasForeignKey(e => e.IdKlient).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasOne(e => e.Pracownik).WithMany(e => e.Zamowienia).HasForeignKey(e => e.IdPracownik).OnDelete(DeleteBehavior.ClientSetNull);

                e.HasData(
                    new Zamowienie
                    {
                        IdZamowienia = 1,
                        IdKlient = 1,
                        IdPracownik = 1,
                        DataPrzyjecia = new System.DateTime(2022, 6, 5)
                    }
                );
            });

            modelBuilder.Entity<WyrobCukierniczy>(e =>
            {
                e.ToTable("WyrobCukierniczy");
                e.HasKey(e => e.IdWyrobuCukierniczego);

                e.Property(e => e.Nazwa).HasMaxLength(200).IsRequired();
                e.Property(e => e.CenaZaSzt).IsRequired();
                e.Property(e => e.Typ).HasMaxLength(40).IsRequired();

                e.HasData(
                    new WyrobCukierniczy
                    {
                        IdWyrobuCukierniczego = 1,
                        Nazwa = "Magdalenek",
                        CenaZaSzt = 1.50,
                        Typ = "Cukierek"
                    },
                    new WyrobCukierniczy
                    {
                        IdWyrobuCukierniczego = 2,
                        Nazwa = "Tofik",
                        CenaZaSzt = 0.99,
                        Typ = "Cukierek"
                    }
                );

            });

            modelBuilder.Entity<ZamowienieWyrobCukierniczy>(e =>
            {
                e.ToTable("Zamowienie_WyrobCukierniczy");
                e.HasKey(e => new { e.IdWyrobuCukierniczego, e.IdZamowienia });

                e.Property(e => e.Ilosc).IsRequired();
                e.Property(e => e.Uwagi).HasMaxLength(300);

                e.HasOne(e => e.WyrobCukierniczy).WithMany(e => e.ZamowieniaWyrobCukierniczy).HasForeignKey(e => e.IdWyrobuCukierniczego).OnDelete(DeleteBehavior.ClientCascade);
                e.HasOne(e => e.Zamowienie).WithMany(e => e.ZamowieniaWyrobCukierniczy).HasForeignKey(e => e.IdZamowienia).OnDelete(DeleteBehavior.ClientCascade);

                e.HasData(
                    new ZamowienieWyrobCukierniczy
                    {
                        IdZamowienia = 1,
                        IdWyrobuCukierniczego = 1,
                        Ilosc = 10
                    },
                    new ZamowienieWyrobCukierniczy
                    {
                        IdZamowienia = 1,
                        IdWyrobuCukierniczego = 2,
                        Ilosc = 20
                    }
                );
            });
        }
    }
}
