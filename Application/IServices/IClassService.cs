using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.IComm;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.IServices
{
    /// <summary>
    /// 班级应用服务接口
    /// </summary>
    public interface IClassService<TSource, TDest> 
        where TSource : BaseEntity, IAggregateRoot 
        where TDest : class
    {
        /// <summary>
        /// 添加编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddOrEdit(TDest model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        bool Remove(Expression<Func<TSource, bool>> express);

        /// <summary>
        /// 获取单个模型
        /// </summary>
        /// <param name="express">表达式</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        TDest Single(Expression<Func<TSource, bool>> express = null, 
            Func<IQueryable<TSource>, IIncludableQueryable<TSource, object>> include = null);

        /// <summary>
        /// 获取模型集合
        /// </summary>
        /// <param name="express">表达式</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        List<TDest> Lists(Expression<Func<TSource, bool>> express = null, 
            Func<IQueryable<TSource>, IIncludableQueryable<TSource, object>> include = null);
    }

    public interface IClassService
    {
        bool AddOrEdit<TSource>(TSource entity) where TSource : BaseEntity;

        bool Remove<TSource>(Expression<Func<TSource, bool>> express) where TSource : BaseEntity;

        TDestination Single<TSource, TDestination>(Expression<Func<TSource, bool>> express,
            Func<IQueryable<TSource>, IIncludableQueryable<TSource, object>> include = null) where TSource : BaseEntity;

        List<TDestination> Lists<TSource, TDestination>(Expression<Func<TSource, bool>> express = null,
            Func<IQueryable<TSource>, IIncludableQueryable<TSource, object>> include = null) where TSource : BaseEntity;
    }
}
