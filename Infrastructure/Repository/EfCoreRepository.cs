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
            this.DBContext = context;
            this.query = DBContext.Set<T>();
        }

        public IExamDbContext DBContext { get; private set; }

        #region Sync
        public bool SaveAs(T entity)
        {
            DBContext.Entry(entity).State = EntityState.Added;
            return true;
        }
        
        public bool RemoveAs(T entity)
        {
            DBContext.Entry(entity).State = EntityState.Deleted;
            return true;
        }
        
        public bool EditAs(T entity)
        {
            DBContext.Entry(entity).State = EntityState.Modified;
            return true;
        }
        
        public T Single(ISpecification<T> spec, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                query = include(query);
            return query.FirstOrDefault(spec.Expression);
        }
        
        public IEnumerable<T> QuerySet(ISpecification<T> spec = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
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
        public async Task<bool> SaveAsync(T entity)
        {
            return await Task.Run(() => this.SaveAs(entity));
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            return await Task.Run(() => this.RemoveAs(entity));
        }

        public async Task<bool> EditAsync(T entity)
        {
            return await Task.Run(() => this.EditAs(entity));
        }

        public async Task<T> SingleAsync(ISpecification<T> spec, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return await Task.Run(() => this.Single(spec, include));
        }

        public async Task<IEnumerable<T>> QuerySetAsync(ISpecification<T> spec = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return await Task.Run(() => this.QuerySet(spec, include));
        }

        public async Task<PageResult> ListsAsync(
            int? index,
            int? size,
            ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return await Task.Run(() => new PageResult
            {
                Rows = this.Lists(out int total, index, size, spec, include),
                Total = total
            });
        }
        #endregion
    }
}
