using Domain.AddressDomain;
using Infrastructure;
using System.Collections.Generic;

namespace Application.ServiceAddress
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public Address Create(Address address)
        {
            Validator.Validate(address);

            var saveAddress = _addressRepository.Save(address);
            return saveAddress;
        }

        public Address Retrieve(int id)
        {
            return _addressRepository.Get(id);
        }

        public Address Update(Address address)
        {
            Validator.Validate(address);

            var updateAddress = _addressRepository.Update(address);
            return updateAddress;
        }

        public Address Delete(int id)
        {
            return _addressRepository.Delete(id);
        }

        public List<Address> RetrieveAll()
        {
            return _addressRepository.GetAll();
        }
    }
}
