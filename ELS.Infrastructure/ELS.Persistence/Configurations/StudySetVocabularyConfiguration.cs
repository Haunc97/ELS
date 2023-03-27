using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ELS.Core.Entities;

namespace ELS.Persistence.Configurations
{
    public class StudySetVocabularyConfiguration : IEntityTypeConfiguration<StudySetVocabulary>
    {
        public void Configure(EntityTypeBuilder<StudySetVocabulary> builder)
        {
            builder.HasKey(e => new { e.StudySetId, e.VocabularyId });

            builder.HasOne(e => e.Vocabulary)
                .WithMany(e => e.StudySetVocabularies)
                .HasForeignKey(e => e.VocabularyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.StudySet)
                .WithMany(e => e.StudySetVocabularies)
                .HasForeignKey(e => e.StudySetId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}