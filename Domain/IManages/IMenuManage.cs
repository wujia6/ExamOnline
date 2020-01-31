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
        #region ### functions
        bool SaveAs(MenuInfo entity);

        bool EditTo(MenuInfo entity);

        bool RemoveAt(ISpecification<MenuInfo> spec);

        Task<MenuInfo> SingleAsync(
            ISpecification<MenuInfo> spec,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);

        Task<IEnumerable<MenuInfo>> QueryAsync(
            ISpecification<MenuInfo> spec = null,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);

        Task<object> QueryAsync(
            int index, int size,
            ISpecification<MenuInfo> spec = null,
            Func<IQueryable<MenuInfo>, IIncludableQueryable<MenuInfo, object>> include = null);
        #endregion
    }
}
