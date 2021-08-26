using System;
using System.Collections.Generic;
using System.Dynamic;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.Infrastructure.DataAcces.Repositories
{
    public class PetRepositoryInMemory : IPetRepository
    {
        private static List<Pet> _petTable = new List<Pet>();
        private static int _id = 1;

        public Pet Create(Pet pet)
        {
            pet.Id = _id++;
            _petTable.Add(pet);
            return pet;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _petTable;
        }

        public Pet Update(Pet petUpdate)
        {
            var pet = ReadById(petUpdate.Id);
            if (pet != null)
            {
                pet.Name = petUpdate.Name;
                pet.Price = petUpdate.Price;
                return pet;
            }
            return null;
        }

        public void Delete(int petIdRemove)
        {
            var petFound = ReadById(petIdRemove);
            if (petFound != null)
            {
                _petTable.Remove(petFound);
            }
        }

        public Pet ReadById(int id)
        {
            foreach (var pet in _petTable)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }
    }
}