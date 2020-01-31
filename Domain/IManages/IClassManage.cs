using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassAgg;
using Domain.IComm;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.IManages
{
    /// <summary>
    /// 领域服务班级接口
    /// </summary>
    public interface IClassManage
    {
        bool SaveAs(ClassInfo entity);

        bool EditTo(ClassInfo entity);
        
        bool RemoveAt(ISpecification<ClassInfo> spec);
        
        Task<ClassInfo> SingleAsync(
            ISpecification<ClassInfo> spec = null,
            Func<IQueryable<ClassInfo>, IIncludableQueryable<ClassInfo, object>> include = null);

        Task<IEnumerable<ClassInfo>> QueryAsync(
            ISpecification<ClassInfo> spec = null,
            Func<IQueryable<ClassInfo>, IIncludableQueryable<ClassInfo, object>> include = null);

        Task<object> QueryAsync(
            int index, int size,
            ISpecification<ClassInfo> spec = null,
            Func<IQueryable<ClassInfo>, IIncludableQueryable<ClassInfo, object>> include = null);
    }
}
