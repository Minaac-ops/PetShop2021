using System;
using System.Collections.Generic;
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
            //Relations
            modelBuilder.Entity<PetEntity>()
                .HasOne(pe => pe.Insurance)
                .WithMany(ie => ie.Pets);

            modelBuilder.Entity<PetEntity>()
                .HasOne(pe => pe.Owner)
                .WithMany(oe => oe.Pets);

            modelBuilder.Entity<PetEntity>()
                .HasOne(p => p.PetType)
                .WithMany(pt => pt.Pets);

            modelBuilder.Entity<PetColorEntity>()
                .HasKey(pc => new {pc.ColorId, pc.PetId});
            modelBuilder.Entity<PetColorEntity>()
                .HasOne(pc => pc.Color)
                .WithMany(c => c.Pets)
                .HasForeignKey(pc => pc.ColorId);

            modelBuilder.Entity<PetColorEntity>()
                .HasOne(pc => pc.Pet)
                .WithMany(p => p.Colors)
                .HasForeignKey(pc => pc.PetId);
            
            //Insurances
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity()
                    {Id = 1, Name = "HorseInsurance", Price = 500});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity()
                    {Id = 2, Name = "CatInsurance", Price = 30});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity()
                    {Id = 3, Name = "DogInsurance", Price = 50});

            //Owners
            modelBuilder.Entity<OwnerEntity>()
                .HasData(new OwnerEntity {Id = 1, Address = "Grønnegade 77", Email = "mac@live.dk", OwnerName = "Mina Anne Christensen"});
            modelBuilder.Entity<OwnerEntity>()
                .HasData(new OwnerEntity {Id = 2, Address = "Skolgade 66", Email = "tak@live.dk", OwnerName = "Trine Agnete Knudsen"});
            
            //Colors
            modelBuilder.Entity<ColorEntity>()
                .HasData(new ColorEntity() {Id = 1, Color = "Brown"});
            modelBuilder.Entity<ColorEntity>()
                .HasData(new ColorEntity() {Id = 2, Color = "Red"});
            modelBuilder.Entity<ColorEntity>()
                .HasData(new ColorEntity() {Id = 3, Color = "White"});
            
            //PetTypes
            modelBuilder.Entity<PetTypeEntity>()
                .HasData(new PetTypeEntity() {Id = 1, Name = "Horse",});
            modelBuilder.Entity<PetTypeEntity>()
                .HasData(new PetTypeEntity() {Id = 2, Name = "Cat"});

            //PetColor-table (many-many)
            modelBuilder.Entity<PetColorEntity>()
                .HasData(new PetColorEntity() {PetId = 1 ,ColorId = 1});
            modelBuilder.Entity<PetColorEntity>()
                .HasData(new PetColorEntity() {PetId = 1, ColorId = 2});
            modelBuilder.Entity<PetColorEntity>()
                .HasData(new PetColorEntity() {PetId = 2, ColorId = 3});
            
            //Pets
            modelBuilder.Entity<PetEntity>()
                .HasData(new PetEntity()
                {
                    Id = 1,
                    Name = "Rex",
                    Birthday = DateTime.Today,
                    SoldTime = DateTime.Today,
                    Price = 50000,
                    PetTypeId = 1,
                    InsuranceId = 1,
                    OwnerId = 2
                });
            
            modelBuilder.Entity<PetEntity>()
                .HasData(new PetEntity() {
                    Id = 2,
                    Name = "Perle",
                    Birthday = DateTime.Today,
                    SoldTime = DateTime.Today,
                    Price = 1000,
                    PetTypeId = 2,
                    InsuranceId = 2,
                    OwnerId = 1
                });
        }
        
        public DbSet<InsuranceEntity> Insurances { get; set; }
        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<PetTypeEntity> PetTypes { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<PetColorEntity> PetColors { get; set; }
        
    }
}