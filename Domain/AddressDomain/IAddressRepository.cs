using System.Collections.Generic;

namespace Domain.AddressDomain
{
    public interface IAddressRepository
    {
        Address Save(Address address);
        Address Get(int id);
        Address Update(Address address);
        Address Delete(int id);
        List<Address> GetAll();
    }
}
