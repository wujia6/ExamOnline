using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Application.DTO;
using Domain.Entities.UserAgg;

namespace Application.IServices
{
    /// <summary>
    /// 用户应用服务接口
    /// </summary>
    public interface IUserService
    {
        bool AddOrEdit(UserDTO model);

        bool Remove(Expression<Func<UserInfo, bool>> express);

        UserDTO Single(Expression<Func<UserInfo, bool>> express, Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null);

        List<UserDTO> Lists(Expression<Func<UserInfo, bool>> express = null,Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null);
    }
}
