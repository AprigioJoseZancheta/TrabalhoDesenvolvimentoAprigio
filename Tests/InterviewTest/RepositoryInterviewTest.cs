using Domain.InterviewDomain;
using FluentAssertions;
using Infrastructure.Data;
using Infrastructure.Data.InterviewInfra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace Tests.InterviewTest
{
    [TestClass]
    public class RepositoryInterviewTest
    {
        private IInterviewRepository _repository;
        private Interview _interview;

        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ContextDb>());
            _repository = new InterviewRepository();
            _interview = ObjectMother.GetInterview();

            using (var context = new ContextDb())
            {
                context.Interviews.Add(_interview);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void AddInterviewPersistedTest()
        {
            _repository.Save(_interview);
            _interview.Id.Should().BeGreaterThan(default(int));
        }

        [TestMethod]
        public void RetrieveInterviewPersistedTest()
        {
            Interview interview = _repository.Get(1);

            interview.Should().NotBeNull();
        }

        [TestMethod]
        public void RetrieveAllInterviewPersistedTest()
        {
            var persistedInterview = _repository.GetAll();

            persistedInterview.Count.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void UpdateInterviewPersistedTest()
        {
            Interview interview = _repository.Get(1);
            interview.Comment = "Outro comentário";

            Interview updateInterview = _repository.Update(interview);

            Interview repositoryInterview = _repository.Get(1);

            updateInterview.Should().NotBeNull();
            updateInterview.ShouldBeEquivalentTo(repositoryInterview);
        }

        [TestMethod]
        public void DeleteInterviewPersistedTest()
        {
            using (var context = new ContextDb())
            {
                var entity = context.Interviews.Find(_interview.Id);

                context.Interviews.Remove(entity);
            }
        }
    }
}
