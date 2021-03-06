using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.Core.IServices
{
    public interface IPetTypeService
    {
        PetType CreatePetType(PetType petType);
        
        List<PetType> GetPetTypes();

        PetType GetById(int id);
    }
}