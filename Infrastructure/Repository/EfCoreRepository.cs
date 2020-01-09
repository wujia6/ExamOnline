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
        public bool AddAt(T entity)
        {
            DBContext.Entry(entity).State = EntityState.Added;
            return true;
        }
        
        public bool RemoveAt(T entity)
        {
            DBContext.Entry(entity).State = EntityState.Deleted;
            return true;
        }
        
        public bool ModifyAt(T entity)
        {
            DBContext.Entry(entity).State = EntityState.Modified;
            return true;
        }
        
        public T Single(ISpecification<T> spec, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                query = include(query);
            return query.FirstOrDefault(spec.Expression);
        }
        
        public IEnumerable<T> Lists(ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                query = include(query);
            return spec == null ? query : query.Where(spec?.Expression);
        }

        public IEnumerable<T> Lists(out int total, int? pageIndex = 0, int? pageSize = 10, 
            ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                query = include(query);
            if (spec != null)
            {
                var result = query.Where(spec.Expression).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value);
                total = result.Count();
                return result;
            }
            else
            {
                var result = query.Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value);
                total = result.Count();
                return result;
            }
        }
        #endregion

        #region Async
        public async Task<bool> AddAsync(T entity)
        {
            return await Task.Run(() => this.AddAt(entity));
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            return await Task.Run(() => this.RemoveAt(entity));
        }

        public async Task<bool> ModifyAsync(T entity)
        {
            return await Task.Run(() => this.ModifyAt(entity));
        }

        public async Task<T> SingleAsync(ISpecification<T> spec, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return await Task.Run(() => this.Single(spec, include));
        }

        public async Task<IEnumerable<T>> ListsAsync(ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return await Task.Run(() => this.Lists(spec, include));
        }
        
        #endregion
    }
}
