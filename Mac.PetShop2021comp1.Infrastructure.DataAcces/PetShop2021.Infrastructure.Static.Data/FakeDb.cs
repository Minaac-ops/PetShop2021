using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.Infrastructure.DataAcces.PetShop2021.Infrastructure.Static.Data
{
    public class FakeDb
    {
        public static int Id = 1;
        public static List<Pet> Pets = new List<Pet>();

        public static int OwnerId = 1;
        public static List<Owner> Owners = new List<Owner>();
    }
}