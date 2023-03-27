using ELS.Core.Entities;
using ELS.Persistence.Contexts;
using ELS.UseCase.PluginInterfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ELS.Persistence.Repositories
{
    public class VocabularyRepository : BaseRepository<ELSContext, Vocabulary>, IVocabularyRepository
    {
        public VocabularyRepository(IDbContextFactory<ELSContext> dbContextFactory)
            : base(dbContextFactory)
        {
            
        }
    }
}
