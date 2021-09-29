using System.Collections.Generic;
using System.Linq;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.Infrastructure.DataAcces.PetShop2021.Infrastructure.Static.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        public OwnerRepository()
        {
            if (FakeDb.Owners.Count > 0) return;
            var owner1 = new Owner()
            {
                Id = FakeDb.OwnerId++,
                OwnerName = "Mina",
                Address = "Grønnegade 77",
                Email = "trine@live.dk"
            };
            FakeDb.Owners.Add(owner1);
        }
        
        public Owner CreateOwner(Owner owner)
        {
            owner.Id = FakeDb.OwnerId++;
            FakeDb.Owners.Add(owner);
            return owner;
        }

        public IEnumerable<Owner> ReadAllOwners()
        {
            return FakeDb.Owners;
        }

        public Owner ReadById(long id)
        {
            return FakeDb.Owners.
                Select(o => new Owner()
                {
                    Id = o.Id,
                    OwnerName = o.Address,
                    Address = o.Address,
                    Email = o.Email,
                    
                }).
                FirstOrDefault(o => o.Id == id);
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            var owner = ReadById(ownerUpdate.Id);
            if (owner != null)
            {
                owner.OwnerName = ownerUpdate.OwnerName;
                owner.Email = ownerUpdate.Email;
                owner.Address = ownerUpdate.Address;
            }
            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            var ownerFound = ReadById(id);
            if (ownerFound != null)
            {
                FakeDb.Owners.Remove(ownerFound);
                return ownerFound;
            }
            return null;
        }
    }
}