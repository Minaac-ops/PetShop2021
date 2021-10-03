using System;
using System.Collections.Generic;

namespace Mac.PetShop2021comp1.Core.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PetType Type { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime SoldTime { get; set; }
        public List<Color> Colors { get; set; }
        public Insurance Insurance { get; set; }
        public double Price { get; set; }
        public Owner Owner { get; set; }
    }
}