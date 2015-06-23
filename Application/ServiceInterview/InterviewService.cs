using Domain.InterviewDomain;
using Infrastructure;
using System.Collections.Generic;

namespace Application.ServiceInterview
{
    public class InterviewService : IInterviewService
    {
        private IInterviewRepository _interviewRepository;

        public InterviewService(IInterviewRepository interviewRepository)
        {
            _interviewRepository = interviewRepository;
        }

        public Interview Create(Interview interview)
        {
            Validator.Validate(interview);

            var saveInterview = _interviewRepository.Save(interview);
            return saveInterview;
        }

        public Interview Retrieve(int id)
        {
            return _interviewRepository.Get(id);
        }

        public Interview Update(Interview interview)
        {
            Validator.Validate(interview);

            var updateInterview = _interviewRepository.Update(interview);
            return updateInterview;
        }

        public Interview Delete(int id)
        {
            return _interviewRepository.Delete(id);
        }

        public List<Interview> RetrieveAll()
        {
            return _interviewRepository.GetAll();
        }
    }
}
