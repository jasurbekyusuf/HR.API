//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

using HR.API.Models.Employees;
using HR.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IGenericCRUDService<EmployeeModel> _employeeSvc;
        public EmployeeController(IGenericCRUDService<EmployeeModel> employeeSvc)
        {
            _employeeSvc = employeeSvc;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeSvc.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound($"Employee with the given id:{id} is not found.");
            else if (id < 0)
                return BadRequest("Wrong data.");

            return Ok(await _employeeSvc.Get(id));
        }

        [HttpPost]
        public async  Task<IActionResult> Post([FromBody] EmployeeModel employee)
        {
            var createdEmployee = await _employeeSvc.Create(employee);
            var routeValues = new { id = createdEmployee.Id };
            return CreatedAtRoute(routeValues, createdEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeModel employee)
        {
            var updatedEmployee = await _employeeSvc.Update(id, employee);
            return Ok(updatedEmployee);
        }

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


