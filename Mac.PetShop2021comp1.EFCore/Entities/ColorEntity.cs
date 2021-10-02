using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.EFCore.Entities
{
    public class ColorEntity
    {
        public int Id { get; set; }
        public string Color { get; set; }
        
        public List<PetColorEntity> Pets { get; set; }
    }
}