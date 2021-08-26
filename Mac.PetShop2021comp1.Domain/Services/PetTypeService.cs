using System.Collections.Generic;
using System.Linq;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp1.Core.IServices;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRepository _typeRepo;
        
        public PetTypeService(IPetTypeRepository typeRepo)
        {
            _typeRepo = typeRepo;
        }
        
        public PetType CreatePetType(PetType petType)
        {
            return _typeRepo.CreateType(petType);
        }
        
        public List<PetType> GetPetTypes()
        {
            return _typeRepo.ReadPetTypes().ToList();
        }
        
        public PetType GetById(int id)
        {
            return _typeRepo.ReadById(id);
        }
    }
}