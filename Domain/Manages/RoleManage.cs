using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.RoleAgg;
using Domain.IComm;
using Domain.IManages;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Manages
{
    public class RoleManage : IRoleManage
    {
        private readonly IEfCoreRepository<RoleInfo> efCore;

        public RoleManage(IEfCoreRepository<RoleInfo> ef)
        {
            this.efCore = ef;
        }

        public bool AddOrEdit(RoleInfo entity)
        {
            return entity.ID > 0 ? efCore.ModifyAt(entity) : efCore.AddAt(entity);
        }

        public IEnumerable<RoleInfo> Lists(ISpecification<RoleInfo> spec = null, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            return efCore.Lists(spec, include);
        }

        public bool Remove(ISpecification<RoleInfo> spec)
        {
            var entity = Single(spec);
            return efCore.RemoveAt(entity);
        }

        public RoleInfo Single(ISpecification<RoleInfo> spec, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            return efCore.Single(spec, include);
        }
    }
}
