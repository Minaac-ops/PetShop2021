using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.Core.IServices
{
    public interface IPetTypeService
    {
        List<PetType> GetPetTypes();

        PetType CreatePetType(PetType petType);

        PetType GetById(int id);
    }
}