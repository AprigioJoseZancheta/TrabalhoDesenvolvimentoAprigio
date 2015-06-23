using Domain.InterviewDomain;
using System.Collections.Generic;

namespace Application.ServiceInterview
{
    public interface IInterviewService
    {
        Interview Create(Interview interview);
        Interview Retrieve(int id);
        Interview Update(Interview interview);
        Interview Delete(int id);
        List<Interview> RetrieveAll();
    }
}
