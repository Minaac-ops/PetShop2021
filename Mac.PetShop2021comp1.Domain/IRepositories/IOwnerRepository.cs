using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp.Domain.IRepositories
{
    public interface IOwnerRepository
    {
        Owner CreateOwner(Owner owner);

        IEnumerable<Owner> ReadAllOwners();

        Owner ReadById(long id);

        Owner UpdateOwner(Owner owner);

        Owner DeleteOwner(int id);
    }
}