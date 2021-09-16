using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.Core.IServices
{
    public interface IInsuranceService
    { 
        Insurance CreateInsurance(Insurance insurance);
        Insurance GetById(int id);
        Insurance ReadAll();
        Insurance UpdateInsurance(int id);
        void DeleteInsurance(int id);
    }
}