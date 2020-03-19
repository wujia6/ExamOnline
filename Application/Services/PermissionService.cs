using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Application.IServices;
using AutoMapper.Execution;
using Domain.Entities.PermissionAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;
using Infrastructure.Utils;

namespace Application.Services
{
    public class PermissionService : IPermssionService
    {
        private readonly IPermssionManage permssionManage;
        private readonly IExamDbContext context;

        public PermissionService(IPermssionManage manage, IExamDbContext cxt)
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

        public async Task<PermissionDto> SingleAsync(Expression<Func<PermissionInfo, bool>> express)
        {
            var spec = Specification<PermissionInfo>.Eval(express);
            var entry = await permssionManage.SingleAsync(spec);
            return entry.MapTo<PermissionDto>();
        }

        public async Task<List<PermissionDto>> QueryAsync(Expression<Func<PermissionInfo, bool>> express = null)
        {
            var spec = express == null ? null : Specification<PermissionInfo>.Eval(express);
            var entreies = await permssionManage.QueryAsync(spec);
            var models = entreies.MapToList<PermissionDto>();
            return CommonUtils.Recursion(models);
        }

        public async Task<PageResult<PermissionDto>> PaginatorAsync(int offset, int limit, Expression<Func<PermissionInfo, bool>> express = null)
        {
            var spec = express == null ? null : Specification<PermissionInfo>.Eval(express);
            var entrys = await permssionManage.QueryAsync(spec);
            var anonymous = new { total = entrys.Count(), rows = entrys.Skip(offset).Take(limit) };
            return anonymous.ToPageResult<PermissionDto>();
        }
    }
}
