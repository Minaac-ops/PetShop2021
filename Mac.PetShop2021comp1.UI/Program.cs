﻿using System;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp.Domain.Services;
using Mac.PetShop2021comp1.Core.IServices;
using Mac.PetShop2021comp1.Core.Models;
using Mac.PetShop2021comp1.Infrastructure.DataAcces.Repositories;

namespace Mac.PetShop2021comp1.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IPetRepository repo = new PetRepositoryInMemory();
            IPetService service = new PetService(repo);

            var menu = new Menu(service);
            menu.Start();
        }
    }
}