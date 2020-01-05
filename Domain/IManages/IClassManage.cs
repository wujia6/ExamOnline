using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.IComm;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.IManages
{
    /// <summary>
    /// 领域服务班级接口
    /// </summary>
    public interface IClassManage<T> where T : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// 插入或更新
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool AddOrEdit(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        bool Remove(ISpecification<T> spec);

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        T Single(ISpecification<T> spec = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        IEnumerable<T> Lists(ISpecification<T> spec = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }

    public interface IClassManage
    {
        /// <summary>
        /// 插入或更新
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool AddOrEdit<T>(T entity) where T : BaseEntity;

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        bool Remove<T>(ISpecification<T> spec) where T : BaseEntity;

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        T Single<T>(ISpecification<T> spec = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null) where T : BaseEntity;

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        IEnumerable<T> Lists<T>(ISpecification<T> spec = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null) where T : BaseEntity;
    }
}
