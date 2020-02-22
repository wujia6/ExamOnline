using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.DTO.Models;
using Application.IServices;
using AutoMapper.Execution;
using Domain.Entities.PermissionAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services
{
    public class PermssionService : IPermssionService
    {
        private readonly IPermssionManage permssionManage;
        private readonly IExamDbContext context;

        public PermssionService(IPermssionManage manage, IExamDbContext cxt)
        {
            this.permssionManage = manage ?? throw new ArgumentNullException(nameof(permssionManage));
            this.context = cxt ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> SaveAsync(PermissionDto model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<PermissionInfo>();
            return permssionManage.SaveAs(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> EditAsync(PermissionDto model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<PermissionInfo>();
            return permssionManage.EditTo(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> RemoveAsync(Expression<Func<PermissionInfo, bool>> express)
        {
            var spec = Specification<PermissionInfo>.Eval(express);
            return permssionManage.RemoveAt(spec) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<List<PermissionDto>> QueryAsync(
            Expression<Func<PermissionInfo, bool>> express = null, 
            Func<IQueryable<PermissionInfo>, IIncludableQueryable<PermissionInfo, object>> include = null)
        {
            var spec = express == null ? null : Specification<PermissionInfo>.Eval(express);
            dynamic anonymous = await permssionManage.QueryAsync(null, null, spec, include);
            return anonymous.Rows.MapToList<PermissionDto>();
            //return (anonymous.GetType().GetProperty("Rows").GetValue(anonymous) as IEnumerable<object>).MapToList<PermssionDto>();
        }

        public async Task<PageResult<PermissionDto>> QueryAsync(
            int? offset, int? limit, 
            Expression<Func<PermissionInfo, bool>> express = null, 
            Func<IQueryable<PermissionInfo>, IIncludableQueryable<PermissionInfo, object>> include = null)
        {
            var spec = express == null ? null : Specification<PermissionInfo>.Eval(express);
            var anonymous = await permssionManage.QueryAsync(offset, limit, spec, include);
            return anonymous.ToPageResult<PermissionDto>();
        }
    }
}
