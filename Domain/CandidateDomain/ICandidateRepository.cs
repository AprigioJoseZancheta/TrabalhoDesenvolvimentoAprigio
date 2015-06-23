using System.Collections.Generic;

namespace Domain.CandidateDomain
{
    public interface ICandidateRepository
    {
        Candidate Save(Candidate candidate);
        Candidate Get(int id);
        Candidate Update(Candidate candidate);
        Candidate Delete(int id);
        List<Candidate> GetAll();
    }
}
