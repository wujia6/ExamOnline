using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Domain.Entities.UserAgg;
using Domain.IManages;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.IServices
{
    public interface IAdminService : IUserService
    {
        //Task<bool> SaveAsync(AdminDto model);

        //Task<bool> EditAsync(AdminDto model);

        //Task<bool> RemoveAsync(Expression<Func<AdminInfo, bool>> express);

        //Task<AdminDto> SingleAsync(
        //    Expression<Func<AdminInfo, bool>> express,
        //    Func<IQueryable<AdminInfo>, IIncludableQueryable<AdminInfo, object>> include = null);

        //Task<List<AdminDto>> QueryAsync(
        //    Expression<Func<AdminInfo, bool>> express = null,
        //    Func<IQueryable<AdminInfo>, IIncludableQueryable<AdminInfo, object>> include = null);

        //Task<PageResult<AdminDto>> QueryAsync(
        //    int index, int size,
        //    Expression<Func<AdminInfo, bool>> express = null,
        //    Func<IQueryable<AdminInfo>, IIncludableQueryable<AdminInfo, object>> include = null);
    }
}
