using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.MenuAgg;
using Domain.IComm;
using Domain.IManages;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Manages
{
    public class MenuManage : IMenuManage
    {
        private readonly IEfCoreRepository<MenuInfo> efCore;

        public MenuManage(IEfCoreRepository<MenuInfo> ef)
        {
            this.efCore = ef;
        }

        public bool Save(MenuInfo entity)
        {
            return efCore.SaveAs(entity);
        }

        public bool Edit(MenuInfo entity)
        {
            return efCore.EditAs(entity);
        }

        public bool Remove(ISpecification<MenuInfo> spec)
        {
            var entity = Single(spec);
            return entity == null ? false : efCore.RemoveAs(entity);
        }

        public MenuInfo Single(ISpecification<MenuInfo> spec)
        {
            return efCore.Single(spec);
        }

        public IEnumerable<MenuInfo> Lists(
            out int total, 
            int? index, 
            int? size, 
            ISpecification<MenuInfo> spec = null, 
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null)
        {
            return efCore.Lists(out total, index, size, spec, include);
        }

        public async Task<bool> SaveAsync(MenuInfo entity)
        {
            return await efCore.SaveAsync(entity);
        }

        public async Task<bool> EditAsync(MenuInfo entity)
        {
            return await efCore.EditAsync(entity);
        }

        public async Task<bool> RemoveAsync(ISpecification<MenuInfo> spec)
        {
            var entity = await SingleAsync(spec);
            return await efCore.RemoveAsync(entity);
        }

        public async Task<MenuInfo> SingleAsync(ISpecification<MenuInfo> spec)
        {
            return await efCore.SingleAsync(spec);
        }

        public async Task<IEnumerable<MenuInfo>> QueryByAsync(ISpecification<MenuInfo> spec)
        {
            return await efCore.QuerySetAsync(spec);
        }

        public async Task<PageResult> ListsAsync(
            int? index, 
            int? size, 
            ISpecification<MenuInfo> spec = null, 
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null)
        {
            return await efCore.ListsAsync(index, size, spec, include);
        }
    }
}
