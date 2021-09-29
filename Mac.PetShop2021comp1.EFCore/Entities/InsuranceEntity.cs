using System.Collections.Generic;

namespace Mac.PetShop2021comp1.EFCore.Entities
{
    public class InsuranceEntity
    {
        public List<PetEntity> Pets { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price{ get; set; }
    }
}