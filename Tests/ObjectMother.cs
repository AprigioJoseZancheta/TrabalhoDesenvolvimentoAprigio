using Domain.AddressDomain;
using Domain.CandidateDomain;
using Domain.InterviewDomain;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ObjectMother
    {
        public static Candidate GetCandidate()
        {
            Candidate candidate = new Candidate();
            candidate.Name = "Aprigio";
            candidate.Cpf = "033.155.867-87";
            candidate.Phone = "88336569";
            candidate.Interviews = new List<Interview>()
            {
                new Interview()
                {
                    Comment = "Qualquer coisa",
                    DataInterview = DateTime.Now,
                    Local = "Ndd"
                }
            };
            return candidate;
        }

        public static Address GetAddress()
        {
            Address address = new Address();
            address.City = "Lages";
            address.Cp = "88509230";
            address.Neighborhood = "São Cristovão";
            address.State = "SC";
            address.Street = "Rio de Janeiro";
            address.Candidate = new Candidate()
            {
                Name = "Aprigio"
            };
            return address;
        }

        public static Interview GetInterview()
        {
            Interview interview = new Interview();
            interview.Local = "Ndd";
            interview.Comment = "Qualquer coisa";
            interview.DataInterview = DateTime.Now;
            interview.Candidate = new Candidate()
            {
                Name = "Aprigio"
                
            };
            return interview;
        }
    }
}
