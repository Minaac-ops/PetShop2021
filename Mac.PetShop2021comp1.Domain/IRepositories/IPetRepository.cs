﻿using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp.Domain.IRepositories
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);

        IEnumerable<Pet> ReadPets();

        Pet Update(Pet petUpdate);

        void Delete(int petIdRemove);

        public Pet ReadById(int id);

    }
}