using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Domain.Entities.UserAgg;
using Application.ViewModels;

namespace Application.IServices
{
    /// <summary>
    /// 用户应用服务接口
    /// </summary>
    public interface IUserService
    {
        bool AddOrEdit(DtoUser model);

        bool Remove(Expression<Func<UserInfo, bool>> express);

        DtoUser Single(Expression<Func<UserInfo, bool>> express, Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null);

        List<DtoUser> Lists(Expression<Func<UserInfo, bool>> express = null,Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null);
    }
}
