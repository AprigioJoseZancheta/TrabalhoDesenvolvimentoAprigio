using System;
using Domain.AddressDomain;
using Domain.CandidateDomain;
using FluentAssertions;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.CandidateTest
{
    [TestClass]
    public class DomainCandidateTest
    {
        private Candidate _candidate;

        [TestInitialize]
        public void Setup()
        {
            _candidate = ObjectMother.GetCandidate();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidCandidateTest()
        {
            _candidate.Should().Be(_candidate);
            Validator.Validate(_candidate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidCandidateNameTest()
        {
            Candidate candidate = new Candidate();
            Validator.Validate(candidate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidCandidateCpfTest()
        {
            Candidate candidate = new Candidate();
            candidate.Name = "Aprigio";
            Validator.Validate(candidate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidCandidatePhoneTest()
        {
            Candidate candidate = new Candidate();
            candidate.Name = "Aprigio";
            candidate.Cpf = "033.155.867-87";

            Validator.Validate(candidate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidCandidateAddressNullTest()
        {
            Candidate candidate = new Candidate();
            candidate.Name = "Aprigio";
            candidate.Cpf = "033.155.867-87";
            candidate.Phone = "88336569";
         
            Validator.Validate(candidate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidCandidateInterviewsNullTest()
        {
            Candidate candidate = new Candidate();
            candidate.Name = "Aprigio";
            candidate.Cpf = "033.155.867-87";
            candidate.Phone = "88336569";
            Validator.Validate(candidate);
        }
    }
}
