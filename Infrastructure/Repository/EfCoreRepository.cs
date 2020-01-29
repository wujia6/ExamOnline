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
        private IQueryable<T> querys;

        //构造方法
        public EfCoreRepository(IExamDbContext context)
        {
            this.ApplicationContext = context;
            this.querys = ApplicationContext.Set<T>();
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
        
        public T GetEntity(
            ISpecification<T> spec, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                querys = include(querys);
            return querys.FirstOrDefault(spec.Expression);
        }
        
        public IEnumerable<T> GetEntities(
            ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                querys = include(querys);
            if (spec != null)
                querys = querys.Where(spec.Expression);
            return querys;
        }

        public IEnumerable<T> Lists(
            out int total, 
            int? index, 
            int? size, 
            ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                querys = include(querys);
            if (spec != null)
                querys = querys.Where(spec.Expression);
            var result = querys.Skip((index.Value - 1) * size.Value).Take(size.Value);
            total = querys.Count();
            return result;
        }
        #endregion

        #region Async
        public async Task<T> GetEntityAsync(
            ISpecification<T> spec, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                querys = include(querys);
            return await querys.FirstOrDefaultAsync(spec.Expression);
        }

        public async Task<IEnumerable<T>> GetEntitiesAsync(
            ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                querys = include(querys);
            if (spec != null)
                querys = await  querys.WhereAsync(spec.Expression);
            return querys;
        }

        public async Task<object> PageListAsync(
            int? index,
            int? size,
            ISpecification<T> spec = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                querys = include(querys);
            if (spec != null)
                querys = await querys.WhereAsync(spec.Expression);
            var rows = querys.Skip((index.Value - 1) * size.Value).Take(size.Value);
            return new { Total = querys.Count(), Rows = rows.AsEnumerable() };
        }
        #endregion
    }
}
