//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

using System.ComponentModel.DataAnnotations;

namespace HR.API.Models.Employees
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FullName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Department { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public int AddressId { get; set; }
        public string AccountNumber { get; set; }
    }
}
