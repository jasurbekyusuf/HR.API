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
    public class EmployeeController : ControllerBase
    {
        private readonly IGenericCRUDService<EmployeeModel> _employeeSvc;
        public EmployeeController(IGenericCRUDService<EmployeeModel> employeeSvc)
        {
            _employeeSvc = employeeSvc;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeSvc.GetAll());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound($"Employee with the given id:{id} is not found.");
            else if (id < 0)
                return BadRequest("Wrong data.");

            return Ok(await _employeeSvc.Get(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async  Task<IActionResult> Post([FromBody] EmployeeModel employee)
        {
            var createdEmployee = await _employeeSvc.Create(employee);
            var routeValues = new { id = createdEmployee.Id };
            return CreatedAtRoute(routeValues, createdEmployee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeModel employee)
        {
            var updatedEmployee = await _employeeSvc.Update(id, employee);
            return Ok(updatedEmployee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleteResult = await _employeeSvc.Delete(id);

            if (deleteResult)
                return NoContent();
            else
                return NotFound();
        }
    }
}


