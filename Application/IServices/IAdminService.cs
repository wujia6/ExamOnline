using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTO;
using Domain.Entities.UserAgg;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.IServices
{
    public interface IAdminService
    {
        bool AddOrEdit(AdminDTO model);

        bool Remove(Expression<Func<AdminInfo, bool>> express);

        AdminDTO Single(Expression<Func<AdminInfo, bool>> express,
            Func<IQueryable<AdminInfo>, IIncludableQueryable<AdminInfo, object>> include = null);

        List<AdminDTO> Lists(Expression<Func<AdminInfo, bool>> express = null,
            Func<IQueryable<AdminInfo>, IIncludableQueryable<AdminInfo, object>> include = null);
    }
}
