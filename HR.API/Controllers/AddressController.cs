//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

using HR.API.Models;
using HR.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IGenericCRUDService<AddressModel> _addressSvc;
        public AddressController(IGenericCRUDService<AddressModel> addressSvc)
        {
            _addressSvc = addressSvc;
        }

        // GET: api/<addressController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _addressSvc.GetAll());
        }

        // GET api/<addressController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound($"Address with the given id:{id} is not found.");
            else if (id < 0)
                return BadRequest("Wrong data.");

            return Ok(await _addressSvc.Get(id));
        }

        // POST api/<addressController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddressModel address)
        {
            var createdaddress = await _addressSvc.Create(address);
            var routeValues = new { id = createdaddress.Id };
            return CreatedAtRoute(routeValues, createdaddress);
        }

        // PUT api/<addressController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AddressModel address)
        {
            var updatedaddress = await _addressSvc.Update(id, address);
            return Ok(updatedaddress);
        }

        // DELETE api/<addressController>/5
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
