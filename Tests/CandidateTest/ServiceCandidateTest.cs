using Application.ServiceCandidate;
using Domain.CandidateDomain;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.CandidateTest
{
    [TestClass]
    public class ServiceCandidateTest
    {
        private Candidate _candidate;
        private MockRepository _mockRepository;
        private Mock<ICandidateRepository> _candidateRepoMock;
        private CandidateService _service;

        [TestInitialize]
        public void Setup()
        {
            _candidate = ObjectMother.GetCandidate();
            _mockRepository = new MockRepository(MockBehavior.Default);
            _candidateRepoMock = _mockRepository.Create<ICandidateRepository>();
            _service = new CandidateService(_candidateRepoMock.Object);
        }
            
        [TestMethod]
        public void CreateACandidateTest()
        {
            _candidateRepoMock.Setup(c => c.Save(It.IsAny<Candidate>()));

            var candidate = _mockRepository.Create<Candidate>();

            candidate.As<IObjectValidation>().Setup(c => c.Validate());

            _service.Create(candidate.Object);

            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void RetrieveACandidateTest()
        {
            _candidateRepoMock.Setup(c => c.Get(It.IsAny<int>()));

            _service.Retrieve(1);

            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void RetrieveAllACandidateTest()
        {
            _candidateRepoMock.Setup(a => a.GetAll());

            _service.RetrieveAll();

            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void UpdateACandidateTest()
        {
            _candidateRepoMock.Setup(c => c.Update(It.IsAny<Candidate>()));

            var candidate = _mockRepository.Create<Candidate>();

            _service.Update(candidate.Object);

            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void DeleteACandidateTest()
        {
            _candidateRepoMock.Setup(c => c.Delete(It.IsAny<int>()));

            _service.Delete(1);

            _mockRepository.VerifyAll();
        }
    }
}
