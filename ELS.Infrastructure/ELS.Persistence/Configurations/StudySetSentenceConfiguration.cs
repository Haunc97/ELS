using ELS.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ELS.Persistence.Configurations
{
    public class StudySetSentenceConfiguration : IEntityTypeConfiguration<StudySetSentence>
    {
        public void Configure(EntityTypeBuilder<StudySetSentence> builder)
        {
            builder.HasKey(e => new { e.StudySetId, e.SentenceId });

            builder.HasOne(e => e.Sentence)
                .WithMany(e => e.StudySetSentences)
                .HasForeignKey(e => e.SentenceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.StudySet)
                .WithMany(e => e.StudySetSentences)
                .HasForeignKey(e => e.StudySetId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
