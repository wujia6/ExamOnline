using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
        /// 添加
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        bool AddAt(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        bool RemoveAt(T entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        bool ModifyAt(T entity);

        /// <summary>
        /// 单个实体
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        T Single(ISpecification<T> spec,
            Func<IQueryable<T>, IIncludableQueryable<T,object>> include = null);

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        IEnumerable<T> Lists(ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
