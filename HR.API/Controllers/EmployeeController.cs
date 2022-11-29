//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

using HR.API.Models;
using Microsoft.AspNetCore.Mvc;
///*using Microsoft.Gra*/ph;

namespace HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await MockEmployeeRepository.GetEmployees());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound($"Employee with the given id:{id} is not found.");
            else if (id < 0)
                return BadRequest("Wrong data.");

            return Ok(await MockEmployeeRepository.GetEmployee(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async  Task<IActionResult> Post([FromBody] Employee employee)
        {
            var createdEmployee = await MockEmployeeRepository.CreateEmployee(employee);
            var routeValues = new { id = createdEmployee.Id };
            return CreatedAtRoute(routeValues, createdEmployee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}


