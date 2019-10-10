using System.Linq;
using Domain.Entities;

namespace Domain.IComm
{
    /// <summary>
    /// 公共泛型仓储接口
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IEfCoreRepository<T> where T: BaseEntity, IAggregateRoot
    {
        //数据上下文接口对象
        IExamDbContext SqlContext { get; }

        //数据表对象
        IQueryable<T> EntitySet { get; }

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
        T FindBySpec(ISpecification<T> spec);

        /// <summary>
        /// 查找集合
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        IQueryable<T> QueryBySpec(ISpecification<T> spec);
    }
}
