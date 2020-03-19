using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Domain.Entities.RoleAgg;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.IServices
{
    public interface IRoleService
    {
        Task<bool> SaveAsync(RoleDto model);

        Task<bool> EditAsync(RoleDto model);

        Task<bool> RemoveAsync(Expression<Func<RoleInfo, bool>> express);

        Task<RoleDto> SingleAsync(
            Expression<Func<RoleInfo, bool>> express, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null);

        Task<List<RoleDto>> QueryAsync(
            Expression<Func<RoleInfo, bool>> express = null,
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null);

        Task<PageResult<RoleDto>> QueryAsync(
            int offset, 
            int limit,
            Expression<Func<RoleInfo, bool>> express = null,
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null);
    }
}
