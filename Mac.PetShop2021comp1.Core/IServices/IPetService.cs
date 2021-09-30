using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.Core.IServices
{
    public interface IPetService
    {
        int TotalCount();
        Pet Add(Pet pet);

        List<Pet> GetPets(Filter.Filter filter);

        Pet UpdatePet(Pet pet);

        Pet RemovePet(int id);
    }
}