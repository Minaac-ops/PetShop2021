using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp.Domain.IRepositories
{
    public interface IInsuranceRepository
    {
        Insurance CreateInsurance(Insurance insurance);
        Insurance getById(int id);
        IEnumerable<Insurance> ReadAll();
        Insurance UpdateInsurance(Insurance insurance);
        Insurance DeleteInsurance(int id);
    }
}