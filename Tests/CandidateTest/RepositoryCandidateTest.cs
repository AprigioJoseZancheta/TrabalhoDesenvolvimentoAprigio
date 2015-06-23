using Domain.CandidateDomain;
using FluentAssertions;
using Infrastructure.Data;
using Infrastructure.Data.CandidateInfra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace Tests.CandidateTest
{
    [TestClass]
    public class RepositoryCandidateTest
    {
        private ICandidateRepository _repository;
        private Candidate _candidate;

        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ContextDb>());
            _repository = new CandidateRepository();
            _candidate = ObjectMother.GetCandidate();

            using (var context = new ContextDb())
            {
                context.Candidates.Add(_candidate);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void AddCandidatePersistedTest()
        {
            _repository.Save(_candidate);
            _candidate.Id.Should().BeGreaterThan(default(int));
        }

        [TestMethod]
        public void RetrieveCandidatePersistedTest()
        {
            Candidate candidate = _repository.Get(1);

            candidate.Should().NotBeNull();
        }

        [TestMethod]
        public void RetrieveAllCandidatePersistedTest()
        {
            var persistedCandidate = _repository.GetAll();

            persistedCandidate.Count.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void UpdateCandidatePersistedTest()
        {
            Candidate candidate = _repository.Get(1);
            candidate.Name = "João";

            Candidate updateCandidate = _repository.Update(candidate);

            Candidate repositoryCandidate = _repository.Get(1);

            updateCandidate.Should().NotBeNull();
            updateCandidate.ShouldBeEquivalentTo(repositoryCandidate);
        }

        [TestMethod]
        public void DeleteCandidatePersistedTest()
        {
            using (var context = new ContextDb())
            {
                var entity = context.Candidates.Find(_candidate.Id);

                context.Candidates.Remove(entity);
            }
        } 
    }
}
