using System;
using System.Linq;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.IComm
{
    public interface IEfCoreRepository<T> where T : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// 数据上下文
        /// </summary>
        IExamDbContext DBContext { get; }

        /// <summary>
        /// 对象集合
        /// </summary>
        //IQueryable<T> Query { get; }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        bool InsertEntity(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        bool RemoveEntity(T entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        bool UpdateEntity(T entity);

        /// <summary>
        /// 查找单个
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        T SingleEntity(ISpecification<T> spec);

        /// <summary>
        /// 单个实体
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        T SingleEntity(ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T,object>> include = null);

        /// <summary>
        /// 查找集合
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        IQueryable<T> QueryEntity(ISpecification<T> spec);

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        IQueryable<T> QuerySet(ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
