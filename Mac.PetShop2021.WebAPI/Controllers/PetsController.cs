using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mac.PetShop2021.WebAPI.Dtos;
using Mac.PetShop2021comp1.Core.Filtering;
using Mac.PetShop2021comp1.Core.IServices;
using Mac.PetShop2021comp1.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mac.PetShop2021.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpPost]
        public ActionResult<Pet> Create([FromBody] Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("Name is requiered for creating a new pet.");
            }

            return _petService.Add(pet);
        }

        [HttpGet]
        public ActionResult<GetAllPetDto> GetAll([FromQuery] Filter filter)
        {
            try
            {
                var list = _petService.GetPets(filter);
                return Ok(new GetAllPetDto
                {
                    List = list.Select(p => new GetPetDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Colors = p.Colors,
                        PetType = p.Type,
                        Insurance = p.Insurance,
                        Owner = p.Owner
                    }).ToList()
                });
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.StackTrace);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> Update(long id, [FromBody] Pet pet)
        {
            if (pet.Id != id)
            {
                return BadRequest("Id must match");
            }

            return _petService.UpdatePet(pet);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petService.RemovePet(id);
        }
    }
}