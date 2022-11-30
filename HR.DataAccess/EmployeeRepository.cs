//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

using HR.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;
        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            var updatedEmployee = _dbContext.Employees.Attach(employee);
            updatedEmployee.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return employee;
        }
    }
}
