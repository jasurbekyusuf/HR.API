//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

using System.ComponentModel.DataAnnotations;

namespace HR.API.Models.Addresses
{
    public class AddressModel
    {
        public int Id { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string AddressLine2 { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
