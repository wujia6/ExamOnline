using System.Linq;
using Application.DTO;
using Application.IServices;
using Domain.Entities.AnwserAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Utils;

namespace Application.Services
{
    internal class AnswerService : IAnswerService
    {
        private readonly IAnswerManage answerManage;
        private readonly IExamDbContext examContext;

        public AnswerService(IAnswerManage manage, IExamDbContext context)
        {
            this.answerManage = manage;
            this.examContext = context;
        }

        public bool InsertOrUpdate(AnswerDTO inf)
        {
            if (inf == null)
                return false;
            var entity = inf.MapTo<AnswerInfo>();
            return answerManage.InsertOrUpdate(entity) ? examContext.SaveChanges() > 0 : false;
        }

        public bool Remove(ISpecification<AnswerInfo> spec)
        {
            return answerManage.Remove(spec) ? examContext.SaveChanges() > 0 : false;
        }

        public AnswerDTO Single(ISpecification<AnswerInfo> spec)
        {
            return answerManage.FindBySpec(spec).MapTo<AnswerDTO>();
        }

        public IQueryable<AnswerDTO> Query(ISpecification<AnswerInfo> spec)
        {
            return answerManage.QueryBySpec(spec).MapToList<AnswerDTO>();
        }
    }
}
