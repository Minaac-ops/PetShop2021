using System.Collections.Generic;
using System.Linq;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp1.Core.IServices;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRepository _TypeRepo;
        public PetTypeService(IPetTypeRepository typeRepo)
        {
            _TypeRepo = typeRepo;
        }
        
        public List<PetType> GetPetTypes()
        {
            return _TypeRepo.readPetTypes().ToList();
        }

        public PetType CreatePetType(PetType petType)
        {
            return _TypeRepo.CreateType(petType);
        }

        public PetType GetById(int id)
        {
            return _TypeRepo.GetById(id);
        }
    }
}