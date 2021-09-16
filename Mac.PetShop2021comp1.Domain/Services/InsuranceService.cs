﻿using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp1.Core.IServices;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp.Domain.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRepository _insuranceRepository;
        
        public InsuranceService(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;

        }

        public Insurance GetById(int id)
        {
            return _insuranceRepository.getById(id);
        }

        public Insurance CreateInsurance(Insurance insurance)
        {
            return _insuranceRepository.CreateInsurance(insurance);
        }
    }
}