using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        IEnumerable<PetType> readPetTypes();

        PetType CreateType(PetType petType);

        PetType GetById(int id);
    }
}