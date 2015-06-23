using System.Collections.Generic;

namespace Domain.InterviewDomain
{
    public interface IInterviewRepository
    {
        Interview Save(Interview interview);
        Interview Get(int id);
        Interview Update(Interview interview);
        Interview Delete(int id);
        List<Interview> GetAll();
    }
}
