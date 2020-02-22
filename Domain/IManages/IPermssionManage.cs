using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Domain.Entities.PermissionAgg;
using Domain.IComm;

namespace Domain.IManages
{
    public interface IPermssionManage
    {
        bool SaveAs(PermissionInfo entity);

        bool EditTo(PermissionInfo entity);

        bool RemoveAt(ISpecification<PermissionInfo> spec);

        Task<object> QueryAsync(
            int? offset, int? limit,
            ISpecification<PermissionInfo> spec = null,
            Func<IQueryable<PermissionInfo>, IIncludableQueryable<PermissionInfo, object>> include = null);
    }
}
