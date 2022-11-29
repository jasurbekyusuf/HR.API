//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

using HR.API.Models;

namespace HR.DataAccess
{
    public interface IEmployeeRepository
    {
        public Task<EmployeeModel> CreateEmployee(EmployeeModel employee);
        Task<IEnumerable<EmployeeModel>> GetEmployees();
        Task<EmployeeModel> GetEmployee(int id);
        Task<EmployeeModel> UpdateEmployee(int id, EmployeeModel employee);
        Task<bool> DeleteEmployee(int id);
    }
}