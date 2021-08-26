using System;
using System.Security.Authentication.ExtendedProtection;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp.Domain.Services;
using Mac.PetShop2021comp1.Core.IServices;
using Mac.PetShop2021comp1.Core.Models;
using Mac.PetShop2021comp1.Infrastructure.DataAcces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Mac.PetShop2021comp1.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepositoryInMemory>();
            serviceCollection.AddScoped<IPetService, PetService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetService>();

            //IPetRepository repo = new PetRepositoryInMemory();
            //IPetService service = new PetService(repo);

            var menu = new Menu(petService);
            menu.InitData();
            menu.Start();
        }
    }
}