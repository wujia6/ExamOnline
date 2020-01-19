using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using AutoMapper.Execution;
using Application.DTO.Models;
using Application.IServices;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserManage<AdminInfo> adminManage;
        private readonly IExamDbContext context;

        public AdminService(IUserManage<AdminInfo> manage, IExamDbContext cxt)
        {
            this.adminManage = manage;
            this.context = cxt;
        }

        public bool AddOrEdit(AdminDto model)
        {
            if (model == null)
                return false;
            return adminManage.AddorEdit(model.MapTo<AdminInfo>());
        }

        public bool Remove(Expression<Func<AdminInfo, bool>> express)
        {
            var spec = Specification<AdminInfo>.Eval(express);
            return adminManage.Remove(spec);
        }

        public AdminDto Single(Expression<Func<AdminInfo, bool>> express, 
            Func<IQueryable<AdminInfo>, IIncludableQueryable<AdminInfo, object>> include = null)
        {
            var spec = Specification<AdminInfo>.Eval(express);
            return adminManage.Single(spec, include).MapTo<AdminDto>();
        }

        public List<AdminDto> Lists(out int total, int? pageIndex = 1, int? pageSize = 10, 
            Expression<Func<AdminInfo, bool>> express = null, 
            Func<IQueryable<AdminInfo>, IIncludableQueryable<AdminInfo, object>> include = null)
        {
            throw new NotImplementedException();
        }
    }
}
