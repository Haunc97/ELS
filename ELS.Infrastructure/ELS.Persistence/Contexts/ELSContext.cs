using ELS.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ELS.Persistence.Contexts
{
    public class ELSContext : DbContext
    {
        public ELSContext(DbContextOptions<ELSContext> options) : base(options)
        {
        }

        public DbSet<Vocabulary> Vocabularies { get; set; }
        public DbSet<StudySet> StudySets { get; set; }
        public DbSet<StudySetVocabulary> StudySetVocabularies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Load Auto-mapper profiles
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ELSContext).Assembly);
        }
    }
}