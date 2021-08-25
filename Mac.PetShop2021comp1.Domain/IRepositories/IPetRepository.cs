using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp.Domain.IRepositories
{
    public interface IPetRepository
    {
        Pet Add(Pet pet);

        IEnumerable<Pet> FindAll();

        Pet Update(Pet petUpdate);

        void Remove(int petIdRemove);

    }
}