using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp.Domain.IRepositories
{
    public interface IInsuranceRepository
    {
        Insurance CreateInsurance(Insurance insurance);
        Insurance getById(int id);
        Insurance ReadAll();
        Insurance UpdateInsurance(int id);
        void DeleteInsurance(int id);
    }
}