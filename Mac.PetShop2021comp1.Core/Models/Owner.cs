using System.Collections.Generic;

namespace Mac.PetShop2021comp1.Core.Models
{
    public class Owner
    {
        public int Id { get; set; }
        
        public string OwnerName { get; set; }
        
        public string Address { get; set; }
        
        public string Email { get; set; }
        
        public List<Pet> Pets { get; set; }
    }
}