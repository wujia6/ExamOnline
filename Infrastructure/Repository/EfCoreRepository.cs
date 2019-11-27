using System;
using System.Linq;
using Domain.Entities;
using Domain.IComm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Repository
{
    public class EfCoreRepository<T> : IEfCoreRepository<T> where T : BaseEntity, IAggregateRoot
    {
        private readonly IQueryable<T> query;

        //构造方法
        public EfCoreRepository(IExamDbContext context)
        {
            this.DBContext = context;
            this.query = DBContext.Set<T>();
        }

        public IExamDbContext DBContext { get; private set; }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public bool InsertEntity(T entity)
        {
            DBContext.Entry(entity).State = EntityState.Added;
            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public bool RemoveEntity(T entity)
        {
            DBContext.Entry(entity).State = EntityState.Deleted;
            return true;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            DBContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        /// <summary>
        /// 查找单个
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <param name="navigatePropertys">导航属性名称</param>
        /// <returns></returns>
        public T SingleEntity(ISpecification<T> spec)
        {
            return query.FirstOrDefault(spec.Expression);
        }

        public T SingleEntity(ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            include?.Invoke(query);
            return query.FirstOrDefault(spec.Expression);
        }

        /// <summary>
        /// 查找集合
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        public IQueryable<T> QueryEntity(ISpecification<T> spec)
        {
            return query.Where(spec.Expression);
        }

        public IQueryable<T> QuerySet(ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            include?.Invoke(query);
            return query.Where(spec?.Expression);
        }
    }
}
