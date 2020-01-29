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

        //MenuInfo Single(ISpecification<MenuInfo> spec);
        
        //IEnumerable<MenuInfo> QuerySet(ISpecification<MenuInfo> spec);

        //IEnumerable<MenuInfo> Lists(
        //    out int total, 
        //    int? index, 
        //    int? size,
        //    ISpecification<MenuInfo> spec = null,
        //    Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);
        #endregion

        #region ### async
        Task<MenuInfo> SingleAsync(
            ISpecification<MenuInfo> spec, 
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);
        
        Task<IEnumerable<MenuInfo>> QuerySetAsync(
            ISpecification<MenuInfo> spec = null, 
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);
        
        Task<object> ListsAsync(
            int? index,
            int? size,
            ISpecification<MenuInfo> spec = null,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);
        #endregion
    }
}
