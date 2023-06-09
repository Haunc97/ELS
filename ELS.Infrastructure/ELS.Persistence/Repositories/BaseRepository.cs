﻿using ELS.Core.Entities.Base;
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

        public virtual async Task<List<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null)
        {
            using var db = DbContextFactory.CreateDbContext();

            IQueryable<TEntity> query = GetQueryable(db, filter, orderBy, includes);

            var result = query.AsNoTracking(); 
            return await result.ToListAsync();
        }

        public virtual async Task<ListPaging<TEntity>> GetListPagingAsync(
            int PageNumber,
            int PageSize,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null)
        {
            using var db = DbContextFactory.CreateDbContext();

            IQueryable<TEntity> query = GetQueryable(db, filter, orderBy, includes);
            var dataCount = await query.CountAsync();
            var data = await query.AsNoTracking().Skip(PageSize * (PageNumber - 1)).Take(PageSize).ToListAsync();
            return new ListPaging<TEntity>()
            {
                PageNumber = PageNumber,
                PageSize = PageSize,
                Total = dataCount,
                Data = data
            };
        }

        public virtual async Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null)
        {
            using var db = DbContextFactory.CreateDbContext();

            IQueryable<TEntity> query = GetQueryable(db, filter, orderBy, includes);

            var result = query.AsNoTracking();
            return await result.FirstOrDefaultAsync();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            using var db = DbContextFactory.CreateDbContext();
            if (entity == null)
            {
                throw new InvalidOperationException("Unable to add a null entity to the repository.");
            }

            await db.Set<TEntity>().AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task AddRangeAsync(TEntity[] entities)
        {
            if (entities == null)
            {
                throw new InvalidOperationException("Unable to add a null entities to the repository.");
            }

            using var db = DbContextFactory.CreateDbContext();

            db.ChangeTracker.AutoDetectChangesEnabled = false;
            await db.Set<TEntity>().AddRangeAsync(entities);
            db.ChangeTracker.AutoDetectChangesEnabled = true;

            await db.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            using var db = DbContextFactory.CreateDbContext();
            db.Set<TEntity>().Update(entity);
            await db.SaveChangesAsync();
        }

        public virtual async Task RemoveRangeAsync(TEntity[] entities)
        {
            if (entities == null)
            {
                throw new InvalidOperationException("Unable to remove a null entities.");
            }
            using var db = DbContextFactory.CreateDbContext();
            db.Set<TEntity>().RemoveRange(entities);
            await db.SaveChangesAsync();
        }

        protected IQueryable<TEntity> GetQueryable(
            TContext db, Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null)
        {
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

            return query;
        }
    }
}
