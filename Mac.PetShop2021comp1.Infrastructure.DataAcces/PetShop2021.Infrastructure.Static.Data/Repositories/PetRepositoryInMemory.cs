using System;
using System.Collections.Generic;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp1.Core.Filtering;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.Infrastructure.DataAcces.PetShop2021.Infrastructure.Static.Data.Repositories
{
    public class PetRepositoryInMemory : IPetRepository
    {
        public PetRepositoryInMemory()
        {
            if (FakeDb.Pets.Count >= 1) return;
            var pet1 = new Pet()
            {
                Id = FakeDb.Id++,
                Birthday = new DateTime(2021, 8, 9),
                Color = "Brown",
                Name = "Trine",
                Price = 3000,
                Type = new PetType()
                {
                    Id = 1,
                    Name = "Cat"
                },
                Owner = new Owner(){Id = 1}
            };
            
            var pet2 = new Pet()
            {
                Id = FakeDb.Id++,
                Birthday = new DateTime(2021, 6, 9),
                Color = "Red",
                Name = "Mathias",
                Price = 3000,
                Type = new PetType()
                {
                    Id = 2,
                    Name = "Fox"
                },
                Owner = new Owner(){Id = 1}
            };
            FakeDb.Pets.Add(pet1);
            FakeDb.Pets.Add(pet2);
        }

        public int TotalCount()
        {
            throw new NotImplementedException();
        }

        public Pet Create(Pet pet)
        {
            FakeDb.Id++;
            FakeDb.Pets.Add(pet);
            return pet;
        }

        public IEnumerable<Pet> ReadPets(Filter filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDb.Pets;
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

        public Pet Delete(int petIdRemove)
        {
            var petFound = ReadById(petIdRemove);
            if (petFound != null)
            {
                FakeDb.Pets.Remove(petFound);
                return petFound;
            }

            return null;
        }

        public Pet ReadById(int id)
        {
            foreach (var pet in FakeDb.Pets)
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