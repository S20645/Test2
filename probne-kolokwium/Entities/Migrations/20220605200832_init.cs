using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace probne_kolokwium.Entities.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    IdKlient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.IdKlient);
                });

            migrationBuilder.CreateTable(
                name: "Pracownik",
                columns: table => new
                {
                    IdPracownik = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownik", x => x.IdPracownik);
                });

            migrationBuilder.CreateTable(
                name: "WyrobCukierniczy",
                columns: table => new
                {
                    IdWyrobuCukierniczego = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CenaZaSzt = table.Column<double>(type: "float", nullable: false),
                    Typ = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WyrobCukierniczy", x => x.IdWyrobuCukierniczego);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrzyjecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRealizacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IdKlient = table.Column<int>(type: "int", nullable: false),
                    IdPracownik = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie", x => x.IdZamowienia);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Klient_IdKlient",
                        column: x => x.IdKlient,
                        principalTable: "Klient",
                        principalColumn: "IdKlient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Pracownik_IdPracownik",
                        column: x => x.IdPracownik,
                        principalTable: "Pracownik",
                        principalColumn: "IdPracownik",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie_WyrobCukierniczy",
                columns: table => new
                {
                    IdWyrobuCukierniczego = table.Column<int>(type: "int", nullable: false),
                    IdZamowienia = table.Column<int>(type: "int", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie_WyrobCukierniczy", x => new { x.IdWyrobuCukierniczego, x.IdZamowienia });
                    table.ForeignKey(
                        name: "FK_Zamowienie_WyrobCukierniczy_WyrobCukierniczy_IdWyrobuCukierniczego",
                        column: x => x.IdWyrobuCukierniczego,
                        principalTable: "WyrobCukierniczy",
                        principalColumn: "IdWyrobuCukierniczego",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zamowienie_WyrobCukierniczy_Zamowienie_IdZamowienia",
                        column: x => x.IdZamowienia,
                        principalTable: "Zamowienie",
                        principalColumn: "IdZamowienia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_IdKlient",
                table: "Zamowienie",
                column: "IdKlient");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_IdPracownik",
                table: "Zamowienie",
                column: "IdPracownik");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_WyrobCukierniczy_IdZamowienia",
                table: "Zamowienie_WyrobCukierniczy",
                column: "IdZamowienia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zamowienie_WyrobCukierniczy");

            migrationBuilder.DropTable(
                name: "WyrobCukierniczy");

            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "Pracownik");
        }
    }
}
