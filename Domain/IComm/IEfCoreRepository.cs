using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Domain.IComm
{
    /// <summary>
    /// 仓储总接口-泛型
    /// </summary>
    public interface IEfCoreRepository<T> where T : BaseEntity, IAggregateRoot
    {
        #region ### IEfCoreRepository成员
        /// <summary>
        /// 数据上下文
        /// </summary>
        IExamDbContext ApplicationContext { get; }

        /// <summary>
        /// 可查询（泛型）实体集合对象
        /// </summary>
        IQueryable<T> EntitySet { get; set; }
        
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
        bool RemoveAt(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entities">集合对象</param>
        /// <returns></returns>
        bool RemoveAt(IQueryable<T> entities);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        bool EditTo(T entity);
        #endregion
    }
}
