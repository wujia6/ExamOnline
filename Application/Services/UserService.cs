using System.Collections.Generic;
using Application.IServices;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Utils;

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

        public bool Remove(ISpecification<TSource> spec)
        {
            return userManage.Remove(spec) ? examContext.SaveChanges() > 0 : false;
        }

        public TDest Single(ISpecification<TSource> spec)
        {
            return userManage.FindBySpec(spec).MapTo<TDest>();
        }

        public List<TDest> Query(ISpecification<TSource> spec)
        {
            return userManage.QueryBySpec(spec).MapToList<TDest>();
        }

        public TDest UserLogin(ISpecification<TSource> spec)
        {
            var entity = userManage.FindBySpec(spec);
            return entity.MapTo<TDest>();
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
