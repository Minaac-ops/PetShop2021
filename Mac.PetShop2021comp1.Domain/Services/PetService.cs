using System;
using System.Collections.Generic;
using System.Linq;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp1.Core.Filter;
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

        public List<Pet> GetPets(Filter filter)
        {
            if (filter == null || filter.Limit < 1 || filter.Limit > 100)
            {
                throw new ArgumentException("Filter limit must be between 1-100");
            }

            var totalCount = TotalCount();
            var maxPageCount = Math.Ceiling((double) totalCount / filter.Limit);
            if (filter.Page < 1 || filter.Page > maxPageCount)
            {
                throw new ArgumentException($"$Filter page must be between 1-{maxPageCount}");
            }
            return _repo.ReadPets(filter).ToList();
        }

        public int TotalCount()
        {
            return _repo.TotalCount();
        }
        
        public Pet UpdatePet(Pet petUpdate)
        {
            return _repo.Update(petUpdate);
        }

        public Pet RemovePet(int id)
        {
            return _repo.Delete(id);
        }
    }
}