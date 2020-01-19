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
    /// 领域用户服务实现类
    /// </summary>
    public class UserManage : IUserManage
    {
        private readonly IEfCoreRepository<UserInfo> efCore;

        public UserManage(IEfCoreRepository<UserInfo> ef)
        {
            this.efCore = ef;
        }

        public bool AddOrEdit(dynamic entity)
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

        public dynamic Single(ISpecification<UserInfo> spec, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            return efCore.Single(spec, include);
        }

        public IEnumerable<dynamic> Lists(ISpecification<UserInfo> spec = null, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            return efCore.Lists(spec, include);
        }

        public IEnumerable<UserInfo> Lists(out int total, int? pageIndex = 0, int? pageSize = 10, 
            ISpecification<UserInfo> spec = null, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            return efCore.Lists(out total, pageIndex, pageSize, spec, include);
        }
    }

    /// <summary>
    /// 领域用户泛型服务实现类
    /// </summary>
    public class UserManage<T> : IUserManage<T> where T : Entities.BaseEntity, IAggregateRoot
    {
        private readonly IEfCoreRepository<T> efCore;

        public UserManage(IEfCoreRepository<T> ef)
        {
            this.efCore = ef;
        }

        public bool AddorEdit(T entity)
        {
            if (entity == null)
                return false;
            return entity.ID > 0 ? efCore.ModifyAt(entity) : efCore.AddAt(entity);
        }

        public bool Remove(ISpecification<T> spec)
        {
            var entity = Single(spec);
            return entity == null ? false : efCore.RemoveAt(entity);
        }

        public T Single(ISpecification<T> spec, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return efCore.Single(spec, include);
        }

        public IEnumerable<T> Lists(out int total, int? pageIndex = 1, int? pageSize = 10,
            ISpecification<T> spec = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return efCore.Lists(out total, pageIndex, pageSize, spec, include);
        }
    }
}
