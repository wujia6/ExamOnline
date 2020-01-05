using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.ExamAgg;
using Domain.IComm;
using Domain.IManages;
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

        public bool AddOrEdit(ExaminationInfo entity)
        {
            if (entity == null)
                return false;
            return entity.ID > 0 ? efCore.ModifyAt(entity) : efCore.AddAt(entity);
        }

        public bool Remove(ISpecification<ExaminationInfo> spec)
        {
            var entity = Single(spec);
            return entity == null ? false : efCore.RemoveAt(entity);
        }

        public ExaminationInfo Single(ISpecification<ExaminationInfo> spec = null,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null)
        {
            return efCore.Single(spec, include);
        }

        public IEnumerable<ExaminationInfo> Lists(ISpecification<ExaminationInfo> spec = null,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null)
        {
            return efCore.Lists(spec, include);
        }
    }
}
