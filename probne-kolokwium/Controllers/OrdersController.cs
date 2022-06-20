using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using probne_kolokwium.DTOs;
using probne_kolokwium.Entities.Models;
using probne_kolokwium.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace probne_kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IRepoService _service;

        public OrdersController(IRepoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(
                await _service.GetAllOrders()
                .Select(e =>
                new ZamowienieGet
                {
                    IdZamowienia = e.IdZamowienia,
                    DataPrzyjecia = e.DataPrzyjecia,
                    DataRealizacji = e.DataRealizacji,
                    Uwagi = e.Uwagi,
                    Wyroby = e.ZamowieniaWyrobCukierniczy.Select(e => new Wyroby
                    {
                        IdWyrobu = e.IdWyrobuCukierniczego,
                        Nazwa = e.WyrobCukierniczy.Nazwa,
                        Ilosc = e.Ilosc,
                        Uwagi = e.Uwagi,
                        Typ = e.WyrobCukierniczy.Typ,
                        CenaZaSztuke = e.WyrobCukierniczy.CenaZaSzt
                    }).ToList()
                }).ToListAsync()
            );
        }

        [HttpGet("{clientName}")]
        public async Task<IActionResult> Get(string clientName)
        {
            return Ok(
                await _service.GetAllOrdersByClientName(clientName)
                .Select(e =>
                new ZamowienieGet
                {
                    IdZamowienia = e.IdZamowienia,
                    DataPrzyjecia = e.DataPrzyjecia,
                    DataRealizacji = e.DataRealizacji,
                    Uwagi = e.Uwagi,
                    Wyroby = e.ZamowieniaWyrobCukierniczy.Select(e => new Wyroby
                    {
                        IdWyrobu = e.IdWyrobuCukierniczego,
                        Nazwa = e.WyrobCukierniczy.Nazwa,
                        Ilosc = e.Ilosc,
                        Uwagi = e.Uwagi,
                        Typ = e.WyrobCukierniczy.Typ,
                        CenaZaSztuke = e.WyrobCukierniczy.CenaZaSzt
                    }).ToList()
                }).ToListAsync()
            );
        }
    }
}
