using Domain.AddressDomain;
using System.Collections.Generic;

namespace Application.ServiceAddress
{
    public interface IAddressService
    {
        Address Create(Address address);
        Address Retrieve(int id);
        Address Update(Address address);
        Address Delete(int id);
        List<Address> RetrieveAll();
    }
}
