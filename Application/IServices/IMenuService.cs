using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTO.Models;
using Domain.Entities.MenuAgg;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.IServices
{
    public interface IMenuService
    {
        /// <summary>
        /// 添加或编辑
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <returns></returns>
        bool AddOrEdit(MenuDto model);

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
        /// 获取分页集合
        /// </summary>
        /// <param name="total">分页总记录</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">显示记录</param>
        /// <param name="express">条件表达式</param>
        /// <param name="include">关联属性</param>
        /// <returns></returns>
        List<MenuDto> Lists(
            out int total, 
            int? pageIndex = 1, 
            int? pageSize = 10,
            Expression<Func<MenuInfo, bool>> express = null,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);

        /// <summary>
        /// 获取分页集合
        /// </summary>
        /// <param name="draw">当前绘制页码</param>
        /// <param name="start">记录开始位置</param>
        /// <param name="length">显示记录长度</param>
        /// <returns></returns>
        List<MenuDto> Paginator(int? draw = 1, int? start = 0, int? length = 10);
    }
}
