using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public ActionResult<List<Pet>> GetAll()
        {
            if (_petService.GetPets() == null)
            {
                return BadRequest("There is no pets in the petshop");
            }

            return _petService.GetPets();
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

        /*[HttpGet("id}")]
        public ActionResult<Pet> ReadById(long id)
        {
            Pet pet = _petService.SearchById(id);
            return Ok(pet);
        }*/
    }
}