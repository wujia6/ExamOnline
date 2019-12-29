using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using Application.IServices;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Domain.IManages;
using Application.DTO;
using Infrastructure.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using AutoMapper;

namespace Application.Services
{
    /// <summary>
    /// 用户服务类
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserManage userManage;
        private readonly IExamDbContext context;
        private readonly IMapper mapper;

        public UserService(IUserManage manage, IExamDbContext cxt, IMapper map)
        {
            this.userManage = manage;
            this.context = cxt;
            this.mapper = map;
        }

        public bool AddOrEdit(UserDTO model)
        {
            if (model == null)
                return false;
            var entity = mapper.Map<UserInfo>(model);
            return userManage.AddOrEdit(entity) ? context.SaveChanges() > 0 : false;
        }

        public bool Remove(Expression<Func<UserInfo, bool>> express)
        {
            var spec = Specification<UserInfo>.Eval(express);
            return userManage.Remove(spec) ? context.SaveChanges() > 0 : false;
        }

        public UserDTO Single(Expression<Func<UserInfo, bool>> express, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            var spec = Specification<UserInfo>.Eval(express);
            var entity = userManage.Single(spec,include);
            var model = mapper.Map<UserDTO>(entity);
            return model;
        }

        public List<UserDTO> Lists(Expression<Func<UserInfo, bool>> express = null, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            var spec = Specification<UserInfo>.Eval(express);
            //return userManage.Lists(spec, include).MapToList<UserDTO>();
            return mapper.Map<List<UserDTO>>(userManage.Lists(spec, include));
        }
    }
}
