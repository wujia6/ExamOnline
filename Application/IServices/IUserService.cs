using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Domain.Entities.UserAgg;
using Application.DTO.Models;
using System.Threading.Tasks;
using Infrastructure.Utils;

namespace Application.IServices
{
    /// <summary>
    /// 应用用户服务接口
    /// </summary>
    public interface IUserService
    {
        Task<bool> SaveAsync(dynamic model);

        Task<bool> EditAsync(dynamic model);

        Task<bool> RemoveAsync(Expression<Func<UserInfo, bool>> express);

        Task<ApplicationUser> SingleAsync(
            Expression<Func<UserInfo, bool>> express, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null);

        Task<List<ApplicationUser>> QueryAsync(
            Expression<Func<UserInfo, bool>> express = null,
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null);

        Task<PageResult<ApplicationUser>> QueryAsync(
            int index, int size, 
            Expression<Func<UserInfo, bool>> express = null,
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null);
    }
}
