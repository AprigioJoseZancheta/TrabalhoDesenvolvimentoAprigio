using Domain.CandidateDomain;
using System;
using Infrastructure;

namespace Domain.InterviewDomain
{
    public class Interview : IObjectValidation
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string Comment { get; set; }
        public DateTime DataInterview { get; set; }

        public int CandidateId { get; set; }
        public virtual  Candidate Candidate { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Local))
                throw new Exception("Local Inválido");
            if (string.IsNullOrEmpty(Comment))
                throw new Exception("Comentário Inválido");
            if (DataInterview > DateTime.Now)
                throw new Exception();
            if (CandidateId == 0)
            {
                throw new Exception();
            }
            throw new Exception();
        }
    }
}
