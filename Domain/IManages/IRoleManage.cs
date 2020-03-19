using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.RoleAgg;
using Domain.IComm;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.IManages
{
    public interface IRoleManage
    {
        bool SaveAs(RoleInfo entity);

        bool EditTo(RoleInfo entity);

        bool RemoveAt(ISpecification<RoleInfo> spec);

        Task<RoleInfo> SingleAsync(
            ISpecification<RoleInfo> spec, 
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null);

        Task<IEnumerable<RoleInfo>> QueryAsync(
            ISpecification<RoleInfo> spec = null,
            Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null);

        //Task<object> QueryAsync(
        //    int index, int size,
        //    ISpecification<RoleInfo> spec = null, 
        //    Func<IQueryable<RoleInfo>, IIncludableQueryable<RoleInfo, object>> include = null);
    }
}
