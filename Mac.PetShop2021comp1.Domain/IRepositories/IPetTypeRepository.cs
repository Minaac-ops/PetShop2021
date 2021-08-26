using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        PetType CreateType(PetType petType);
        
        IEnumerable<PetType> ReadPetTypes();
        
        PetType ReadById(int id);
    }
}