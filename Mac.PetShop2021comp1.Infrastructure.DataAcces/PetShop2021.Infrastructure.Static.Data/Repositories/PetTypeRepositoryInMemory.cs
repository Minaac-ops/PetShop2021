using System.Collections.Generic;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.Infrastructure.DataAcces.PetShop2021.Infrastructure.Static.Data.Repositories
{
    public class PetTypeRepositoryInMemory : IPetTypeRepository
    {
        private static List<PetType> _typeTable = new List<PetType>();
        private static int _typeId = 1;

        public PetType CreateType(PetType petType)
        {
            petType.Id = _typeId++;
            _typeTable.Add(petType);
            return petType;
        }

        public PetType ReadById(int id)
        {
            foreach (var petType in _typeTable)
            {
                if (petType.Id == id)
                {
                    return petType;
                }
            }
            return null;
        }

        public IEnumerable<PetType> ReadPetTypes()
        {
            return _typeTable;
        }
    }
}