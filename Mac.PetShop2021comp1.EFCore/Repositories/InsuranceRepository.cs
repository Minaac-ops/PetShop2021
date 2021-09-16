using System.Linq;
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp1.Core.Models;
using Mac.PetShop2021comp1.EFCore.Entities;

namespace Mac.PetShop2021comp1.EFCore.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly PetShopContext _ctx;
        
        public InsuranceRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public Insurance getById(int id)
        {
            return _ctx.Insurances
                .Select(ie => new Insurance
                {
                    Id = ie.Id,
                    Name = ie.Name,
                    Price = ie.Price
                })
                .FirstOrDefault(i => i.Id == id);
        }

        public Insurance CreateInsurance(Insurance insurance)
        {
            var entity = _ctx.Add(new InsuranceEntity
            {
                Name = insurance.Name,
                Price = insurance.Price
            }).Entity;
            _ctx.SaveChanges();
            return new Insurance
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }
    }
}