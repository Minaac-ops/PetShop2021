using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.Core.IServices
{
    public interface IOwnerService
    {
        Owner Create(Owner owner);

        List<Owner> ReadAllOwners();

        Owner UpdateOwner(Owner owner);

        void DeleteOwner(int id);
    }
}