using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
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

        public bool Save(RoleInfo entity)
        {
            return efCore.SaveAs(entity);
        }

        public bool Edit(RoleInfo entity)
        {
            return efCore.EditAs(entity);
        }

        public bool Remove(ISpecification<RoleInfo> spec)
        {
            var entity = Single(spec);
            return efCore.RemoveAs(entity);
        }

        public IEnumerable<RoleInfo> Lists(
            out int total,
            int? index,
            int? size,
            ISpecification<RoleInfo> spec = null, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            return efCore.Lists(out total, index, size, spec, include);
        }

        public RoleInfo Single(
            ISpecification<RoleInfo> spec, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            return efCore.Single(spec, include);
        }
    }
}
