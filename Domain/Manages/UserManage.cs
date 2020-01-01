using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Domain.IManages;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Manages
{
    /// <summary>
    /// 用户领域服务实现类
    /// </summary>
    public class UserManage : IUserManage
    {
        private readonly IEfCoreRepository<UserInfo> efCore;

        public UserManage(IEfCoreRepository<UserInfo> ef)
        {
            this.efCore = ef;
        }

        public bool AddOrEdit(UserInfo entity)
        {
            if (entity == null)
                return false;
            return entity.ID > 0 ? efCore.ModifyAt(entity) : efCore.AddAt(entity);
        }

        public bool Remove(ISpecification<UserInfo> spec)
        {
            var entity = Single(spec);
            return entity == null ? false : efCore.RemoveAt(entity);
        }

        public dynamic Single(ISpecification<UserInfo> spec, Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            if (include != null)
                return efCore.Single(spec, include);
            return efCore.Single(spec);
        }

        public IEnumerable<UserInfo> Lists(ISpecification<UserInfo> spec = null, Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            if (include != null)
                return efCore.Lists(spec, include);
            return efCore.Lists(spec);
        }

        
    }
}
