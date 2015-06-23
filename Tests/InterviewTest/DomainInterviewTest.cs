using System;
using Domain.InterviewDomain;
using FluentAssertions;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.InterviewTest
{
    [TestClass]
    public class DomainInterviewTest
    {
        private Interview _interview;

        [TestInitialize]
        public void Setup()
        {
            _interview = ObjectMother.GetInterview();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidInterviewTest()
        {
            _interview.Should().Be(_interview);
            Validator.Validate(_interview);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidInterviewLocalTest()
        {
            Interview interview = new Interview();
            Validator.Validate(interview);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidInterviewCommentTest()
        {
            Interview interview = new Interview();
            interview.Local = "Ndd";
            Validator.Validate(interview);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidInterviewDataInterviewTest()
        {
            Interview interview = new Interview();
            interview.Local = "Ndd";
            interview.Comment = "Qualquer coisa";

            Validator.Validate(interview);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidInterviewsCandidateNullTest()
        {
            Interview interview = new Interview();
            interview.Local = "Ndd";
            interview.Comment = "Qualquer coisa";
            interview.DataInterview = DateTime.Now;

            Validator.Validate(interview);
        }
    }
}
