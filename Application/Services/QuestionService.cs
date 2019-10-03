using System.Linq;
using Application.IServices;
using Domain.Entities.QuestionAgg;
using Domain.IComm;
using Domain.IManages;

namespace Application.Services
{
    internal class QuestionService : IQuestionService
    {
        private readonly IQuestionManage questionManage;
        private readonly ISqlContext sqlContext;

        public QuestionService(IQuestionManage manage, ISqlContext context)
        {
            this.questionManage = manage;
            this.sqlContext = context;
        }

        public bool InsertOrUpdate(QuestionInfo inf)
        {
            if (inf == null)
                return false;
            return questionManage.InsertOrUpdate(inf) ? sqlContext.SaveChanges() > 0 : false;
        }

        public bool Remove(ISpecification<QuestionInfo> spec)
        {
            return questionManage.Remove(spec) ? sqlContext.SaveChanges() > 0 : false;
        }

        public QuestionInfo Single(ISpecification<QuestionInfo> spec)
        {
            return questionManage.FindBySpec(spec);
        }

        public IQueryable<QuestionInfo> Query(ISpecification<QuestionInfo> spec)
        {
            return questionManage.QueryBySpec(spec);
        }
    }
}
