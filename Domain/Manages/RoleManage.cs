using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.RoleAgg;
using Domain.IComm;
using Domain.IManages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Manages
{
    public class RoleManage : IRoleManage
    {
        private readonly IEfCoreRepository<RoleInfo> efCore;

        public RoleManage(IEfCoreRepository<RoleInfo> ef)
        {
            this.efCore = ef ?? throw new ArgumentNullException(nameof(efCore));
        }

        public bool SaveAs(RoleInfo entity)
        {
            return efCore.SaveAs(entity);
        }

        public bool EditTo(RoleInfo entity)
        {
            return efCore.EditTo(entity);
        }

        public bool RemoveAt(ISpecification<RoleInfo> spec)
        {
            var entity = efCore.EntitySet.FirstOrDefault(spec.Expression);
            return entity == null ? false : efCore.RemoveAt(entity);
        }

        public async Task<RoleInfo> SingleAsync(
            ISpecification<RoleInfo> spec, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            if (include!=null)
                efCore.EntitySet = include(efCore.EntitySet);
            return await efCore.EntitySet.FirstOrDefaultAsync(spec.Expression);
        }

        public async Task<IEnumerable<RoleInfo>> QueryAsync(
            ISpecification<RoleInfo> spec = null,
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            if (include != null)
                efCore.EntitySet = include(efCore.EntitySet);
            if (spec != null)
                efCore.EntitySet = efCore.EntitySet.Where(spec.Expression);
            return await efCore.EntitySet.ToListAsync();
        }

        //public async Task<object> QueryAsync(
        //    int offset, int limit,
        //    ISpecification<RoleInfo> spec = null,
        //    Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        //{
        //    if (include != null)
        //        efCore.EntitySet = include(efCore.EntitySet);
        //    if (spec != null)
        //        efCore.EntitySet = efCore.EntitySet.Where(spec.Expression);
        //    return new
        //    {
        //        Total = await efCore.EntitySet.CountAsync(),
        //        Rows = await efCore.EntitySet.Skip(offset).Take(limit).ToListAsync()
        //    };
        //}
    }
}
