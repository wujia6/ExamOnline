using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Domain.Entities.MenuAgg;
using Domain.IComm;
using Domain.IManages;

namespace Domain.Manages
{
    public class MenuManage : IMenuManage
    {
        private readonly IEfCoreRepository<MenuInfo> efCore;

        public MenuManage(IEfCoreRepository<MenuInfo> ef)
        {
            this.efCore = ef;
        }

        #region ### functions
        public bool SaveAs(MenuInfo entity)
        {
            return efCore.SaveAs(entity);
        }

        public bool EditTo(MenuInfo entity)
        {
            return efCore.EditTo(entity);
        }

        public bool RemoveAt(ISpecification<MenuInfo> spec)
        {
            //var entity = efCore.EntitySet.SingleOrDefault(spec.Expression);
            var entities = efCore.EntitySet.Where(spec.Expression);
            return entities == null ? false : efCore.RemoveAt(entities);
        }

        public async Task<MenuInfo> SingleAsync(
            ISpecification<MenuInfo> spec,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null)
        {
            if (include != null)
                efCore.EntitySet = include(efCore.EntitySet);
            return await efCore.EntitySet.FirstOrDefaultAsync(spec.Expression);
        }

        public async Task<object> QueryAsync(
            int? offset, int? limit,
            ISpecification<MenuInfo> spec = null,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null)
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
        #endregion
    }
}
