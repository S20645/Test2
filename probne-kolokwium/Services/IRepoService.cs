﻿using probne_kolokwium.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probne_kolokwium.Services
{
    public interface IRepoService
    {
        IQueryable<Zamowienie> GetAllOrders();
        IQueryable<Zamowienie> GetAllOrdersByClientName(string clientName);
        Task SaveChangesAsync();
        IQueryable<Pracownik> GetEmployeeById(int id);
        IQueryable<Klient> GetClientById(int id);
        IQueryable<WyrobCukierniczy> GetConfectioneryById(int id);
        Task CreateAsync<T>(T entity) where T : class;
    }
}
