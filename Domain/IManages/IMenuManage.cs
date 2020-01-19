using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.MenuAgg;
using Domain.IComm;
using Microsoft.EntityFrameworkCore.Query;

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
        /// 获取分页集合
        /// </summary>
        /// <param name="total">分页总记录</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">显示记录</param>
        /// <param name="spec">规约对象</param>
        /// <param name="include">关联属性</param>
        /// <returns></returns>
        IEnumerable<MenuInfo> Lists(
            out int total, 
            int? pageIndex = 1, 
            int? pageSize = 10,
            ISpecification<MenuInfo> spec = null,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);
    }
}
