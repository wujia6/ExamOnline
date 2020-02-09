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
            this.ApplicationContext = context;
            this.EntitySet = context.Set<T>();
        }

        #region EfCoreRepository成员
        public IExamDbContext ApplicationContext { get; private set; }

        public IQueryable<T> EntitySet { get; set; }

        public bool SaveAs(T entity)
        {
            ApplicationContext.Set<T>().Attach(entity);
            ApplicationContext.Entry(entity).State = EntityState.Added;
            return true;
        }
        
        public bool RemoveAt(T entity)
        {
            ApplicationContext.Set<T>().Attach(entity);
            ApplicationContext.Entry(entity).State = EntityState.Deleted;
            return true;
        }

        public bool RemoveAt(IQueryable<T> entities)
        {
            ApplicationContext.Set<T>().RemoveRange(entities);
            return true;
        }

        public bool EditTo(T entity)
        {
            ApplicationContext.Set<T>().Attach(entity);
            ApplicationContext.Entry(entity).State = EntityState.Modified;
            return true;
        }
        #endregion
    }
}
