using Domain.CandidateDomain;
using System.Collections.Generic;

namespace Application.ServiceCandidate
{
    public interface ICandidateService
    {
        Candidate Create(Candidate candidate);
        Candidate Retrieve(int id);
        Candidate Update(Candidate candidate);
        Candidate Delete(int id);
        List<Candidate> RetrieveAll();
    }
}
