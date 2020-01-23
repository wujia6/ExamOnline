using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Domain.Entities;
using Domain.Entities.MenuAgg;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.IServices
{
    public interface IMenuService
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <returns></returns>
        bool Save(MenuDto model);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <returns></returns>
        bool Edit(MenuDto model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spec">表达式对象</param>
        /// <returns></returns>
        bool Remove(Expression<Func<MenuInfo, bool>> express);

        /// <summary>
        /// 获取单个模型
        /// </summary>
        /// <param name="express">表达式对象</param>
        /// <returns></returns>
        MenuDto Single(Expression<Func<MenuInfo, bool>> express);

        /// <summary>
        /// 获取分页集合
        /// </summary>
        /// <param name="total">分页总记录</param>
        /// <param name="index">当前页码</param>
        /// <param name="size">显示记录</param>
        /// <param name="express">条件表达式</param>
        /// <param name="include">关联属性</param>
        /// <returns></returns>
        List<MenuDto> Lists(
            out int total, 
            int? index = 1, 
            int? size = 10,
            Expression<Func<MenuInfo, bool>> express = null,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="spec">表达式对象</param>
        /// <returns></returns>
        Task<List<MenuDto>> QueryByAsync(Expression<Func<MenuInfo, bool>> express);

        /// <summary>
        /// 获取分页集合（异步）
        /// </summary>
        /// <param name="index">当前页码</param>
        /// <param name="size">显示记录</param>
        /// <param name="express">条件表达式</param>
        /// <param name="include">关联属性</param>
        /// <returns></returns>
        Task<PageResult> ListsAsync(
            int? index = 1,
            int? size = 10,
            Expression<Func<MenuInfo, bool>> express = null,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);
    }
}
