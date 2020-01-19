using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool AddOrEdit(MenuInfo entity)
        {
            return entity.ID > 0 ? efCore.ModifyAt(entity) : efCore.AddAt(entity);
        }

        public bool Remove(ISpecification<MenuInfo> spec)
        {
            var entity = FindBy(spec);
            return entity == null ? false : efCore.RemoveAt(entity);
        }

        public MenuInfo FindBy(ISpecification<MenuInfo> spec)
        {
            return efCore.Single(spec);
        }

        public IEnumerable<MenuInfo> Lists(ISpecification<MenuInfo> spec = null)
        {
            return efCore.Lists(spec);
        }

        public IEnumerable<MenuInfo> Lists(
            out int total, 
            int? pageIndex = 1, 
            int? pageSize = 10, 
            ISpecification<MenuInfo> spec = null, 
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null)
        {
            return efCore.Lists(out total, pageIndex, pageSize, spec, include);
        }
    }
}
