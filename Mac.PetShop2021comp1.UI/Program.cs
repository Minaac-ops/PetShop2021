using System;
using System.Security.Authentication.ExtendedProtection;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp.Domain.Services;
using Mac.PetShop2021comp1.Core.IServices;
using Mac.PetShop2021comp1.Core.Models;
using Mac.PetShop2021comp1.EFCore.Repositories;
using Mac.PetShop2021comp1.Infrastructure.DataAcces.PetShop2021.Infrastructure.Static.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using OwnerRepository = Mac.PetShop2021comp1.EFCore.Repositories.OwnerRepository;

namespace Mac.PetShop2021comp1.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetTypeRepository, PetTypeRepository>();
            
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPetTypeService, PetTypeService>();

            serviceCollection.AddScoped<IOwnerService, OwnerService>();
            serviceCollection.AddScoped<IOwnerRepository, OwnerRepository>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetService>();

            var petTypeService = serviceProvider.GetRequiredService<IPetTypeService>();

            //IPetRepository repo = new PetRepositoryInMemory();
            //IPetService service = new PetService(repo);

            var menu = new Menu(petService, petTypeService);
            menu.InitData();
            //menu.Start();
        }
    }
}