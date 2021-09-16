using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp.Domain.IRepositories
{
    public interface IInsuranceRepository
    {
        Insurance getById(int id);

        Insurance CreateInsurance(Insurance insurance);
    }
}