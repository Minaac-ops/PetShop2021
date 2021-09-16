using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.Core.IServices
{
    public interface IInsuranceService
    {
        Insurance GetById(int id);

        Insurance CreateInsurance(Insurance insurance);
    }
}