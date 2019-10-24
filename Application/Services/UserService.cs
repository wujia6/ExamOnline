using System.Collections.Generic;
using Application.IServices;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Utils;
using Application.DTO;
using Infrastructure.Repository;
using System;
using System.Linq.Expressions;

namespace Application.Services
{
    internal class UserService<TSource, TDest> : IUserService<TSource, TDest> 
        where TSource : UserRoot 
        where TDest : class
    {
        private readonly IUserManage<TSource> userManage;
        private readonly IExamDbContext examContext;

        public UserService(IUserManage<TSource> manage, IExamDbContext context)
        {
            userManage = manage;
            this.examContext = context;
        }

        public bool InsertOrUpdate(TDest model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<TSource>();
            return userManage.InsertOrUpdate(entity) ? examContext.SaveChanges() > 0 : false;
        }

        public bool Remove(TDest model)
        {
            var userDto = model.MapTo<TDest>() as UserRootDTO;
            ISpecification<TSource> spec = Specification<TSource>.Eval(e => e.ID == userDto.ID);
            return userManage.Remove(spec) ? examContext.SaveChanges() > 0 : false;
        }

        public TDest FindById(int id)
        {
            var spec = Specification<TSource>.Eval(e => e.ID == id);
            return userManage.FindBySpec(spec).MapTo<TDest>();
        }

        public List<TDest> QueryBySet(Expression<Func<TSource, bool>> express)
        {
            var spec = Specification<TSource>.Eval(express);
            return userManage.QueryBySpec(spec).MapToList<TDest>();
        }

        public TDest UserLogin(TDest model)
        {
            var userDto = model.MapTo<TDest>() as UserRootDTO;
            var spec = Specification<TSource>.Eval(e => e.Account == userDto.Account && e.Pwd == userDto.Pwd);
            return userManage.FindBySpec(spec).MapTo<TDest>();
        }

        public bool UserRegister(TDest model)
        {
            if (model==null)
                return false;
            var entity = model.MapTo<TSource>();
            return userManage.InsertOrUpdate(entity);
        }
    }
}
