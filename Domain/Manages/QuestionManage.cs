using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.QuestionAgg;
using Domain.IComm;
using Domain.IManages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Manages
{
    public class QuestionManage : IQuestionManage
    {
        private readonly IEfCoreRepository<QuestionInfo> efCore;

        public QuestionManage(IEfCoreRepository<QuestionInfo> ef)
        {
            this.efCore = ef;
        }

        public bool SaveAs(QuestionInfo entity)
        {
            return efCore.SaveAs(entity);
        }

        public bool EditTo(QuestionInfo entity)
        {
            return efCore.EditTo(entity);
        }

        public bool RemoveAt(ISpecification<QuestionInfo> spec)
        {
            var entity = efCore.EntitySet.FirstOrDefault(spec.Expression);
            return entity == null ? false : efCore.RemoveAt(entity);
        }

        public async Task<QuestionInfo> SingleAsync(
            ISpecification<QuestionInfo> spec,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null)
        {
            if (include!=null)
                efCore.EntitySet = include(efCore.EntitySet);
            return await efCore.EntitySet.FirstOrDefaultAsync(spec.Expression);
        }

        public async Task<IEnumerable<QuestionInfo>> QueryAsync(
            ISpecification<QuestionInfo> spec = null,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null)
        {
            if (include!=null)
                efCore.EntitySet = include(efCore.EntitySet);
            if (spec!=null)
                efCore.EntitySet = efCore.EntitySet.Where(spec.Expression);
            return await efCore.EntitySet.ToArrayAsync();
        }

        public async Task<object> QueryAsync(
            int offset, int limit, 
            ISpecification<QuestionInfo> spec = null, 
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null)
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
