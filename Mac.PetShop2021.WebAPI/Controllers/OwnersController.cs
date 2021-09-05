using System.Collections.Generic;
using Mac.PetShop2021comp.Domain.Services;
using Mac.PetShop2021comp1.Core.IServices;
using Mac.PetShop2021comp1.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mac.PetShop2021.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPost]
        public ActionResult<Owner> CreateOwner([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.OwnerName))
            {
                return BadRequest("Owner must have at least a name.");
            }

            return _ownerService.Create(owner);
        }

        [HttpGet]
        public ActionResult<List<Owner>> ReadOwners()
        {
            if (_ownerService == null)
            {
                return BadRequest("There is no owners yet.");
            }

            return Ok(_ownerService.ReadAllOwners());
        }

        [HttpPut("{id}")]
        public ActionResult<Owner> UpdateOwner(long id, Owner owner)
        {
            if (owner.Id != id)
            {
                return BadRequest("Id must match");
            }
            return _ownerService.UpdateOwner(owner);
        }

        [HttpDelete("{id}")]
        public void DeleteOwner(int id)
        {
            _ownerService.DeleteOwner(id);
        }
    }
}