using Domain.CandidateDomain;
using Infrastructure;
using System.Collections.Generic;

namespace Application.ServiceCandidate
{
    public class CandidateService : ICandidateService
    {
        private ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public Candidate Create(Candidate candidate)
        {
            Validator.Validate(candidate);

            var saveCandidate = _candidateRepository.Save(candidate);
            return saveCandidate;
        }

        public Candidate Retrieve(int id)
        {
            return _candidateRepository.Get(id);
        }

        public Candidate Update(Candidate candidate)
        {
            Validator.Validate(candidate);

            var updateCandidate = _candidateRepository.Update(candidate);
            return updateCandidate;
        }

        public Candidate Delete(int id)
        {
            return _candidateRepository.Delete(id);
        }

        public List<Candidate> RetrieveAll()
        {
            return _candidateRepository.GetAll();
        }
    }
}
