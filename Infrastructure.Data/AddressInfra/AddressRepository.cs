using Domain.AddressDomain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Infrastructure.Data.AddressInfra
{
    public class AddressRepository : IAddressRepository
    {
        private ContextDb _context;

        public AddressRepository()
        {
            _context = new ContextDb();
        }

        public Address Save(Address address)
        {
            var newAddress = _context.Addresses.Add(address);
            _context.SaveChanges();
            return newAddress;
        }

        public Address Get(int id)
        {
            var address = _context.Addresses.Find(id);
            return address;
        }

        public Address Update(Address address)
        {
            DbEntityEntry entry = _context.Entry(address);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            return address;
        }

        public Address Delete(int id)
        {
            var address = _context.Addresses.Find(id);
            DbEntityEntry entry = _context.Entry(address);
            entry.State = EntityState.Deleted;
            _context.SaveChanges();
            return address;
        }

        public List<Address> GetAll()
        {
            return _context.Addresses.ToList();
        }
    }
}
