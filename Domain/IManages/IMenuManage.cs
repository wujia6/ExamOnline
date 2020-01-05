using System.Collections.Generic;
using Domain.Entities.MenuAgg;
using Domain.IComm;

namespace Domain.IManages
{
    public interface IMenuManage
    {
        /// <summary>
        /// 添加或编辑
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool AddOrEdit(MenuInfo entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool Remove(ISpecification<MenuInfo> spec);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        MenuInfo FindBy(ISpecification<MenuInfo> spec);

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        IEnumerable<MenuInfo> Lists(ISpecification<MenuInfo> spec = null);
    }
}
