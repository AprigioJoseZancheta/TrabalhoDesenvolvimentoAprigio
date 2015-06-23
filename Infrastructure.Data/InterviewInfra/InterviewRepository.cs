using Domain.InterviewDomain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Infrastructure.Data.InterviewInfra
{
    public class InterviewRepository : IInterviewRepository
    {
        private ContextDb _context;

        public InterviewRepository()
        {
            _context = new ContextDb();
        }

        public Interview Save(Interview interview)
        {
            var newInterview = _context.Interviews.Add(interview);
            _context.SaveChanges();
            return newInterview;
        }

        public Interview Get(int id)
        {
            var interview = _context.Interviews.Find(id);
            return interview;
        }

        public Interview Update(Interview interview)
        {
            DbEntityEntry entry = _context.Entry(interview);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            return interview;
        }

        public Interview Delete(int id)
        {
            var interview = _context.Interviews.Find(id);
            DbEntityEntry entry = _context.Entry(interview);
            entry.State = EntityState.Deleted;
            _context.SaveChanges();
            return interview;
        }

        public List<Interview> GetAll()
        {
            return _context.Interviews.ToList();
        }
    }
}
