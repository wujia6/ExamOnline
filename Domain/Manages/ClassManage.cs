using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using Domain.Entities;
using Domain.IComm;
using Domain.IManages;
using System.Collections.Generic;
using Domain.Entities.ClassAgg;

namespace Domain.Manages
{
    /// <summary>
    /// 班级领域服务实现类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ClassManage<T> : IClassManage<T> where T : BaseEntity, IAggregateRoot
    {
        private readonly IEfCoreRepository<T> efCore;

        public ClassManage(IEfCoreRepository<T> ef)
        {
            this.efCore = ef;
        }

        public bool AddOrEdit(T entity)
        {
            if (entity == null)
                return false;
            return entity.ID > 0 ? efCore.SaveAs(entity) : efCore.EditAs(entity);
        }

        public bool Remove(ISpecification<T> spec)
        {
            var entity = Single(spec);
            return entity == null ? false : efCore.RemoveAs(entity);
        }

        public T Single(ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return efCore.Single(spec);
        }

        public IEnumerable<T> Lists(ISpecification<T> spec = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return efCore.QuerySet(spec, include);
        }
    }

    public class ClassManage : IClassManage
    {
        private readonly IEfCoreRepository<ClassInfo> efCore;

        public ClassManage(IEfCoreRepository<ClassInfo> ef)
        {
            this.efCore = ef;
        }

        public bool AddOrEdit<T>(T entity) where T : BaseEntity
        {
            if (entity == null)
                return false;
            var entitySet = efCore.DBContext.Set<T>();
            return (entity.ID > 0 ? entitySet.Update(entity) : entitySet.Add(entity)) != null;
        }

        public IEnumerable<T> Lists<T>(ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null) where T : BaseEntity
        {
            IQueryable<T> query = efCore.DBContext.Set<T>();
            if (include!=null)
                query = include(query);
            return query.Where(spec.Expression);
        }

        public bool Remove<T>(ISpecification<T> spec) where T : BaseEntity
        {
            var entity = Single(spec);
            return entity == null ? false : efCore.DBContext.Set<T>().Remove(entity) != null;
        }

        public T Single<T>(ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null) where T : BaseEntity
        {
            return include?.Invoke(efCore.DBContext.Set<T>()).FirstOrDefault(spec.Expression);
        }
    }
}
