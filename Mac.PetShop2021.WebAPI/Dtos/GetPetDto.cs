using System;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021.WebAPI.Dtos
{
    public class GetPetDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public PetType Type { get; set; }
        
        public DateTime Birthday { get; set; }
        
        public DateTime SoldTime { get; set; }
        
        public string Color { get; set; }
        
        public double Price { get; set; }
        
        public Owner Owner { get; set; }
    }
}