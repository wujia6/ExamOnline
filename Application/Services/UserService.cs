﻿using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using AtuoMapper;
using Application.IServices;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Repository;
using Application.ViewModels;

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

        public bool AddOrEdit(DtoUser model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<UserInfo>();
            return userManage.AddOrEdit(entity) ? context.SaveChanges() > 0 : false;
        }

        public bool Remove(Expression<Func<UserInfo, bool>> express)
        {
            var spec = Specification<UserInfo>.Eval(express);
            return userManage.Remove(spec) ? context.SaveChanges() > 0 : false;
        }

        public DtoUser Single(Expression<Func<UserInfo, bool>> express, Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            var spec = Specification<UserInfo>.Eval(express);
            UserInfo entity = userManage.Single(spec,include);
            var model = entity.MapTo<DtoUser>();
            return model;
        }

        public List<DtoUser> Lists(Expression<Func<UserInfo, bool>> express = null, Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            var spec = Specification<UserInfo>.Eval(express);
            var lstUser = userManage.Lists(spec, include);
            return lstUser.MapToList<DtoUser>();
        }
    }
}
