using System.Linq;
using Domain.Entities;
using Domain.IComm;

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
        /// <returns></returns>
        T FindBy(ISpecification<T> spec);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        IQueryable<T> QuerySet(ISpecification<T> spec);
    }
}
