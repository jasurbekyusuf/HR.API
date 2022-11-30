//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

using HR.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.DataAccess
{
    public class SqlserverAddressRepository : IAddressRepository
    {
        private readonly AppDbContext _dbContext;
        public SqlserverAddressRepository(AppDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task<Address> CreateAddress(Address address)
        {
            await _dbContext.Addresses.AddAsync(address);
            await _dbContext.SaveChangesAsync();
            return address;
        }

        public async Task<bool> DeleteAddress(int id)
        {
            var address =await _dbContext.Addresses.FindAsync(id);
            if (address != null)
            {
                _dbContext.Addresses.Remove(address);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Address> GetAddress(int id)
        {
            return await _dbContext.Addresses.FindAsync(id);
        }

        public async Task<IEnumerable<Address>> GetAddresses()
        {
            return await _dbContext.Addresses.ToListAsync();
        }

        public async Task<Address> UpdateAddress(int id, Address address)
        {
            var updatedAddress = _dbContext.Addresses.Attach(address);
            updatedAddress.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return address;
        }
    }
}
