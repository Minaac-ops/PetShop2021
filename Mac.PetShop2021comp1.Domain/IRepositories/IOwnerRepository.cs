using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp.Domain.IRepositories
{
    public interface IOwnerRepository
    {
        Owner CreateOwner(Owner owner);

        IEnumerable<Owner> ReadAllOwners();

        Owner UpdateOwner(Owner owner);

        void DeleteOwner(int id);
    }
}