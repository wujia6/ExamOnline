using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.IManages
{
    /// <summary>
    /// 领域用户服务接口
    /// </summary>
    public interface IUserManage
    {
        /// <summary>
        /// 添加或修改
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool AddOrEdit(dynamic entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        bool Remove(ISpecification<UserInfo> spec);

        /// <summary>
        /// 单个查找
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        dynamic Single(ISpecification<UserInfo> spec, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        IEnumerable<dynamic> Lists(ISpecification<UserInfo> spec = null, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="total">总记录</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">显示记录数</param>
        /// <param name="spec">规约表达式</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        IEnumerable<UserInfo> Lists(out int total, int? pageIndex = 0, int? pageSize = 10,
            ISpecification<UserInfo> spec = null,
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null);
    }

    /// <summary>
    /// 领域用户泛型服务接口
    /// </summary>
    public interface IUserManage<T> where T : BaseEntity, IAggregateRoot
    {
        bool AddorEdit(T entity);

        bool Remove(ISpecification<T> spec);

        T Single(ISpecification<T> spec,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        IEnumerable<T> Lists(out int total, int? pageIndex = 1, int? pageSize = 10,
            ISpecification<T> spec = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
