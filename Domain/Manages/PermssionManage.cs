using System;
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

        public async Task<object> QueryAsync(int? offset, int? limit, 
            ISpecification<PermissionInfo> spec = null, 
            Func<IQueryable<PermissionInfo>, IIncludableQueryable<PermissionInfo, object>> include = null)
        {
            dynamic anonymous = new { };
            if (include != null)
                efCore.EntitySet = include(efCore.EntitySet);
            if (spec != null)
                efCore.EntitySet = efCore.EntitySet.Where(spec.Expression);
            if (offset.HasValue && limit.HasValue)
            {
                anonymous.Total = await efCore.EntitySet.CountAsync();
                efCore.EntitySet = efCore.EntitySet.Skip(offset.Value).Take(limit.Value);
            }
            anonymous.Rows = await efCore.EntitySet.ToListAsync();
            return anonymous;
        }
    }
}
