using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTO.Models;
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
    }
}
