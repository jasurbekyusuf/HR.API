//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

using HR.DataAccess.Entities;

namespace HR.DataAccess
{
    public interface IAddressRepository
    {
        public Task<Address> CreateAddress(Address address);
        Task<IEnumerable<Address>> GetAddresses();
        Task<Address> GetAddress(int id);
        Task<Address> UpdateAddress(int id, Address address);
        Task<bool> DeleteAddress(int id);
    }
}