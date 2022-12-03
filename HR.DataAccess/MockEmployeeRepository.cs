//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

using System.Collections.Concurrent;
using HR.DataAccess.Employees;
using HR.DataAccess.Entities;

namespace HR.API
{
    public  class SqlserverEmployeeRepository : IEmployeeRepository
    {
        private static ConcurrentDictionary<int, Employee> _employees = new ConcurrentDictionary<int, Employee>();
        private static object locker = new ();

        public SqlserverEmployeeRepository()
        {
            Init();
        }

        private void Init()
        {
            _employees.TryAdd(1, new Employee { Id = 1, FullName = "John Doe", Department = "IT", Email = "jon@nt.com" });
            _employees.TryAdd(2, new Employee { Id = 2, FullName = "Alice Smmith", Department = "Accounting", Email = "Alice@nt.com" });
            _employees.TryAdd(3, new Employee { Id = 3, FullName = "Bill Hamilton", Department = "HR", Email = "Bill@nt.com" });
            _employees.TryAdd(4, new Employee { Id = 4, FullName = "Warren James", Department = "Marketing", Email = "Warrent@nt.com" });
            _employees.TryAdd(5, new Employee { Id = 5, FullName = "Peter Kent", Department = "Management", Email = "Petter@nt.com" });
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            int newId = 0;
            lock (locker)
            {
                newId = _employees.Keys.Max() + 1;
            }
            employee.Id = newId;
            _employees.TryAdd(newId, employee);
            return await Task.FromResult(employee);
        }

        public  async Task<IEnumerable<Employee>> GetEmployees()=>
            await Task.FromResult(_employees.Values);

        public  async Task<Employee> GetEmployee(int id) =>
            await Task.FromResult(_employees[id]);

        public async Task<Employee> UpdateEmployee(int id, Employee employee)=>
            await Task.FromResult(_employees[id]= _employees[id] = employee);

        public  Task<bool> DeleteEmployee(int id)
        {
            if (_employees.ContainsKey(id))
            {
                _employees.TryRemove(id, out _);
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}
