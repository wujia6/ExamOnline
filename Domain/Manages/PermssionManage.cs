using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.PermissionAgg;
using Domain.IComm;
using Domain.IManages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Manages
{
    public class PermssionManage : IPermssionManage
    {
        private readonly IEfCoreRepository<PermissionInfo> efCore;

        public PermssionManage(IEfCoreRepository<PermissionInfo> ef)
        {
            this.efCore = ef;
        }

        public bool EditTo(PermissionInfo entity)
        {
            return efCore.EditTo(entity);
        }

        public bool RemoveAt(ISpecification<PermissionInfo> spec)
        {
            var entities = efCore.EntitySet.Where(spec.Expression);
            return entities == null ? false : efCore.RemoveAt(entities);
        }

        public bool SaveAs(PermissionInfo entity)
        {
            return efCore.SaveAs(entity);
        }

        public async Task<IEnumerable<PermissionInfo>> QueryAsync(ISpecification<PermissionInfo> spec = null)
        {
            if (spec != null)
                efCore.EntitySet = efCore.EntitySet.Where(spec.Expression);
            return await efCore.EntitySet.ToListAsync();
        }

        public async Task<PermissionInfo> SingleAsync(ISpecification<PermissionInfo> spec)
        {
            return await efCore.EntitySet.FirstOrDefaultAsync(spec.Expression);
        }
    }
}
