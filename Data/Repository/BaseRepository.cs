using Application.Context;
using Domain.Entities.Core;
using Data.Interfaces.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Data.Repository
{
    public class BaseRepository<T, TDbContext> : IBaseRepository<T>
        where T : BaseEntity
        where TDbContext : DataContext
    {
        private readonly DataContext Context;

        public BaseRepository(DataContext context)
        {
            Context = context;
        }

        public virtual async Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public virtual async Task AddAsync(List<T> entity)
        {
            await Context.Set<T>().AddRangeAsync(entity);
        }

        public virtual void Update(T entity, params Expression<Func<T, object>>[]? properties)
        {
            if (properties != null)
            {
                UpdateProperties(entity, properties);
            }
            else
            {
                Context.Set<T>().Update(entity);
            }
        }

        public virtual void Update(List<T> entities, params Expression<Func<T, object>>[]? properties)
        {
            if (properties != null)
            {
                foreach (var entity in entities)
                {
                    UpdateProperties(entity, properties);
                }
            }
            else
            {
                Context.Set<T>().UpdateRange(entities);
            }
        }

        private void UpdateProperties(T entity, params Expression<Func<T, object>>[] properties)
        {
            foreach (var property in properties)
            {
                Context.Entry(entity).Property(property).IsModified = true;
            }
        }

        public virtual void Delete(T entity)
        {
            entity.DeletedAt = DateTime.Now;
            Update(entity, x => x.DeletedAt);
        }

        public virtual void Delete(List<T> entities)
        {
            entities.ForEach(x => x.DeletedAt = DateTime.Now);
            Update(entities, x => x.DeletedAt);
        }

        public virtual async Task<long> CountAsync(Expression<Func<T, bool>>? predicate = null, Expression<Func<T, long>>? groupBy = null)
        {
            if (groupBy != null)
            {
                var query = Get(predicate);
                var groupedQuery = query.GroupBy(groupBy);
                return await groupedQuery.CountAsync();
            }
            else
            {
                var query = Get(predicate);
                return await query.CountAsync();
            }
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null)
        {
            IQueryable<T> query = Context.Set<T>();
            return await query.AnyAsync(predicate);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Expression<Func<T, T>>? selector = null,
            bool disableTracking = false,
            bool ignoreQueryFilters = false,
            int? skip = null,
            int? limit = null)
        {
            var query = Get(
                predicate: predicate,
                orderBy: orderBy,
                include: include,
                selector: selector,
                disableTracking: disableTracking,
                skip: skip,
                limit: limit);

            return await query.ToListAsync();
        }

        public virtual async Task<T> GetOneAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Expression<Func<T, T>>? selector = null,
            bool disableTracking = false,
            bool ignoreQueryFilters = false)
        {
            var query = Get(
                predicate: predicate,
                orderBy: orderBy,
                include: include,
                selector: selector,
                disableTracking: disableTracking);


            return await query.FirstOrDefaultAsync();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>>? predicate = null,
           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
           Expression<Func<T, T>>? selector = null,
           bool disableTracking = false,
           bool ignoreQueryFilters = false,
           int? skip = null,
           int? limit = null)
        {
            var query = GetIQueryable(
                predicate: predicate,
                orderBy: orderBy,
                include: include,
                disableTracking: disableTracking,
                ignoreQueryFilters: ignoreQueryFilters,
                skip: skip,
                limit: limit);
            if (selector != null)
            {
                query = query.Select(selector).AsQueryable();
            }

            return query;
        }

        private IQueryable<T> GetIQueryable<T>(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool disableTracking = false,
            bool ignoreQueryFilters = false,
            int? skip = null,
            int? limit = null) where T : class
        {
            IQueryable<T> query = Context.Set<T>();

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip != null)
            {
                query = query.Skip(skip.Value);
            }

            if (limit != null)
            {
                query = query.Take(limit.Value);
            }

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }
            return query;
        }
    }
}