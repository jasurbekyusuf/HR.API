//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

using HR.API.Models;
using HR.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IGenericCRUDService<AddressModel> _addressSvc;
        public AddressController(IGenericCRUDService<AddressModel> addressSvc)
        {
            _addressSvc = addressSvc;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _addressSvc.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound($"Address with the given id:{id} is not found.");
            else if (id < 0)
                return BadRequest("Wrong data.");

            return Ok(await _addressSvc.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddressModel address)
        {
            var createdaddress = await _addressSvc.Create(address);
            var routeValues = new { id = createdaddress.Id };
            return CreatedAtRoute(routeValues, createdaddress);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AddressModel address)
        {
            var updatedaddress = await _addressSvc.Update(id, address);
            return Ok(updatedaddress);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleteResult = await _addressSvc.Delete(id);

            if (deleteResult)
                return NoContent();
            else
                return NotFound();
        }
    }
}
