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

        Task<ListPaging<TEntity>> GetListPagingAsync(
            int PageNumber,
            int PageSize,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null);

        /// <summary>
        /// Get entity as no tracking.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// To add new entities to database context
        /// </summary>
        /// <param name="entities">Array of entity to add</param>
        /// <returns>Task</returns>
        Task AddRangeAsync(TEntity[] entities);

        /// <summary>
        /// To update entities in database context
        /// </summary>
        /// <param name="entities"></param>
        Task RemoveRangeAsync(TEntity[] entities);
    }

    public class ListPaging<T> where T : Entity
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public int PageTotal => ((Total - 1) / PageSize) + 1;
        public List<T> Data { get; set; }
    }
}