﻿using System.Collections.Generic;
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
            return _repo.Create(pet);
        }

        public List<Pet> GetPets()
        {
            var list = _repo.ReadPets();
            var orderedEnumerable = list.OrderBy(pet => pet.Price);

            return orderedEnumerable.ToList();
        }

        public void RemovePet(int id)
        {
            _repo.Delete(id);
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            return _repo.Update(petUpdate);
        }

        public Pet SearchById(int id)
        {
            return _repo.ReadById(id);
        }

        public List<Pet> SearchByType(string type)
        {
            var list = _repo.ReadPets();
            var searchEnumerable = list.Where(pet => pet.Type == type);

            return searchEnumerable.ToList();
        }
    }
}