using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public bool AddAt(T entity)
        {
            DBContext.Entry(entity).State = EntityState.Added;
            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public bool RemoveAt(T entity)
        {
            DBContext.Entry(entity).State = EntityState.Deleted;
            return true;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public bool ModifyAt(T entity)
        {
            DBContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        /// <summary>
        /// 查找单个
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <param name="include">要包含的导航属性</param>
        /// <returns></returns>
        public T Single(ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                query = include(query);
            return query.FirstOrDefault(spec.Expression);
        }

        /// <summary>
        /// 查找集合
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <param name="include">要包含的导航属性</param>
        /// <returns></returns>
        public IEnumerable<T> Lists(ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
                query = include(query);
            return query.Where(spec?.Expression);
        }
    }
}
