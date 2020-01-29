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
            return entity.ID > 0 ? efCore.EditAs(entity) : efCore.SaveAs(entity);
        }

        public bool Remove(ISpecification<ExaminationInfo> spec)
        {
            var entity = Single(spec);
            return entity == null ? false : efCore.RemoveAs(entity);
        }

        public ExaminationInfo Single(ISpecification<ExaminationInfo> spec = null,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null)
        {
            return efCore.GetEntity(spec, include);
        }

        public IEnumerable<ExaminationInfo> Lists(ISpecification<ExaminationInfo> spec = null,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null)
        {
            return efCore.GetEntities(spec, include);
        }
    }
}
