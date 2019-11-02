using System.Collections.Generic;
using Application.DTO;
using Application.IServices;
using Domain.Entities.QuestionAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Utils;

namespace Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionManage questionManage;
        private readonly IExamDbContext examContext;

        public QuestionService(IQuestionManage manage, IExamDbContext context)
        {
            this.questionManage = manage;
            this.examContext = context;
        }

        public bool AddOrEdit(QuestionDTO model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<QuestionInfo>();
            return questionManage.AddOrEdit(entity) ? examContext.SaveChanges() > 0 : false;
        }

        public bool Remove(ISpecification<QuestionInfo> spec)
        {
            return questionManage.Remove(spec) ? examContext.SaveChanges() > 0 : false;
        }

        public QuestionDTO FindBy(ISpecification<QuestionInfo> spec)
        {
            return questionManage.FindBy(spec).MapTo<QuestionDTO>();
        }

        public List<QuestionDTO> QuerySet(ISpecification<QuestionInfo> spec)
        {
            return questionManage.QuerySet(spec).MapToList<QuestionDTO>();
        }
    }
}
