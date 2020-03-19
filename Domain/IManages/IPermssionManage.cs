using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Domain.Entities.PermissionAgg;
using Domain.IComm;
using System.Collections.Generic;

namespace Domain.IManages
{
    public interface IPermssionManage
    {
        bool SaveAs(PermissionInfo entity);

        bool EditTo(PermissionInfo entity);

        bool RemoveAt(ISpecification<PermissionInfo> spec);

        Task<PermissionInfo> SingleAsync(ISpecification<PermissionInfo> spec);

        Task<IEnumerable<PermissionInfo>> QueryAsync(ISpecification<PermissionInfo> spec = null);
    }
}
