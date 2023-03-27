using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ELS.Core.Entities;

namespace ELS.Persistence.Configurations
{
    public class VocabularyConfiguration : IEntityTypeConfiguration<Vocabulary>
    {
        public void Configure(EntityTypeBuilder<Vocabulary> builder)
        {
            
        }
    }
}
