using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.MenuAgg;
using Domain.IComm;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.IManages
{
    public interface IMenuManage
    {
        #region ### sync
        bool Save(MenuInfo entity);

        bool Edit(MenuInfo entity);

        bool Remove(ISpecification<MenuInfo> spec);

        //MenuInfo GetEntity(ISpecification<MenuInfo> spec);

        //IEnumerable<MenuInfo> GetEntities(
        //    ISpecification<MenuInfo> spec, 
        //    Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);

        //IEnumerable<MenuInfo> Lists(
        //    out int total, 
        //    int? index, 
        //    int? size,
        //    ISpecification<MenuInfo> spec = null,
        //    Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);
        #endregion

        #region ### async
        Task<MenuInfo> GetEntityAsync(
            ISpecification<MenuInfo> spec,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);

        Task<IEnumerable<MenuInfo>> GetEntitiesAsync(
            ISpecification<MenuInfo> spec = null,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);

        Task<object> PageListAsync(
            int? index,
            int? size,
            ISpecification<MenuInfo> spec = null,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);
        #endregion
    }
}
