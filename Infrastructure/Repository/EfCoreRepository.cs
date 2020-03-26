using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.IComm;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EfCoreRepository<T> : IEfCoreRepository<T> where T : BaseEntity, IAggregateRoot
    {
        //构造方法
        public EfCoreRepository(IExamDbContext context)
        {
            this.ApplicationContext = context ?? throw new ArgumentNullException(nameof(context));
            this.EntitySet = context.Set<T>();
        }

        #region EfCoreRepository成员
        public IExamDbContext ApplicationContext { get; private set; }

        public IQueryable<T> EntitySet { get; set; }

        public bool SaveAs(T entity)
        {
            try
            {
                ApplicationContext.Set<T>().Attach(entity);
                ApplicationContext.Entry(entity).State = EntityState.Added;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public bool RemoveAt(T entity)
        {
            try
            {
                ApplicationContext.Set<T>().Attach(entity);
                ApplicationContext.Entry(entity).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveAt(IQueryable<T> entities)
        {
            try
            {
                ApplicationContext.Set<T>().AttachRange(entities);
                ApplicationContext.Entry(entities).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditTo(T entity)
        {
            try
            {
                ApplicationContext.Set<T>().Attach(entity);
                ApplicationContext.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        #endregion
    }
}
