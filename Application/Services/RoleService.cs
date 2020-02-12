using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper.Execution;
using Application.DTO.Models;
using Application.IServices;
using Domain.Entities.RoleAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Query;
using System.Threading.Tasks;
using Infrastructure.Utils;

namespace Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleManage roleManage;
        private readonly IExamDbContext context;

        public RoleService(IRoleManage manage, IExamDbContext cxt)
        {
            this.roleManage = manage;
            this.context = cxt;
        }

        public async Task<bool> SaveAsync(RoleDto model)
        {
            var entity = model.MapTo<RoleInfo>();
            return roleManage.SaveAs(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> EditAsync(RoleDto model)
        {
            var entity = model.MapTo<RoleInfo>();
            return roleManage.EditTo(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> RemoveAsync(Expression<Func<RoleInfo, bool>> express)
        {
            var spec = Specification<RoleInfo>.Eval(express);
            return roleManage.RemoveAt(spec) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<RoleDto> SingleAsync(
            Expression<Func<RoleInfo, bool>> express, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            var spec = Specification<RoleInfo>.Eval(express);
            var entity = await roleManage.SingleAsync(spec);
            return entity.MapTo<RoleDto>();
        }

        public async Task<List<RoleDto>> QueryAsync(
            Expression<Func<RoleInfo, bool>> express = null, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            var spec = express == null? null : Specification<RoleInfo>.Eval(express);
            var entities = await roleManage.QueryAsync(spec,include);
            return entities.MapToList<RoleDto>();
        }

        public async Task<PageResult<RoleDto>> QueryAsync(
            int index, int size,
            Expression<Func<RoleInfo, bool>> express = null, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            var spec = express == null? null : Specification<RoleInfo>.Eval(express);
            var anonymous = await roleManage.QueryAsync(index, size, spec, include);
            return anonymous.ToPageResult<RoleDto>();
        }

        public RoleDto SingleIn(
            Expression<Func<RoleInfo, bool>> express, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            var spec = Specification<RoleInfo>.Eval(express);
            var entity = roleManage.SingleIn(spec,include);
            return entity.MapTo<RoleDto>();
        }
    }
}
