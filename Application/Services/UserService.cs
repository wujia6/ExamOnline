using System.Linq;
using Application.IServices;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Utilities;

namespace Application.Services
{
    internal class UserService<TSource, TDest> : IUserService<TSource, TDest> 
        where TSource : UserInfo 
        where TDest : class
    {
        private readonly IUserManage<TSource> userManage;
        private readonly ISqlContext sqlContext;

        public UserService(IUserManage<TSource> mgr, ISqlContext sql)
        {
            userManage = mgr;
            this.sqlContext = sql;
        }

        public bool InsertOrUpdate(TDest inf)
        {
            if (inf == null)
                return false;
            var entity = inf.MapTo<TSource>();
            return userManage.InsertOrUpdate(entity) ? sqlContext.SaveChanges() > 0 : false;
        }

        public bool Remove(ISpecification<TSource> spec)
        {
            return userManage.Remove(spec) ? sqlContext.SaveChanges() > 0 : false;
        }

        public TDest Single(ISpecification<TSource> spec)
        {
            return userManage.FindBySpec(spec).MapTo<TDest>();
        }

        public IQueryable<TDest> Query(ISpecification<TSource> spec)
        {
            return userManage.QueryBySpec(spec).MapToList<TDest>().AsQueryable();
        }
    }
}
