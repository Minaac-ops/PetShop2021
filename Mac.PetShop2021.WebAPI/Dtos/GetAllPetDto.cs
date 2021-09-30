using System.Collections.Generic;

namespace Mac.PetShop2021.WebAPI.Dtos
{
    public class GetAllPetDto
    {
        public List<GetPetDto> List { get; set; }
    }
}