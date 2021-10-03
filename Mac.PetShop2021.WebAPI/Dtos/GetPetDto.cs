using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021.WebAPI.Dtos
{
    public class GetPetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public PetType PetType { get; set; }
        public List<Color> Colors { get; set; }
    }
}