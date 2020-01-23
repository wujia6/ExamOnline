using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.IComm
{
    /// <summary>
    /// 仓储总接口-泛型
    /// </summary>
    /// <typeparam name="T">泛型类型</typeparam>
    public interface IEfCoreRepository<T> where T : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// 数据上下文
        /// </summary>
        IExamDbContext DBContext { get; }

        #region 同步
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        bool SaveAs(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        bool RemoveAs(T entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        bool EditAs(T entity);

        /// <summary>
        /// 单个实体
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        T Single(ISpecification<T> spec, Func<IQueryable<T>, IIncludableQueryable<T,object>> include = null);

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        IEnumerable<T> QuerySet(ISpecification<T> spec = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <param name="total">分页记录总数</param>
        /// <param name="index">当前页码</param>
        /// <param name="size">每页记录显示条数</param>
        /// <param name="spec">规约表达式</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        IEnumerable<T> Lists(
            out int total,
            int? index,
            int? size,
            ISpecification<T> spec = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        #endregion

        #region 异步
        /// <summary>
        /// 添加（异步）
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        Task<bool> SaveAsync(T entity);

        /// <summary>
        /// 删除（异步）
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        Task<bool> RemoveAsync(T entity);

        /// <summary>
        /// 修改（异步）
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        Task<bool> EditAsync(T entity);

        /// <summary>
        /// 单个实体（异步）
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        Task<T> SingleAsync(ISpecification<T> spec, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        /// <summary>
        /// 获取实体集合（异步）
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        Task<IEnumerable<T>> QuerySetAsync(ISpecification<T> spec = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        /// <summary>
        /// 获取实体集合（异步）
        /// </summary>
        /// <param name="index">当前页码</param>
        /// <param name="size">页面显示记录数</param>
        /// <param name="spec">规约表达式</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        Task<PageResult> ListsAsync(
            int? index,
            int? size,
            ISpecification<T> spec = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        #endregion
    }
}
