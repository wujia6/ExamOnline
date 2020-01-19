using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTO.Models;
using Domain.Entities.UserAgg;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.IServices
{
    public interface IAdminService
    {
        bool AddOrEdit(AdminDto model);

        bool Remove(Expression<Func<AdminInfo, bool>> express);

        AdminDto Single(Expression<Func<AdminInfo, bool>> express,
            Func<IQueryable<AdminInfo>, IIncludableQueryable<AdminInfo, object>> include = null);

        List<AdminDto> Lists(out int total, int? pageIndex = 1, int? pageSize = 10, 
            Expression<Func<AdminInfo, bool>> express = null, 
            Func<IQueryable<AdminInfo>, IIncludableQueryable<AdminInfo, object>> include = null);
    }
}
