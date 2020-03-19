using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Domain.Entities.PermissionAgg;
using Infrastructure.Utils;

namespace Application.IServices
{
    public interface IPermssionService
    {
        Task<bool> SaveAsync(PermissionDto model);

        Task<bool> EditAsync(PermissionDto model);

        Task<bool> RemoveAsync(Expression<Func<PermissionInfo, bool>> express);

        Task<PermissionDto> SingleAsync(Expression<Func<PermissionInfo, bool>> express);

        Task<List<PermissionDto>> QueryAsync(Expression<Func<PermissionInfo, bool>> express = null);

        Task<PageResult<PermissionDto>> PaginatorAsync(int offset, int limit, Expression<Func<PermissionInfo, bool>> express = null);
    }
}
