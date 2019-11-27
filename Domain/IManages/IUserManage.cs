using System;
using System.Linq;
using Domain.Entities.UserAgg;
using Domain.IComm;

namespace Domain.IManages
{
    /// <summary>
    /// 领域服务用户接口
    /// </summary>
    public interface IUserManage
    {
        /// <summary>
        /// 添加或修改
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool AddOrEdit(UserInfo entity);

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
        /// <returns></returns>
        UserInfo FindBy(ISpecification<UserInfo> spec);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        IQueryable<UserInfo> QueryBy(ISpecification<UserInfo> spec);
    }
}
