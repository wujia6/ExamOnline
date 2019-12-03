using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.AnwserAgg;
using Domain.IComm;
using Domain.IManages;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Manages
{
    public class AnswerManage : IAnswerManage
    {
        private readonly IEfCoreRepository<AnswerInfo> efCore;

        public AnswerManage(IEfCoreRepository<AnswerInfo> ef)
        {
            this.efCore = ef;
        }

        public bool AddOrEdit(AnswerInfo entity)
        {
            if (entity == null)
                return false;
            return entity.ID > 0 ? efCore.AddAt(entity) : efCore.ModifyAt(entity);
        }

        public bool Remove(ISpecification<AnswerInfo> spec)
        {
            var entity = Single(spec);
            return entity == null ? false : efCore.RemoveAt(entity);
        }

        public AnswerInfo Single(ISpecification<AnswerInfo> spec = null,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null)
        {
            return efCore.Single(spec, include);
        }

        public IEnumerable<AnswerInfo> Lists(ISpecification<AnswerInfo> spec = null,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null)
        {
            return efCore.Lists(spec, include);
        }
    }
}
