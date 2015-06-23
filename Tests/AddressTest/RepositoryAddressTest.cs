using Domain.AddressDomain;
using FluentAssertions;
using Infrastructure.Data;
using Infrastructure.Data.AddressInfra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace Tests.AddressTest
{
    [TestClass]
    public class RepositoryAddressTest
    {
        private IAddressRepository _repository;
        private Address _address;

        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ContextDb>());
            _repository = new AddressRepository();
            _address = ObjectMother.GetAddress();

            using (var context = new ContextDb())
            {
                context.Addresses.Add(_address);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void AddAddressPersistedTest()
        {
            _repository.Save(_address);
            _address.Id.Should().BeGreaterThan(default(int));
        }

        [TestMethod]
        public void RetrieveAddressPersistedTest()
        {
            Address address = _repository.Get(1);

            address.Should().NotBeNull();
        }

        [TestMethod]
        public void RetrieveAllAddressPersistedTest()
        {
            var persistedAddress = _repository.GetAll();

            persistedAddress.Count.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void UpdateAddressPersistedTest()
        {
            Address address = _repository.Get(1);
            address.State = "PR";

            Address updateAddress = _repository.Update(address);

            Address repositoryAddress = _repository.Get(1);

            updateAddress.Should().NotBeNull();
            updateAddress.ShouldBeEquivalentTo(repositoryAddress);
        }

        [TestMethod]
        public void DeleteAddressPersistedTest()
        {
            using (var context = new ContextDb())
            {
                var entity = context.Addresses.Find(_address.Id);

                context.Addresses.Remove(entity);
            }
        }
    }
}
