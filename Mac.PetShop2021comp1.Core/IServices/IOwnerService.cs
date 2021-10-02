using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.Core.IServices
{
    public interface IOwnerService
    {
        Owner Create(Owner owner);

        List<Owner> ReadAllOwners();
        
        //Owner FindByIdIncludePet(int id);

        Owner UpdateOwner(Owner owner);

        Owner DeleteOwner(int id);
    }
}