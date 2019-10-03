using System;
using System.Linq;
using Application.IServices;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Domain.IManages;

namespace Application.Services
{
    internal class UserService<T> : IUserService<T> where T : UserInfo
    {
        private readonly IUserManage<T> userManage;
        private readonly ISqlContext sqlContext;

        public UserService(IUserManage<T> mgr, ISqlContext sql)
        {
            userManage = mgr;
            this.sqlContext = sql;
        }

        public bool InsertOrUpdate(T inf)
        {
            return userManage.InsertOrUpdate(inf) ? sqlContext.SaveChanges() > 0 : false;
        }

        public bool Remove(ISpecification<T> spec)
        {
            return userManage.Remove(spec) ? sqlContext.SaveChanges() > 0 : false;
        }

        public T Single(ISpecification<T> spec)
        {
            return userManage.FindBySpec(spec);
        }

        public IQueryable<T> Query(ISpecification<T> spec)
        {
            return userManage.QueryBySpec(spec);
        }
    }
}
