using System.Collections.Generic;

namespace Mac.PetShop2021comp1.EFCore.Entities
{
    public class PetTypeEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public List<PetEntity> Pets { get; set; }
    }
}