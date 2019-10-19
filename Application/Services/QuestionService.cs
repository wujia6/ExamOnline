using System.Collections.Generic;
using Application.DTO;
using Application.IServices;
using Domain.Entities.QuestionAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Utils;

namespace Application.Services
{
    internal class QuestionService : IQuestionService
    {
        private readonly IQuestionManage questionManage;
        private readonly IExamDbContext examContext;

        public QuestionService(IQuestionManage manage, IExamDbContext context)
        {
            this.questionManage = manage;
            this.examContext = context;
        }

        public bool InsertOrUpdate(QuestionDTO inf)
        {
            if (inf == null)
                return false;
            var entity = inf.MapTo<QuestionInfo>();
            return questionManage.InsertOrUpdate(entity) ? examContext.SaveChanges() > 0 : false;
        }

        public bool Remove(ISpecification<QuestionInfo> spec)
        {
            return questionManage.Remove(spec) ? examContext.SaveChanges() > 0 : false;
        }

        public QuestionDTO Single(ISpecification<QuestionInfo> spec)
        {
            return questionManage.FindBySpec(spec).MapTo<QuestionDTO>();
        }

        public List<QuestionDTO> Query(ISpecification<QuestionInfo> spec)
        {
            return questionManage.QueryBySpec(spec).MapToList<QuestionDTO>();
        }
    }
}
