using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ExamAgg;
using Domain.IComm;
using Domain.IManages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Manages
{
    public class ExaminationManage : IExaminationManage
    {
        private readonly IEfCoreRepository<ExaminationInfo> efCore;

        public ExaminationManage(IEfCoreRepository<ExaminationInfo> ef)
        {
            this.efCore = ef;
        }

        public bool SaveAs(ExaminationInfo entity)
        {
            return efCore.SaveAs(entity);
        }

        public bool EditTo(ExaminationInfo entity)
        {
            return efCore.EditTo(entity);
        }

        public bool RemoveAt(ISpecification<ExaminationInfo> spec)
        {
            var entity = efCore.EntitySet.FirstOrDefault(spec.Expression);
            return entity == null ? false : efCore.RemoveAt(entity);
        }

        public async Task<ExaminationInfo> SingleAsync(
            ISpecification<ExaminationInfo> spec,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null)
        {
            if(include != null)
                efCore.EntitySet = include(efCore.EntitySet);
            return await efCore.EntitySet.FirstOrDefaultAsync(spec.Expression);
        }

        public async Task<IEnumerable<ExaminationInfo>> QueryAsync(
            ISpecification<ExaminationInfo> spec = null,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null)
        {
            if (include != null)
                efCore.EntitySet = include(efCore.EntitySet);
            if (spec != null)
                efCore.EntitySet = await efCore.EntitySet.WhereAsync(spec.Expression);
            return efCore.EntitySet;
        }

        public async Task<object> QueryAsync(
            int index, int size, 
            ISpecification<ExaminationInfo> spec = null, 
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null)
        {
            if (include != null)
                efCore.EntitySet = include(efCore.EntitySet);
            if (spec != null)
                efCore.EntitySet = efCore.EntitySet.Where(spec.Expression);
            return new
            {
                Total = efCore.EntitySet.Count(),
                Rows = await efCore.EntitySet.Skip((index - 1) * size).Take(size).ToListAsync()
            };
        }
    }
}
