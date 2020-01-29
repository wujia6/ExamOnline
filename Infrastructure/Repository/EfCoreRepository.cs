using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.IComm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Repository
{
    public class EfCoreRepository<T> : IEfCoreRepository<T> where T : BaseEntity, IAggregateRoot
    {
        private IQueryable<T> query;

        //构造方法
        public EfCoreRepository(IExamDbContext context)
        {
            this.ApplicationContext = context;
            this.query = ApplicationContext.Set<T>();
        }

        public IExamDbContext ApplicationContext { get; private set; }

        #region Sync
        public bool SaveAs(T entity)
        {
            ApplicationContext.Set<T>().Attach(entity);
            ApplicationContext.Entry(entity).State = EntityState.Added;
            return true;
        }
        
        public bool RemoveAs(T entity)
        {
            ApplicationContext.Set<T>().Attach(entity);
            ApplicationContext.Entry(entity).State = EntityState.Deleted;
            return true;
        }
        
        public bool EditAs(T entity)
        {
            ApplicationContext.Set<T>().Attach(entity);
            ApplicationContext.Entry(entity).State = EntityState.Modified;
            return true;
        }
        
        public T Single(
            ISpecification<T> spec, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                query = include(query);
            return query.SingleOrDefault(spec.Expression);
        }
        
        public IEnumerable<T> QuerySet(
            ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                query = include(query);
            return spec == null ? query : query.Where(spec?.Expression);
        }

        public IEnumerable<T> Lists(
            out int total, 
            int? index, 
            int? size, 
            ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                query = include(query);
            if (spec != null)
            {
                var result = query.Where(spec.Expression).Skip((index.Value - 1) * size.Value).Take(size.Value);
                total = result.Count();
                return result;
            }
            else
            {
                var result = query.Skip((index.Value - 1) * size.Value).Take(size.Value);
                total = result.Count();
                return result;
            }
        }
        #endregion

        #region Async
        public async Task<T> SingleAsync(
            ISpecification<T> spec, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                query = include(query);
            return await query.SingleOrDefaultAsync(spec.Expression);
        }

        public async Task<IEnumerable<T>> QuerySetAsync(
            ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                query = include(query);
            if (spec != null)
                query = query.Where(spec.Expression);
            return await query.ToListAsync();
        }

        public async Task<object> ListsAsync(
            int? index,
            int? size,
            ISpecification<T> spec = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                query = include(query);
            if (spec != null)
                query = query.Where(spec.Expression);
            var rows = await query.Skip((index.Value - 1) * size.Value).Take(size.Value).ToListAsync();
            return new { Total = query.Count(), Rows = rows };
        }
        #endregion
    }
}
