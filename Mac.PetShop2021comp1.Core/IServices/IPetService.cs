using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.Core.IServices
{
    public interface IPetService
    {
        Pet Add(Pet pet);

        List<Pet> GetPets();

        void RemovePet(int id);

        Pet UpdatePet(Pet pet);

        public Pet SearchById(int id);
    }
}