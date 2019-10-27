using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities.UserAgg;

namespace Application.IServices
{
    /// <summary>
    /// 用户应用服务接口
    /// </summary>
    /// <typeparam name="TSource">实体类型</typeparam>
    /// <typeparam name="TDest">DTO类型</typeparam>
    public interface IUserService<TSource, TDest> where TSource : UserBase where TDest : class
    {
        /// <summary>
        /// 插入或更新
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <returns></returns>
        bool InsertOrUpdate(TDest model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        bool Remove(TDest model);

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        TDest FindById(int id);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">条件委托</param>
        /// <returns></returns>
        List<TDest> QueryBySet(Expression<Func<TSource,bool>> express);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        TDest UserLogin(TDest model);

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="model">用户对象</param>
        /// <returns></returns>
        bool UserRegister(TDest model);
    }
}
