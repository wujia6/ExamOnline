using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query;
using Domain.IComm;
using Domain.IManages;
using Domain.Entities.ClassAgg;

namespace Domain.Manages
{
    /// <summary>
    /// 班级领域服务实现类
    /// </summary>
    public class ClassManage : IClassManage
    {
        private readonly IEfCoreRepository<ClassInfo> efCore;

        public ClassManage(IEfCoreRepository<ClassInfo> ef)
        {
            this.efCore = ef;
        }

        public bool SaveAs(ClassInfo entity)
        {
            return efCore.SaveAs(entity);
        }

        public bool EditTo(ClassInfo entity)
        {
            return efCore.EditTo(entity);
        }

        public bool RemoveAt(ISpecification<ClassInfo> spec)
        {
            var entity = efCore.EntitySet.SingleOrDefault(spec.Expression);
            return entity == null ? false : efCore.RemoveAt(entity);
        }

        public async Task<ClassInfo> SingleAsync(
            ISpecification<ClassInfo> spec,
            Func<IQueryable<ClassInfo>, IIncludableQueryable<ClassInfo, object>> include = null)
        {
            if (include != null)
                efCore.EntitySet = include(efCore.EntitySet);
            return await efCore.EntitySet.FirstOrDefaultAsync(spec.Expression);
        }

        public async Task<IEnumerable<ClassInfo>> QueryAsync(
            ISpecification<ClassInfo> spec = null,
            Func<IQueryable<ClassInfo>, IIncludableQueryable<ClassInfo, object>> include = null)
        {
            if (include != null)
                efCore.EntitySet = include(efCore.EntitySet);
            if (spec != null)
                efCore.EntitySet = efCore.EntitySet.Where(spec.Expression);
            return await efCore.EntitySet.ToArrayAsync();
        }

        public async Task<object> QueryAsync(
            int offset,
            int limit,
            ISpecification<ClassInfo> spec = null,
            Func<IQueryable<ClassInfo>, IIncludableQueryable<ClassInfo, object>> include = null)
        {
            if (include != null)
                efCore.EntitySet = include(efCore.EntitySet);
            if (spec != null)
                efCore.EntitySet = efCore.EntitySet.Where(spec.Expression);
            return new
            {
                Total = await efCore.EntitySet.CountAsync(),
                Rows = await efCore.EntitySet.Skip(offset).Take(limit).ToListAsync()
            };
        }
    }
}
