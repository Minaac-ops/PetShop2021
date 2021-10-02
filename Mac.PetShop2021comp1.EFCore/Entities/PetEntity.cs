using System;
using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.EFCore.Entities
{
    public class PetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime SoldTime { get; set; }
        public double Price { get; set; }
        public int PetTypeId { get; set; }
        public PetTypeEntity PetType { get; set; }
        public int InsuranceId { get; set; }
        public InsuranceEntity Insurance { get; set; }
        public int OwnerId { get; set; }
        public OwnerEntity Owner { get; set; }
        
        public List<PetColorEntity> Colors { get; set; }

    }
}