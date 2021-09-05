using System.Collections.Generic;
using System.Linq;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp1.Core.IServices;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp.Domain.Services
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepo;

        public OwnerService(IOwnerRepository ownerRepo)
        {
            _ownerRepo = ownerRepo;
        }
        
        public Owner Create(Owner owner)
        {
            return _ownerRepo.CreateOwner(owner);
        }

        public List<Owner> ReadAllOwners()
        {
            var list = _ownerRepo.ReadAllOwners();
            var orderedEnumerable = list.OrderBy(owner => owner.OwnerName);
            return orderedEnumerable.ToList();
        }

        public Owner UpdateOwner(Owner owner)
        {
            return _ownerRepo.UpdateOwner(owner);
        }

        public void DeleteOwner(int id)
        {
            _ownerRepo.DeleteOwner(id);
        }
    }
}