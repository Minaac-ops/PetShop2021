using System;
using System.Collections.Generic;
using System.Linq;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.Infrastructure.DataAcces.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {

        private static List<Owner> _ownersTable = new List<Owner>();
        private static int _id = 1;
        
        public Owner CreateOwner(Owner owner)
        {
            owner.Id = _id++;
            _ownersTable.Add(owner);
            return owner;
        }

        public IEnumerable<Owner> ReadAllOwners()
        {
            return _ownersTable;
        }

        public Owner ReadById(long id)
        {
            var entity = _ownersTable.FirstOrDefault(owner => owner.Id == id);
            return entity;
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

        public void DeleteOwner(int id)
        {
            var ownerFound = ReadById(id);
            if (ownerFound != null)
            {
                _ownersTable.Remove(ownerFound);
            }
        }
    }
}