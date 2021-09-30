using System.Collections.Generic;
using System.Linq;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp1.Core.Filter;
using Mac.PetShop2021comp1.Core.Models;
using Mac.PetShop2021comp1.EFCore.Entities;

namespace Mac.PetShop2021comp1.EFCore.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopContext _ctx;

        public PetRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public int TotalCount()
        {
            return _ctx.Pets.Count();
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
            var selectQuery = _ctx.Pets.Select(pe => new Pet
            {
                Id = pe.Id,
                Birthday = pe.Birthday,
                Color = pe.Color,
                Name = pe.Name,
                Price = pe.Price,
                SoldTime = pe.SoldTime
            });
            if (filter.OrderDir.ToLower().Equals("asc"))
            {
                switch (filter.OrderBy.ToLower())
                {
                    case "name":
                        selectQuery = selectQuery.OrderBy(p => p.Name);
                        break;
                    case "id":
                        selectQuery = selectQuery.OrderBy(p => p.Id);
                        break;
                }
            }
            else
            {
                switch (filter.OrderBy.ToLower())
                {
                    case "name":
                        selectQuery = selectQuery.OrderByDescending(p => p.Name);
                        break;
                    case "id":
                        selectQuery = selectQuery.OrderByDescending(p => p.Id);
                        break;
                }
            }

            selectQuery = selectQuery.Where(p => p.Name.ToLower().StartsWith(filter.Search.ToLower()));
            var query = selectQuery
                .Skip((filter.Page - 1) * filter.Limit)
                .Take((filter.Limit));
            return query.ToList();
        }

        public Pet ReadById(int id)
        {
            return _ctx.Pets
                .Select(p => new Pet
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Birthday = p.Birthday,
                    SoldTime = p.SoldTime
                }).FirstOrDefault(p => p.Id == id);
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

        public Pet Delete(int petIdRemove)
        {
            _ctx.Pets.Remove(new PetEntity() {Id = petIdRemove});
            _ctx.SaveChanges();
            return new Pet
            {
                Id = petIdRemove
            };
        }
    }
}