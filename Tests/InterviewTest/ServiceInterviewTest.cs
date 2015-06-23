using Application.ServiceInterview;
using Domain.InterviewDomain;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.InterviewTest
{
    [TestClass]
    public class ServiceInterviewTest
    {

        private Interview _interview;
        private MockRepository _mockRepository;
        private Mock<IInterviewRepository> _interviewRepoMoq;
        private InterviewService _service;

        [TestInitialize]
        public void Setup()
        {
            _interview = ObjectMother.GetInterview();
            _mockRepository = new MockRepository(MockBehavior.Default);
            _interviewRepoMoq = _mockRepository.Create<IInterviewRepository>();
            _service = new InterviewService(_interviewRepoMoq.Object);
        }
            
        [TestMethod]
        public void CreateAInterviewTest()
        {
            _interviewRepoMoq.Setup(i => i.Save(It.IsAny<Interview>()));

            var interview = _mockRepository.Create<Interview>();

            interview.As<IObjectValidation>().Setup(i => i.Validate());

            _service.Create(interview.Object);

            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void RetrieveAInterviewTest()
        {
            _interviewRepoMoq.Setup(a => a.Get(It.IsAny<int>()));

            _service.Retrieve(1);

            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void RetrieveAllAInterviewTest()
        {
            _interviewRepoMoq.Setup(a => a.GetAll());

            _service.RetrieveAll();

            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void UpdateAInterviewTest()
        {
            _interviewRepoMoq.Setup(a => a.Update(It.IsAny<Interview>()));

            var interview = _mockRepository.Create<Interview>();

            _service.Update(interview.Object);

            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void DeleteAInterviewTest()
        {
            _interviewRepoMoq.Setup(a => a.Delete(It.IsAny<int>()));

            _service.Delete(1);

            _mockRepository.VerifyAll();
        }
    }
}
