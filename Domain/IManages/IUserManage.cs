using System.Linq;
using Domain.Entities.UserAgg;
using Domain.IComm;

namespace Domain.IManages
{
    /// <summary>
    /// 领域服务用户接口
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IUserManage<T> where T : UserRoot
    {
        /// <summary>
        /// 添加或修改
        /// </summary>
        /// <param name="inf">实体对象</param>
        /// <returns></returns>
        bool InsertOrUpdate(T inf);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        bool Remove(ISpecification<T> spec);

        /// <summary>
        /// 单个查找
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        T FindBySpec(ISpecification<T> spec);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        IQueryable<T> QueryBySpec(ISpecification<T> spec);
    }
}
