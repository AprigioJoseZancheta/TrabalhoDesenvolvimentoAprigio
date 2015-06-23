using Domain.AddressDomain;
using Domain.CandidateDomain;
using Domain.InterviewDomain;
using System.Data.Entity;

namespace Infrastructure.Data
{
    public class ContextDb : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Interview> Interviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().ToTable("TBCandidate");
            modelBuilder.Entity<Candidate>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Address>().ToTable("TBAddress");
            modelBuilder.Entity<Interview>().ToTable("TBInterview");
            modelBuilder.Entity<Interview>()
                .Property(i => i.Comment)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
