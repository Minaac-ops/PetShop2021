using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.EFCore.Entities
{
    public class OwnerEntity
    {
        public int Id { get; set; }
        
        public string OwnerName { get; set; }
        
        public string Address { get; set; }
        
        public string Email { get; set; }
        
        public List<PetEntity> Pets { get; set; }
    }
}