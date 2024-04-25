using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace Data.Interfaces.RepositoryInterface
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Add one entity
        /// </summary>
        /// <param name="entity"></param>
        Task AddAsync(T entity);

        Task AddAsync(List<T> entity);

        void Update(T entity, Expression<Func<T, object>>[]? properties = null);

        void Update(List<T> entities, Expression<Func<T, object>>[]? properties = null);

        void Delete(T entity);

        void Delete(List<T> entities);

        Task<long> CountAsync(Expression<Func<T, bool>>? predicate = null, Expression<Func<T, long>>? groupBy = null);

        Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null);

        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Expression<Func<T, T>>? selector = null,
            bool disableTracking = false,
            bool ignoreQueryFilters = false,
            int? skip = null,
            int? limit = null);

        Task<T> GetOneAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Expression<Func<T, T>>? selector = null,
            bool disableTracking = false,
            bool ignoreQueryFilters = false);

        IQueryable<T> Get(Expression<Func<T, bool>>? predicate = null,
           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
           Expression<Func<T, T>>? selector = null,
           bool disableTracking = false,
           bool ignoreQueryFilters = false,
           int? skip = null,
           int? limit = null);

    }
}
