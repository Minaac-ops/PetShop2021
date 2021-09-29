using System.Collections.Generic;
using System.Linq;
using Mac.PetShop2021.WebAPI;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp1.Core.Models;
using Mac.PetShop2021comp1.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mac.PetShop2021comp1.EFCore.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopContext _ctx;
        
        public PetRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public Pet Create(Pet pet)
        {
            var beforeSaveEntity = new PetEntity()
            {
                Name = pet.Name,
                Birthday = pet.Birthday,
                SoldTime = pet.SoldTime
            };
            var afterSaveEntity = _ctx.Pets.Add(beforeSaveEntity).Entity;
            
            _ctx.SaveChanges();
            return new Pet()
            {
                Id = afterSaveEntity.Id,
                Name = afterSaveEntity.Name,
                Birthday = afterSaveEntity.Birthday,
                SoldTime = afterSaveEntity.SoldTime
            };
        }

        public IEnumerable<Pet> ReadPets(Filter filter)
        {
            return _ctx.Pets
                .Skip((filter.Page -1) * filter.Limit)
                .Take(filter.Limit)
                .Select(p => new Pet()
                {
                    Id = p.Id,
                    Birthday = p.Birthday,
                    Color = p.Color,
                    Name = p.Name,
                    Price = p.Price,
                    SoldTime = p.SoldTime,
                    InsuranceId = p.InsuranceId,
                    PetTypeId = p.PetTypeId
                }).ToList();
        }

        public Pet ReadById(int id)
        {
            return _ctx.Pets
                .Select(p => new Pet
                {
                    Id = p.Id,
                    Birthday = p.Birthday,
                    Color = p.Color,
                    Name = p.Name,
                    Price = p.Price,
                    SoldTime = p.SoldTime,
                    InsuranceId = p.InsuranceId,
                    PetTypeId = p.PetTypeId
                })
                .FirstOrDefault(p => p.Id == id);
        }

        public Pet Update(Pet petUpdate)
        {
            var beforeSaveEntity = new PetEntity()
            {
                Id = petUpdate.Id,
                Name = petUpdate.Name,
                Birthday = petUpdate.Birthday,
                SoldTime = petUpdate.SoldTime
            };
            var afterSaveEntity = _ctx.Pets.Update(beforeSaveEntity).Entity;
            
            _ctx.SaveChanges();
            return new Pet()
            {
                Id = afterSaveEntity.Id,
                Name = afterSaveEntity.Name,
                Birthday = afterSaveEntity.Birthday,
                SoldTime = afterSaveEntity.SoldTime
            };
        }

        public void Delete(int petIdRemove)
        {
            _ctx.Remove(new PetEntity() {Id = petIdRemove});
            _ctx.SaveChanges();
        }
    }
}