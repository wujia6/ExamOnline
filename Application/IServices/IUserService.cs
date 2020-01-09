using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Domain.Entities.UserAgg;
using Application.DTO.Models;

namespace Application.IServices
{
    /// <summary>
    /// 用户应用服务接口
    /// </summary>
    public interface IUserService
    {
        bool AddOrEdit(dynamic model);

        bool Remove(Expression<Func<UserInfo, bool>> express);

        ApplicationUser Single(Expression<Func<UserInfo, bool>> express, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null);

        List<ApplicationUser> Lists(Expression<Func<UserInfo, bool>> express = null,
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null);

        List<ApplicationUser> Lists(out int total, int? pageIndex = 0, int? pageSize = 10, 
            Expression<Func<UserInfo, bool>> express = null,
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null);
    }
}
