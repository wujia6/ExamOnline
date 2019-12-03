using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using Domain.Entities;
using Domain.IComm;
using Domain.IManages;
using System.Collections.Generic;

namespace Domain.Manages
{
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
            return entity.ID > 0 ? efCore.AddAt(entity) : efCore.ModifyAt(entity);
        }

        public bool Remove(ISpecification<T> spec)
        {
            var entity = Single(spec);
            return entity == null ? false : efCore.RemoveAt(entity);
        }

        public T Single(ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return efCore.Single(spec);
        }

        public IEnumerable<T> Lists(ISpecification<T> spec = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return efCore.Lists(spec, include);
        }
    }
}
