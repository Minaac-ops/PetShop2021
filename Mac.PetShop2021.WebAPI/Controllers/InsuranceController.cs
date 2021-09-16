using System;
using System.Collections.Generic;
using Mac.PetShop2021comp1.Core.IServices;
using Mac.PetShop2021comp1.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mac.PetShop2021.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpGet("{id}")]
        public ActionResult<Insurance> ReadById(int id)
        {
            try
            {
                return Ok(_insuranceService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call 911");
            }
        }

        [HttpGet]
        public ActionResult<List<Insurance>> ReadAll()
        {
            try
            {
                return Ok(_insuranceService.ReadAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpPost]
        public ActionResult<Insurance> CreateInsurance(Insurance insurance)
        {
            try
            {
                return Ok(_insuranceService.CreateInsurance(insurance));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call Mathias, he knows");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Insurance> UpdateInsurance(int id)
        {
            try
            {
                return Ok(_insuranceService.UpdateInsurance(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpDelete("{id}")]
        public void DeleteInsurance(int id)
        {
            try
            {
                _insuranceService.DeleteInsurance(id);
            }
            catch (Exception e)
            {
                StatusCode(500, "Something went wrong");
            }
        }
    }
}