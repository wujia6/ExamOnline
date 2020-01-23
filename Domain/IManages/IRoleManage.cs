using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.RoleAgg;
using Domain.IComm;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.IManages
{
    public interface IRoleManage
    {
        bool AddOrEdit(RoleInfo entity);

        bool Remove(ISpecification<RoleInfo> spec);

        RoleInfo Single(
            ISpecification<RoleInfo> spec, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null);

        IEnumerable<RoleInfo> Lists(
            ISpecification<RoleInfo> spec = null, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null);

        Task<bool> AddOrEditAsync(RoleInfo entity);

        Task<bool> RemoveAsync(ISpecification<RoleInfo> spec);

        Task<RoleInfo> SingleAsync(
            ISpecification<RoleInfo> spec,
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null);

        Task<PageResult> ListsAsync(
            int? index,
            int? size,
            ISpecification<RoleInfo> spec = null,
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null);
    }
}
