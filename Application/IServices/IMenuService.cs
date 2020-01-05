using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTO.Models;
using Domain.Entities.MenuAgg;

namespace Application.IServices
{
    public interface IMenuService
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
        /// <param name="spec">表达式对象</param>
        /// <returns></returns>
        bool Remove(Expression<Func<MenuInfo, bool>> express);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="spec">表达式对象</param>
        /// <returns></returns>
        MenuDto FindBy(Expression<Func<MenuInfo, bool>> express);

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="spec">表达式对象</param>
        /// <returns></returns>
        IEnumerable<MenuDto> Lists(Expression<Func<MenuInfo, bool>> express = null);
    }
}
