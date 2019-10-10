using System.Linq;
using Application.IServices;
using Domain.Entities.AnwserAgg;
using Domain.IComm;
using Domain.IManages;

namespace Application.Services
{
    internal class AnswerService : IAnswerService
    {
        private readonly IAnswerManage answerManage;
        private readonly IExamDbContext sqlContext;

        public AnswerService(IAnswerManage manage, IExamDbContext context)
        {
            this.answerManage = manage;
            this.sqlContext = context;
        }

        public bool InsertOrUpdate(AnswerInfo inf)
        {
            if (inf == null)
                return false;
            return answerManage.InsertOrUpdate(inf) ? sqlContext.SaveChanges() > 0 : false;
        }

        public bool Remove(ISpecification<AnswerInfo> spec)
        {
            return answerManage.Remove(spec) ? sqlContext.SaveChanges() > 0 : false;
        }

        public AnswerInfo Single(ISpecification<AnswerInfo> spec)
        {
            return answerManage.FindBySpec(spec);
        }

        public IQueryable<AnswerInfo> Query(ISpecification<AnswerInfo> spec)
        {
            return answerManage.QueryBySpec(spec);
        }
    }
}
