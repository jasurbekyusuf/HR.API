//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

using HR.API.Models;
using HR.DataAccess;

namespace HR.API.Services
{
    public class EmployeeCRUDService : IGenericCRUDService<EmployeeModel>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeCRUDService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository= employeeRepository;
        }
        public async Task<EmployeeModel> Create(EmployeeModel model)
        {
            var employee = new Employee
            {
                FullName = model.FullName,
                Department = model.Department,
                Email = model.Email,
                Salary= model.Salary,
            };
            var createdEmployee = await _employeeRepository.CreateEmployee(employee);
            var result = new EmployeeModel
            {
                FullName = createdEmployee.FullName,
                Department = createdEmployee.Department,
                Email = createdEmployee.Email,
                Id = createdEmployee.Id,
                Salary = createdEmployee.Salary
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _employeeRepository.DeleteEmployee(id);
        }

        public async Task<EmployeeModel> Get(int id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            var model = new EmployeeModel
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Department = employee.Department,
                Email = employee.Email,
                Salary = employee.Salary
            };
            return model;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            var result = new List<EmployeeModel>();
            var employees = await _employeeRepository.GetEmployees();
            foreach (var employee in employees) 
            {
                var model = new EmployeeModel
                {
                    FullName = employee.FullName,
                    Department = employee.Department,
                    Email = employee.Email,
                    Id = employee.Id,
                    Salary = employee.Salary
                };
                result.Add(model);
            }
            return result;
        }

        public async Task<EmployeeModel> Update(int id, EmployeeModel model)
        {
            var employee = new Employee
            {
                FullName = model.FullName,
                Department = model.Department,
                Email = model.Email,
                Id= model.Id,
                Salary = model.Salary
            };
            var updatedEmployee = await _employeeRepository.UpdateEmployee(id, employee);
            var result = new EmployeeModel
            {
                FullName = updatedEmployee.FullName,
                Department = updatedEmployee.Department,
                Email = updatedEmployee.Email,
                Id = updatedEmployee.Id,
                Salary = updatedEmployee.Salary
            };
            return result;
        }
    }
}
