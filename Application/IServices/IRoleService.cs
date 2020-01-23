using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Domain.Entities;
using Domain.Entities.RoleAgg;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.IServices
{
    public interface IRoleService
    {
        bool AddOrEdit(RoleDto model);

        bool Remove(Expression<Func<RoleInfo, bool>> express);

        RoleDto Single(Expression<Func<RoleInfo, bool>> express, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null);

        List<RoleDto> Lists(Expression<Func<RoleInfo, bool>> express = null,
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null);

        Task<bool> AddOrEdirAsync(RoleDto model);

        Task<bool> RemoveAsync(Expression<Func<RoleInfo, bool>> express);

        Task<RoleDto> SingleAsync(Expression<Func<RoleInfo, bool>> express,
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null);

        Task<PageResult> ListsAsync(
            int? index = 1,
            int? size = 10,
            Expression<Func<RoleInfo, bool>> express = null,
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null);
    }
}
