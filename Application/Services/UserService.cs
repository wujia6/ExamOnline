using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using AutoMapper.Execution;
using Application.IServices;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;
using Application.DTO.Models;
using System.Threading.Tasks;

namespace Application.Services
{
    /// <summary>
    /// 用户服务类
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserManage userManage;
        private readonly IExamDbContext context;

        public UserService(IUserManage manage, IExamDbContext cxt)
        {
            this.userManage = manage;
            this.context = cxt;
        }

        public async Task<bool> SaveAsync(dynamic model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<UserInfo>();
            return userManage.SaveAs(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> EditAsync(dynamic model)
        {
            if (model==null)
                return false;
            var entity = model.MapTo<UserInfo>();
            return userManage.EditTo(entity) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<bool> RemoveAsync(Expression<Func<UserInfo, bool>> express)
        {
            var spec = Specification<UserInfo>.Eval(express);
            return userManage.RemoveAt(spec) ? await context.SaveChangesAsync() > 0 : false;
        }

        public async Task<ApplicationUser> SingleAsync(
            Expression<Func<UserInfo, bool>> express, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            var spec = Specification<UserInfo>.Eval(express);
            UserInfo entity = await userManage.SingleAsync(spec,include);
            var model = entity.MapTo<ApplicationUser>();
            return model;
        }

        public async Task<List<ApplicationUser>> QueryAsync(
            Expression<Func<UserInfo, bool>> express = null, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            var spec = Specification<UserInfo>.Eval(express);
            var entities = await userManage.QueryAsync(spec, include);
            return entities.MapToList<ApplicationUser>();
        }

        public async Task<PageResult<ApplicationUser>> QueryAsync(
            int index, int size, 
            Expression<Func<UserInfo, bool>> express = null, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            var spec = Specification<UserInfo>.Eval(express);
            var anonymous = await userManage.QueryAsync(index, size, spec, include);
            return anonymous.ToPageResult<ApplicationUser>();
        }
    }
}
