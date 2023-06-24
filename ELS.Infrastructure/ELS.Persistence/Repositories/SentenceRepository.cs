using ELS.Core.Entities;
using ELS.Persistence.Contexts;
using ELS.UseCase.PluginInterfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ELS.Persistence.Repositories
{
    public class SentenceRepository : BaseRepository<ELSContext, Sentence>, ISentenceRepository
    {
        public SentenceRepository(IDbContextFactory<ELSContext> dbContextFactory)
            : base(dbContextFactory)
        {

        }
    }
}
