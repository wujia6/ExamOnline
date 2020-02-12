using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Domain.Entities.ClassAgg;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.IServices
{
    /// <summary>
    /// 班级应用服务接口
    /// </summary>
    public interface IClassService
    {
        Task<bool> SaveAsync(ClassDto model);

        Task<bool> EditAsync(ClassDto model);

        Task<bool> RemoveAsync(Expression<Func<ClassInfo, bool>> express);

        Task<ClassDto> SingleAsync(
            Expression<Func<ClassInfo, bool>> express,
            Func<IQueryable<ClassInfo>, IIncludableQueryable<ClassInfo, object>> include = null);

        Task<List<ClassDto>> QueryAsync(
            Expression<Func<ClassInfo, bool>> express = null,
            Func<IQueryable<ClassInfo>, IIncludableQueryable<ClassInfo, object>> include = null);

        Task<PageResult<ClassDto>> QueryAsync(
            int index, int size,
            Expression<Func<ClassInfo, bool>> express = null,
            Func<IQueryable<ClassInfo>, IIncludableQueryable<ClassInfo, object>> include = null);
    }
}
