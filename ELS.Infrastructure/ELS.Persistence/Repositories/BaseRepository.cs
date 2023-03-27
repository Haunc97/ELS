using ELS.Core.Entities.Base;
using ELS.UseCase.PluginInterfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ELS.Persistence.Repositories
{
    public abstract class BaseRepository<TContext, TEntity> : IBaseRepository<TEntity>
        where TEntity : Entity where TContext : DbContext
    {
        protected IDbContextFactory<TContext> DbContextFactory { get; private set; }

        public BaseRepository(IDbContextFactory<TContext> dbContextFactory)
        {
            DbContextFactory = dbContextFactory;
        }

        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null)
        {
            using var db = DbContextFactory.CreateDbContext();
            DbSet<TEntity> dbSet = db.Set<TEntity>();
            IQueryable<TEntity> query;

            query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != null)
            {
                query = includes(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            var result = query.AsNoTracking();
            return await result.ToListAsync();
        }

        public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null)
        {
            var result = QueryDb(filter, orderBy, includes);
            return await result.FirstOrDefaultAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            using var db = DbContextFactory.CreateDbContext();
            if (entity == null)
            {
                throw new InvalidOperationException("Unable to add a null entity to the repository.");
            }

            await db.Set<TEntity>().AddAsync(entity);
            await db.SaveChangesAsync();
        }

        #region protected
        protected virtual IQueryable<TEntity> GetQueryable()
        {
            using var db = DbContextFactory.CreateDbContext();
            DbSet<TEntity> dbSet = db.Set<TEntity>();
            IQueryable<TEntity> query;

            query = dbSet;

            return query;
        }

        protected virtual IQueryable<TEntity> QueryDb(Expression<Func<TEntity, bool>>? filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes)
        {
            IQueryable<TEntity> query = GetQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != null)
            {
                query = includes(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }
        #endregion
    }
}
