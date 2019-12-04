using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using Application.IServices;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Domain.IManages;
using Application.DTO.Mappings;
using Application.DTO;
using Infrastructure.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;

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
            userManage = manage;
            this.context = cxt;
        }

        public bool AddOrEdit(UserDTO model)
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

        public UserDTO Single(Expression<Func<UserInfo, bool>> express, Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            var spec = Specification<UserInfo>.Eval(express);
            dynamic entity = userManage.Single(spec, include);
            return entity.MapTo<UserDTO>();
        }

        public List<UserDTO> Lists(Expression<Func<UserInfo, bool>> express = null, Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            var spec = Specification<UserInfo>.Eval(express);
            return userManage.Lists(spec, include).MapToList<UserDTO>();
        }
    }
}
