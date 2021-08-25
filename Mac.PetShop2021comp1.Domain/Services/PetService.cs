using System.Collections.Generic;
using System.Linq;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp1.Core.IServices;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _repo;
        public PetService(IPetRepository repo)
        {
            _repo = repo;
        }

        public Pet Add(Pet pet)
        {
            return _repo.Add(pet);
        }

        public List<Pet> GetPets()
        {
            var list = _repo.FindAll();
            var orderedEnumerable = list.OrderBy(pet => pet.Price);

            return orderedEnumerable.ToList();
        }
    }
}