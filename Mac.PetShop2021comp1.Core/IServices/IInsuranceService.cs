using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.Core.IServices
{
    public interface IInsuranceService
    { 
        Insurance CreateInsurance(Insurance insurance);
        Insurance GetById(int id);
        List<Insurance> ReadAll();
        Insurance UpdateInsurance(Insurance insurance);
        Insurance DeleteInsurance(int id);
    }
}