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
            modelBuilder.Entity<PetEntity>()
                .HasOne(pe => pe.Insurance)
                .WithMany(ie => ie.Pets);

            modelBuilder.Entity<PetEntity>()
                .HasOne(p => p.PetType)
                .WithMany();
            
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity()
                {Id = 1, Name = "HorseInsurance", Price = 500});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity()
                    {Id = 2, Name = "CatInsurance", Price = 30});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity()
                    {Id = 3, Name = "DogInsurance", Price = 50});

            modelBuilder.Entity<OwnerEntity>().HasData(new OwnerEntity
            {
                Id = 1, Address = "Vejen 2", Email = "hejsa@live.dk", OwnerName = "Trine"
            });
            modelBuilder.Entity<OwnerEntity>().HasData(new OwnerEntity
            {
                Id = 2, Address = "Vejen 5", Email = "jegertræt@live.dk", OwnerName = "Mathias"
            });
        }

        public DbSet<InsuranceEntity> Insurances { get; set; }
        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<PetTypeEntity> PetTypes { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
    }
}