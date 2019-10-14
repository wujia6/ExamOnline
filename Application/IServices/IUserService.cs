﻿using System.Linq;
using Domain.Entities.UserAgg;
using Domain.IComm;

namespace Application.IServices
{
    /// <summary>
    /// 用户应用服务接口
    /// </summary>
    /// <typeparam name="TSource">实体类型</typeparam>
    /// <typeparam name="TDest">DTO类型</typeparam>
    public interface IUserService<TSource, TDest> where TSource : UserRoot where TDest : class
    {
        /// <summary>
        /// 插入或更新
        /// </summary>
        /// <param name="inf">实体对象</param>
        /// <returns></returns>
        bool InsertOrUpdate(TDest inf);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        bool Remove(ISpecification<TSource> spec);

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        TDest Single(ISpecification<TSource> spec);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        IQueryable<TDest> Query(ISpecification<TSource> spec);
    }
}
