using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace probne_kolokwium.Entities.Migrations
{
    public partial class dodanoNoweDane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Klient",
                columns: new[] { "IdKlient", "Imie", "Nazwisko" },
                values: new object[] { 1, "Michal", "Kowalski" });

            migrationBuilder.InsertData(
                table: "Pracownik",
                columns: new[] { "IdPracownik", "Imie", "Nazwisko" },
                values: new object[] { 1, "Mateusz", "Kowalski" });

            migrationBuilder.InsertData(
                table: "WyrobCukierniczy",
                columns: new[] { "IdWyrobuCukierniczego", "CenaZaSzt", "Nazwa", "Typ" },
                values: new object[,]
                {
                    { 1, 1.5, "Magdalenek", "Cukierek" },
                    { 2, 0.98999999999999999, "Tofik", "Cukierek" }
                });

            migrationBuilder.InsertData(
                table: "Zamowienie",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlient", "IdPracownik", "Uwagi" },
                values: new object[] { 1, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null });

            migrationBuilder.InsertData(
                table: "Zamowienie_WyrobCukierniczy",
                columns: new[] { "IdWyrobuCukierniczego", "IdZamowienia", "Ilosc", "Uwagi" },
                values: new object[] { 1, 1, 10, null });

            migrationBuilder.InsertData(
                table: "Zamowienie_WyrobCukierniczy",
                columns: new[] { "IdWyrobuCukierniczego", "IdZamowienia", "Ilosc", "Uwagi" },
                values: new object[] { 2, 1, 20, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobCukierniczy",
                keyColumns: new[] { "IdWyrobuCukierniczego", "IdZamowienia" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobCukierniczy",
                keyColumns: new[] { "IdWyrobuCukierniczego", "IdZamowienia" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "WyrobCukierniczy",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WyrobCukierniczy",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Klient",
                keyColumn: "IdKlient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pracownik",
                keyColumn: "IdPracownik",
                keyValue: 1);
        }
    }
}
