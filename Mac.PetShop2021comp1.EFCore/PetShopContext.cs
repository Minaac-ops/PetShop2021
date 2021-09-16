using Mac.PetShop2021comp1.Core.Models;
using Mac.PetShop2021comp1.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mac.PetShop2021comp1.EFCore
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> opt) : base(opt){ }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity()
                {Id = 1, Name = "SafeStuff", Price = 22});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity()
                    {Id = 2, Name = "PetInsurance", Price = 25});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity()
                    {Id = 3, Name = "BingoStuff", Price = 12});
        }

        public DbSet<InsuranceEntity> Insurances { get; set; }
    }
}