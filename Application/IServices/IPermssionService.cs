using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.DTO.Models;
using Domain.Entities.PermissionAgg;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.IServices
{
    public interface IPermssionService
    {
        Task<bool> SaveAsync(PermissionDto model);

        Task<bool> EditAsync(PermissionDto model);

        Task<bool> RemoveAsync(Expression<Func<PermissionInfo, bool>> express);

        Task<List<PermissionDto>> QueryAsync(
            Expression<Func<PermissionInfo, bool>> express = null,
            Func<IQueryable<PermissionInfo>, IIncludableQueryable<PermissionInfo, object>> include = null);

        Task<PageResult<PermissionDto>> QueryAsync(
            int? offset, int? limit,
            Expression<Func<PermissionInfo, bool>> express = null,
            Func<IQueryable<PermissionInfo>, IIncludableQueryable<PermissionInfo, object>> include = null);
    }
}
