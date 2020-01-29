using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Domain.Entities.MenuAgg;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.IServices
{
    public interface IMenuService
    {
        Task<bool> SaveAsync(MenuDto model);
        
        Task<bool> EditAsync(MenuDto model);
        
        Task<bool> RemoveAsync(Expression<Func<MenuInfo, bool>> express);
        
        Task<MenuDto> SingleAsync(
            Expression<Func<MenuInfo, bool>> express, 
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);
        
        Task<List<MenuDto>> QuerySetAsync(
            Expression<Func<MenuInfo, bool>> express = null, 
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);
        
        Task<PageResult<MenuDto>> ListsAsync(
            int? index,
            int? size,
            Expression<Func<MenuInfo, bool>> express = null,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);
    }
}
