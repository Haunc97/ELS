using ELS.Core.Entities;
using ELS.Persistence.Contexts;
using ELS.UseCase.PluginInterfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ELS.Persistence.Repositories
{
    public class StudySetRepository : BaseRepository<ELSContext, StudySet>, IStudySetRepository
    {
        public StudySetRepository(IDbContextFactory<ELSContext> dbContextFactory)
            : base(dbContextFactory)
        {
            
        }
    }
}
