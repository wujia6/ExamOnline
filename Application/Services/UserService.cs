using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using Application.IServices;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Utils;
using Application.DTO;
using Infrastructure.Repository;

namespace Application.Services
{
    /// <summary>
    /// 用户服务类
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserManage userManage;
        private readonly IExamDbContext db;

        public UserService(IUserManage manage, IExamDbContext context)
        {
            userManage = manage;
            this.db = context;
        }

        public bool AddOrEdit(UserDTO model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<UserInfo>();
            return userManage.AddOrEdit(entity) ? db.SaveChanges() > 0 : false;
        }

        public List<UserDTO> QueryBy(Expression<Func<UserInfo, bool>> express)
        {
            var spec = Specification<UserInfo>.Eval(express);
            return userManage.QueryBy(spec).MapToList<UserDTO>();
        }

        public bool Remove(UserDTO model)
        {
            var userDto = model.MapTo<UserDTO>();
            var spec = Specification<UserInfo>.Eval(e => e.ID == userDto.ID);
            return userManage.Remove(spec) ? db.SaveChanges() > 0 : false;
        }

        public UserDTO FindBy(Expression<Func<UserInfo, bool>> express)
        {
            var spec = Specification<UserInfo>.Eval(express);
            var user = userManage.FindBy(spec);
            return user.MapTo<UserDTO>();
        }
    }
}
