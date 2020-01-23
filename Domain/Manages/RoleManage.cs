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

        public bool AddOrEdit(RoleInfo entity)
        {
            return entity.ID > 0 ? efCore.EditAs(entity) : efCore.SaveAs(entity);
        }

        public bool Remove(ISpecification<RoleInfo> spec)
        {
            var entity = Single(spec);
            return efCore.RemoveAs(entity);
        }

        public IEnumerable<RoleInfo> Lists(
            ISpecification<RoleInfo> spec = null, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            return efCore.QuerySet(spec, include);
        }

        public RoleInfo Single(
            ISpecification<RoleInfo> spec, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            return efCore.Single(spec, include);
        }

        public async Task<bool> AddOrEditAsync(RoleInfo entity)
        {
            return entity.ID > 0 ? await efCore.EditAsync(entity) : await efCore.SaveAsync(entity);
        }

        public async Task<bool> RemoveAsync(ISpecification<RoleInfo> spec)
        {
            var entity = await SingleAsync(spec);
            return entity == null ? false : await efCore.RemoveAsync(entity);
        }

        public async Task<RoleInfo> SingleAsync(ISpecification<RoleInfo> spec, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            return await efCore.SingleAsync(spec, include);
        }

        public async Task<PageResult> ListsAsync(
            int? index,
            int? size,
            ISpecification<RoleInfo> spec = null, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null)
        {
            return await efCore.ListsAsync(index, size, spec, include);
        }
    }
}
