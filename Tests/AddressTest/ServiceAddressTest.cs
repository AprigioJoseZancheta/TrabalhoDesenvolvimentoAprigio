using Application.ServiceAddress;
using Domain.AddressDomain;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.AddressTest
{
    [TestClass]
    public class ServiceAddressTest
    {
        private Address _address;
        private MockRepository _mockRepository;
        private Mock<IAddressRepository> _addressRepoMoq;
        private AddressService _service;

        [TestInitialize]
        public void Setup()
        {
            _address = ObjectMother.GetAddress();
            _mockRepository = new MockRepository(MockBehavior.Default);
            _addressRepoMoq = _mockRepository.Create<IAddressRepository>();
            _service = new AddressService(_addressRepoMoq.Object);
        }
            
        [TestMethod]
        public void CreateAAddressTest()
        {
            _addressRepoMoq.Setup(a => a.Save(It.IsAny<Address>()));

            var address = _mockRepository.Create<Address>();

            address.As<IObjectValidation>().Setup(a => a.Validate());

            _service.Create(address.Object);

            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void RetrieveAAddressTest()
        {
            _addressRepoMoq.Setup(a => a.Get(It.IsAny<int>()));

            _service.Retrieve(1);

            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void RetrieveAllAAddressTest()
        {
            _addressRepoMoq.Setup(a => a.GetAll());

            _service.RetrieveAll();

            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void UpdateAAddressTest()
        {
            _addressRepoMoq.Setup(a => a.Update(It.IsAny<Address>()));

            var address = _mockRepository.Create<Address>();

            _service.Update(address.Object);

            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void DeleteAAddressTest()
        {
            _addressRepoMoq.Setup(a => a.Delete(It.IsAny<int>()));

            _service.Delete(1);

            _mockRepository.VerifyAll();
        }
    }
}
