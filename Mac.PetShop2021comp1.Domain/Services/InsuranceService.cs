using System.Collections.Generic;
using System.Linq;
using Mac.PetShop2021comp.Domain.IRepositories;
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
        
        public Insurance CreateInsurance(Insurance insurance)
        {
            return _insuranceRepository.CreateInsurance(insurance);
        }
        
        public Insurance GetById(int id)
        {
            return _insuranceRepository.getById(id);
        }
        
        public List<Insurance> ReadAll()
        {
            return _insuranceRepository.ReadAll().ToList();
        }

        public Insurance UpdateInsurance(Insurance insurance)
        {
            return _insuranceRepository.UpdateInsurance(insurance);
        }

        public Insurance DeleteInsurance(int id)
        {
            return _insuranceRepository.DeleteInsurance(id);
        }
    }
}