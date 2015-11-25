using Domain.CandidateDomain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Infrastructure.Data.CandidateInfra
{
    public class CandidateRepository : ICandidateRepository
    {
        private ContextDb _context;

        public CandidateRepository()
        {
            _context = new ContextDb();            
        }

        public Candidate Save(Candidate candidate)
        {
            var newCandidate = _context.Candidates.Add(candidate);
            _context.SaveChanges();
            return newCandidate;
        }

        public Candidate Get(int id)
        {
            var candidate = _context.Candidates.Find(id);
            return candidate;
        }

        public Candidate Update(Candidate candidate)
        {
            DbEntityEntry entry = _context.Entry(candidate);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            return candidate;
        }

        public Candidate Delete(int id)
        {
            var candidate = _context.Candidates.Find(id);
            DbEntityEntry entry = _context.Entry(candidate);
            entry.State = EntityState.Deleted;
            _context.SaveChanges();
            return candidate;
        }

        public List<Candidate> GetAll()
        {
            return _context.Candidates.ToList();
        }
    }
}
