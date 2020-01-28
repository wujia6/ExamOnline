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

        public bool Save(RoleDto model)
        {
            var entity = model.MapTo<RoleInfo>();
            return roleManage.Save(entity) ? context.SaveChanges() > 0 : false;
        }

        public bool Edit(RoleDto model)
        {
            var entity = model.MapTo<RoleInfo>();
            return roleManage.Edit(entity) ? context.SaveChanges() > 0 : false;
        }

        public bool Remove(Expression<Func<RoleInfo, bool>> express)
        {
            var spec = Specification<RoleInfo>.Eval(express);
            return roleManage.Remove(spec) ? context.SaveChanges() > 0 : false;
        }

        public List<RoleDto> Lists(
            out int total,
            int? index,
            int? size,
            Expression<Func<RoleInfo, bool>> express = null, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            var spec = express == null? null : Specification<RoleInfo>.Eval(express);
            return roleManage.Lists(out total, index, size, spec, include).MapToList<RoleDto>();
        }

        public RoleDto Single(
            Expression<Func<RoleInfo, bool>> express, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            var spec = Specification<RoleInfo>.Eval(express);
            return roleManage.Single(spec, include).MapTo<RoleDto>();
        }
    }
}
