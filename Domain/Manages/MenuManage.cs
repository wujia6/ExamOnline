using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        #region ### sync
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
            var entity = efCore.GetEntity(spec);
            return entity == null ? false : efCore.RemoveAs(entity);
        }

        //public MenuInfo GetEntity(ISpecification<MenuInfo> spec)
        //{
        //    return efCore.GetEntity(spec);
        //}

        //public IEnumerable<MenuInfo> GetEntities(
        //    ISpecification<MenuInfo> spec =null, 
        //    Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null)
        //{
        //    return efCore.GetEntities(spec, include);
        //}

        //public IEnumerable<MenuInfo> Lists(
        //    out int total, 
        //    int? index, 
        //    int? size, 
        //    ISpecification<MenuInfo> spec = null, 
        //    Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null)
        //{
        //    return efCore.Lists(out total, index, size, spec, include);
        //}
        #endregion

        #region ### async
        public async Task<MenuInfo> GetEntityAsync(
            ISpecification<MenuInfo> spec,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null)
        {
            return await efCore.GetEntityAsync(spec);
        }

        public async Task<IEnumerable<MenuInfo>> GetEntitiesAsync(
            ISpecification<MenuInfo> spec,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null)
        {
            return await efCore.GetEntitiesAsync(spec);
        }

        public async Task<object> PageListAsync(
            int? index,
            int? size,
            ISpecification<MenuInfo> spec = null,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null)
        {
            return await efCore.PageListAsync(index, size, spec, include);
        }
        #endregion
    }
}
