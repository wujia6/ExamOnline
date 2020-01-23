using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper.Execution;
using Application.DTO.Models;
using Application.IServices;
using Domain.Entities.RoleAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Query;
using Domain.Entities;

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

        public bool AddOrEdit(RoleDto model)
        {
            var entity = model.MapTo<RoleInfo>();
            return roleManage.AddOrEdit(entity);
        }

        public bool Remove(Expression<Func<RoleInfo, bool>> express)
        {
            var spec = Specification<RoleInfo>.Eval(express);
            return roleManage.Remove(spec);
        }

        public List<RoleDto> Lists(Expression<Func<RoleInfo, bool>> express = null, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            var spec = Specification<RoleInfo>.Eval(express);
            return roleManage.Lists(spec, include).MapToList<RoleDto>();
        }

        public RoleDto Single(Expression<Func<RoleInfo, bool>> express, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            var spec = Specification<RoleInfo>.Eval(express);
            return roleManage.Single(spec, include).MapTo<RoleDto>();
        }

        public async Task<bool> AddOrEdirAsync(RoleDto model)
        {
            var entity = model.MapTo<RoleInfo>();
            return await roleManage.AddOrEditAsync(entity);
        }

        public async Task<bool> RemoveAsync(Expression<Func<RoleInfo, bool>> express)
        {
            var spec = Specification<RoleInfo>.Eval(express);
            return await roleManage.RemoveAsync(spec);
        }

        public async Task<RoleDto> SingleAsync(Expression<Func<RoleInfo, bool>> express, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            var spec = Specification<RoleInfo>.Eval(express);
            var entity = await roleManage.SingleAsync(spec);
            return MapToExtensions.MapTo<RoleDto>(entity);
        }

        public async Task<PageResult> ListsAsync(
            int? index,
            int? size,
            Expression<Func<RoleInfo, bool>> express = null,
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            var spec = Specification<RoleInfo>.Eval(express);
            var result = await roleManage.ListsAsync(index,size,spec, include);
            result.Rows = MapToExtensions.MapToList<RoleDto>(result.Rows);
            return result;
        }
    }
}
