﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Application.DTO.Models;
using Domain.Entities.MenuAgg;
using Infrastructure.Utils;

namespace Application.IServices
{
    public interface IMenuService
    {
        bool EditTo(MenuDto model);

        Task<bool> SaveAsync(MenuDto model);
        
        Task<bool> EditAsync(MenuDto model);
        
        Task<bool> RemoveAsync(Expression<Func<MenuInfo, bool>> express);

        Task<List<MenuDto>> QueryAsync(
            Expression<Func<MenuInfo, bool>> express = null,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);

        Task<PageResult<MenuDto>> QueryAsync(
            int offset, int limit,
            Expression<Func<MenuInfo, bool>> express = null,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);
    }
}
