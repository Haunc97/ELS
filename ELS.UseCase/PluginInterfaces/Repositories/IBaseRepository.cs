using ELS.Core.Entities.Base;
using System.Linq.Expressions;

namespace ELS.UseCase.PluginInterfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Get the list of entities as no tracking.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null);

        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null);

        Task AddAsync(TEntity entity);
    }
}