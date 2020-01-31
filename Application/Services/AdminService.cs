using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Application.DTO.Models;
using Application.IServices;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Domain.IManages;
using System.Threading.Tasks;
using Infrastructure.Repository;
using AutoMapper.Execution;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserManage adminManage;
        private readonly IExamDbContext context;

        public AdminService(IUserManage manage, IExamDbContext cxt)
        {
            this.adminManage = manage;
            this.context = cxt;
        }

        public async Task<bool> SaveAsync(dynamic model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<AdminInfo>();
            return adminManage.SaveAs(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> EditAsync(dynamic model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<AdminInfo>();
            return adminManage.EditTo(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> RemoveAsync(Expression<Func<UserInfo, bool>> express)
        {
            var spec = Specification<UserInfo>.Eval(express);
            return adminManage.RemoveAt(spec) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<ApplicationUser> SingleAsync(
            Expression<Func<UserInfo, bool>> express, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            var spec = Specification<UserInfo>.Eval(express);
            var entity = await adminManage.SingleAsync(spec);
            return entity.MapTo<ApplicationUser>();
        }

        public async Task<List<ApplicationUser>> QueryAsync(
            Expression<Func<UserInfo, bool>> express = null, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            var spec = express == null ? null : Specification<UserInfo>.Eval(express);
            var entities = await adminManage.QueryAsync(spec) as IEnumerable<UserInfo>;
            return entities.MapToList<ApplicationUser>();
        }

        public async Task<PageResult<ApplicationUser>> QueryAsync(
            int index, int size, 
            Expression<Func<UserInfo, bool>> express = null, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            var spec = express == null ? null : Specification<UserInfo>.Eval(express);
            var anonymous = await adminManage.QueryAsync(index, size, spec, include);
            return anonymous.ToPageResult<ApplicationUser>();
        }
    }
}
