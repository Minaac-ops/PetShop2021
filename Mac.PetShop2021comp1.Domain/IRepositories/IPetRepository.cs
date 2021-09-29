using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp.Domain.IRepositories
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);

        IEnumerable<Pet> ReadPets();
        
        public Pet ReadById(int id);

        Pet Update(Pet petUpdate);

        Pet Delete(int petIdRemove);
    }
}