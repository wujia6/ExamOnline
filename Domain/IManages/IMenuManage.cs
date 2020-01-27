using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.MenuAgg;
using Domain.IComm;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.IManages
{
    public interface IMenuManage
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool Save(MenuInfo entity);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool Edit(MenuInfo entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool Remove(ISpecification<MenuInfo> spec);

        /// <summary>
        /// 获取单个实体模型
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        MenuInfo Single(ISpecification<MenuInfo> spec);

        /// <summary>
        /// 获取分页集合
        /// </summary>
        /// <param name="total">分页总记录</param>
        /// <param name="index">当前页码</param>
        /// <param name="size">显示记录</param>
        /// <param name="spec">规约对象</param>
        /// <param name="include">关联属性</param>
        /// <returns></returns>
        IEnumerable<MenuInfo> Lists(
            out int total, 
            int? index = 1, 
            int? size = 10,
            ISpecification<MenuInfo> spec = null,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        Task<bool> SaveAsync(MenuInfo entity);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        Task<bool> EditAsync(MenuInfo entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        Task<bool> RemoveAsync(ISpecification<MenuInfo> spec);

        /// <summary>
        /// 获取单个模型
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        Task<MenuInfo> SingleAsync(ISpecification<MenuInfo> spec);

        /// <summary>
        /// 获取集合（异步）
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        Task<IEnumerable<MenuInfo>> QueryByAsync(ISpecification<MenuInfo> spec);

        /// <summary>
        /// 获取分页集合（异步）
        /// </summary>
        /// <param name="index">当前页码</param>
        /// <param name="size">显示记录</param>
        /// <param name="spec">规约对象</param>
        /// <param name="include">关联属性</param>
        /// <returns></returns>
        Task<PageResult> ListsAsync(
            int? index, 
            int? size, 
            ISpecification<MenuInfo> spec = null, 
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);
    }
}
