using System;
using Domain.AddressDomain;
using FluentAssertions;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.AddressTest
{
    [TestClass]
    public class DomainAddressTest
    {
        private Address _address;

        [TestInitialize]
        public void Setup()
        {
            _address = ObjectMother.GetAddress();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidAddressTest()
        {
            _address.Should().Be(_address);
            Validator.Validate(_address);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidAddressCityTest()
        {
            Address address = new Address();
            Validator.Validate(address);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidAddressCpTest()
        {
            Address address = new Address();
            address.City = "Lages";
            Validator.Validate(address);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidAddressNeighborhoodTest()
        {
            Address address = new Address();
            address.City = "Lages";
            address.Cp = "88509230";
            Validator.Validate(address);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidAddressStateTest()
        {
            Address address = new Address();
            address.City = "Lages";
            address.Cp = "88509230";
            address.Neighborhood = "São Cristovão";
            Validator.Validate(address);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidAddressStreetTest()
        {
            Address address = new Address();
            address.City = "Lages";
            address.Cp = "88509230";
            address.Neighborhood = "São Cristovão";
            address.State = "SC";
            Validator.Validate(address);
        }
    }
}
