using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ELS.Core.Entities;

namespace ELS.Persistence.Configurations
{
    public class StudySetConfiguration : IEntityTypeConfiguration<StudySet>
    {
        public void Configure(EntityTypeBuilder<StudySet> builder)
        {
            builder.Property(e => e.Title).IsRequired().HasMaxLength(256);
            builder.Property(e => e.Description).HasMaxLength(512);
        }
    }
}
