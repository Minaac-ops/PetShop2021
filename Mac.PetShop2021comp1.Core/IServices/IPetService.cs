using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.Core.IServices
{
    public interface IPetService
    {
        Pet Add(Pet pet);

        List<Pet> GetPets();
        
        public List<Pet> Get5Cheapest();
        
        Pet UpdatePet(Pet pet);

        Pet RemovePet(int id);
        
        Pet SearchById(int id);

        List<Pet> SearchByType(string type);
    }
}