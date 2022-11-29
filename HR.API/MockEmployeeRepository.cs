//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

using System.Collections.Concurrent;
using HR.API.Models;

namespace HR.API
{
    public static class MockEmployeeRepository
    {
        private static ConcurrentDictionary<int, Employee> _employees = new ConcurrentDictionary<int, Employee>();
        private static object locker = new ();
        public static void Init()
        {
            _employees.TryAdd(1, new Employee { Id = 1, FullName = "John Doe", Department = "IT", Email = "jon@nt.com" });
            _employees.TryAdd(2, new Employee { Id = 2, FullName = "Alice Smmith", Department = "Accounting", Email = "Alice@nt.com" });
            _employees.TryAdd(3, new Employee { Id = 3, FullName = "Bill Hamilton", Department = "HR", Email = "Bill@nt.com" });
            _employees.TryAdd(4, new Employee { Id = 4, FullName = "Warren James", Department = "Marketing", Email = "Warrent@nt.com" });
            _employees.TryAdd(5, new Employee { Id = 5, FullName = "Peter Kent", Department = "Management", Email = "Petter@nt.com" });
        }

        public static async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await Task.FromResult(_employees.Values);
        }

        public static async Task<Employee> GetEmployee(int id) 
        {
            return await Task.FromResult(_employees[id]);
        }

        public static Task<Employee> CreateEmployee(Employee employee)
        {
            int newId = 0;
            lock (locker)
            {
                newId = _employees.Keys.Max() + 1;
            }
            employee.Id = newId;
            _employees.TryAdd(newId, employee);
            return Task.FromResult(employee);
        }
    }
}
