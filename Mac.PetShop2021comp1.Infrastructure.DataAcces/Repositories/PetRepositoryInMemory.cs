using System.Collections.Generic;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.Infrastructure.DataAcces.Repositories
{
    public class PetRepositoryInMemory : IPetRepository
    {
        private static List<Pet> _petTable = new List<Pet>();
        private static int _id = 1;
        public Pet Add(Pet pet)
        {
            pet.Id = _id++;
            _petTable.Add(pet);
            return pet;
        }

        public IEnumerable<Pet> FindAll()
        {
            return _petTable;
        }

        public Pet Update(Pet petUpdate)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int petIdRemove)
        {
            throw new System.NotImplementedException();
        }
    }
}