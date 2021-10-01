using System.Collections.Generic;
using System.Linq;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp1.Core.IServices;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp.Domain.Services
{
    public class OwnerService : IOwnerService
    {
        readonly IOwnerRepository _ownerRepo;
        readonly IPetRepository _petRepo;

        public OwnerService(IOwnerRepository ownerRepo, IPetRepository petRepository)
        {
            _ownerRepo = ownerRepo;
            _petRepo = petRepository;
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

        public Owner FindByIdIncludePet(int id)
        {
            var owner = _ownerRepo.ReadById(id);
            owner.Pets = _petRepo.ReadPets().Where(pet => pet.Owner.Id == owner.Id).ToList();
            
            return owner;
        }

        public Owner UpdateOwner(Owner owner)
        {
            return _ownerRepo.UpdateOwner(owner);
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepo.DeleteOwner(id);
        }
    }
}