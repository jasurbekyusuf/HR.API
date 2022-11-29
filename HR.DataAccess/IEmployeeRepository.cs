//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

namespace HR.DataAccess
{
    public interface IEmployeeRepository
    {
        public Task<Employee> CreateEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> UpdateEmployee(int id, Employee employee);
        Task<bool> DeleteEmployee(int id);
    }
}