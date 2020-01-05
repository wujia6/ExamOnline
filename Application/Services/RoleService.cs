using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTO.Models;
using Application.IServices;
using AutoMapper.Execution;
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

        public bool AddOrEdit(RoleDto model)
        {
            var entity = model.MapTo<RoleInfo>();
            return roleManage.AddOrEdit(entity);
        }

        public List<RoleDto> Lists(Expression<Func<RoleInfo, bool>> express = null, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            var spec = Specification<RoleInfo>.Eval(express);
            return roleManage.Lists(spec, include).MapToList<RoleDto>();
        }

        public bool Remove(Expression<Func<RoleInfo, bool>> express)
        {
            var spec = Specification<RoleInfo>.Eval(express);
            return roleManage.Remove(spec);
        }

        public RoleDto Single(Expression<Func<RoleInfo, bool>> express, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            var spec = Specification<RoleInfo>.Eval(express);
            return roleManage.Single(spec, include).MapTo<RoleDto>();
        }
    }
}
