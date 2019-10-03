﻿using System.Linq;
using Domain.Entities.UserAgg;
using Domain.IComm;

namespace Application.IServices
{
    /// <summary>
    /// 用户应用服务接口
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IUserService<T> where T : UserInfo
    {
        /// <summary>
        /// 插入或更新
        /// </summary>
        /// <param name="inf">实体对象</param>
        /// <returns></returns>
        bool InsertOrUpdate(T inf);

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
        /// <returns></returns>
        T Single(ISpecification<T> spec);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        IQueryable<T> Query(ISpecification<T> spec);
    }
}
