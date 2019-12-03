using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.QuestionAgg;
using Domain.IComm;
using Domain.IManages;
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

        public bool AddOrEdit(QuestionInfo entity)
        {
            if (entity == null)
                return false;
            return entity.ID > 0 ? efCore.AddAt(entity) : efCore.ModifyAt(entity);
        }

        public bool Remove(ISpecification<QuestionInfo> spec)
        {
            var entity = Single(spec);
            return entity == null ? false : efCore.RemoveAt(entity);
        }

        public QuestionInfo Single(ISpecification<QuestionInfo> spec = null,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null)
        {
            return efCore.Single(spec, include);
        }

        public IEnumerable<QuestionInfo> Lists(ISpecification<QuestionInfo> spec = null,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null)
        {
            return efCore.Lists(spec, include);
        }
    }
}
