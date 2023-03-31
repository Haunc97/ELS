using ELS.Core.Entities;
using ELS.Persistence.Contexts;
using ELS.UseCase.PluginInterfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ELS.Persistence.Repositories
{
    public class StudySetVocabularyRepository : BaseRepository<ELSContext, StudySetVocabulary>, IStudySetVocabularyRepository
    {
        public StudySetVocabularyRepository(IDbContextFactory<ELSContext> dbContextFactory)
            : base(dbContextFactory)
        {
        }
    }
}