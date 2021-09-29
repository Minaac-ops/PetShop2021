using System.Collections.Generic;
using System.Linq;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp1.Core.Models;
using Mac.PetShop2021comp1.EFCore.Entities;

namespace Mac.PetShop2021comp1.EFCore.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PetShopContext _ctx;

        public OwnerRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }
        public Owner CreateOwner(Owner owner)
        {
            var beforeSaveEntity = new OwnerEntity
            {
                OwnerName = owner.OwnerName,
                Address = owner.Address,
                Email = owner.Email
            };
            var afterSaveEntity = _ctx.Owners.Add(beforeSaveEntity).Entity;
            _ctx.SaveChanges();
            return new Owner
            {
                Id = afterSaveEntity.Id,
                Address = afterSaveEntity.Address,
                Email = afterSaveEntity.Email,
                OwnerName = afterSaveEntity.OwnerName
            };
        }

        public IEnumerable<Owner> ReadAllOwners()
        {
            return _ctx.Owners
                .Select(ow => new Owner
                {
                    Id = ow.Id,
                    Address = ow.Address,
                    Email = ow.Email,
                    OwnerName = ow.OwnerName
                }).ToList();
        }

        public Owner ReadById(long id)
        {
            return _ctx.Owners
                .Select(ow => new Owner
                {
                    Id = ow.Id,
                    Address = ow.Address,
                    Email = ow.Email,
                    OwnerName = ow.OwnerName
                }).FirstOrDefault(owner => owner.Id == id);
        }

        public Owner UpdateOwner(Owner owner)
        {
            var beforeSaveEntity = new OwnerEntity
            {
                OwnerName = owner.OwnerName,
                Address = owner.Address,
                Email = owner.Email,
                Id = owner.Id
            };
            var afterSaveEntity = _ctx.Owners.Update(beforeSaveEntity).Entity;
            _ctx.SaveChanges();
            return new Owner
            {
                OwnerName = afterSaveEntity.OwnerName,
                Address = afterSaveEntity.Address,
                Email = afterSaveEntity.Email,
                Id = afterSaveEntity.Id
            };
        }

        public Owner DeleteOwner(int id)
        {
            _ctx.Owners.Remove(new OwnerEntity {Id = id});
            _ctx.SaveChanges();
            return new Owner
            {
                Id = id
            };
        }
    }
}