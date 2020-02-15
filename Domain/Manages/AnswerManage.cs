using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Domain.Entities.AnwserAgg;
using Domain.IComm;
using Domain.IManages;

namespace Domain.Manages
{
    public class AnswerManage : IAnswerManage
    {
        private readonly IEfCoreRepository<AnswerInfo> efCore;

        public AnswerManage(IEfCoreRepository<AnswerInfo> ef)
        {
            this.efCore = ef;
        }

        public bool SaveAs(AnswerInfo entity)
        {
            return efCore.SaveAs(entity);
        }

        public bool EditTo(AnswerInfo entity)
        {
            return efCore.EditTo(entity);
        }

        public bool RemoveAt(ISpecification<AnswerInfo> spec)
        {
            var entity = efCore.EntitySet.SingleOrDefault(spec.Expression);
            return entity == null ? false : efCore.RemoveAt(entity);
        }

        public async Task<AnswerInfo> SingleAsync(
            ISpecification<AnswerInfo> spec,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null)
        {
            if (include != null)
                efCore.EntitySet = include(efCore.EntitySet);
            return await efCore.EntitySet.FirstOrDefaultAsync(spec.Expression);
        }

        public async Task<IEnumerable<AnswerInfo>> QueryAsync(
            ISpecification<AnswerInfo> spec = null,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null)
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
            ISpecification<AnswerInfo> spec = null,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null)
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
