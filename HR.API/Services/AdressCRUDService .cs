//===================================================
// Copyright (c)  coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Pease
//===================================================

using HR.API.Models;
using HR.DataAccess;
using HR.DataAccess.Entities;

namespace HR.API.Services
{
    public class AddressCRUDService : IGenericCRUDService<AddressModel>
    {
        private readonly IAddressRepository _addressRepository;
        public AddressCRUDService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<AddressModel> Create(AddressModel model)
        {
            var address = new Address
            {
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                PostalCode = model.PostalCode,
                Country = model.Country,
                City = model.City
            };
            var createdAddress = await _addressRepository.CreateAddress(address);
            var result = new AddressModel
            {
                AddressLine1 = createdAddress.AddressLine1,
                AddressLine2 = createdAddress.AddressLine2,
                PostalCode = createdAddress.PostalCode,
                Country = createdAddress.Country,
                City = createdAddress.City,
                Id = createdAddress.Id
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _addressRepository.DeleteAddress(id);
        }

        public async Task<AddressModel> Get(int id)
        {
            var address = await _addressRepository.GetAddress(id);
            var model = new AddressModel
            {
                Id = address.Id,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                PostalCode = address.PostalCode,
                Country = address.Country,
                City = address.City
            };
            return model;
        }

        public async Task<IEnumerable<AddressModel>> GetAll()
        {
            var result = new List<AddressModel>();
            var addresses = await _addressRepository.GetAddresses();
            foreach (var address in addresses)
            {
                var model = new AddressModel
                {
                    Id = address.Id,
                    AddressLine1 = address.AddressLine1,
                    AddressLine2 = address.AddressLine2,
                    PostalCode = address.PostalCode,
                    Country = address.Country,
                    City = address.City
                };
                result.Add(model);
            }
            return result;
        }

        public async Task<AddressModel> Update(int id, AddressModel model)
        {
            var address = new Address
            {
                Id = model.Id,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                PostalCode = model.PostalCode,
                Country = model.Country,
                City = model.City
            };
            var updatedAddress = await _addressRepository.UpdateAddress(id, address);
            var result = new AddressModel
            {
                Id = address.Id,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                PostalCode = address.PostalCode,
                Country = address.Country,
                City = address.City
            };
            return result;
        }
    }
}
