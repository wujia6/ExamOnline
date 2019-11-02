using System.Collections.Generic;
using Application.DTO;
using Application.IServices;
using Domain.Entities.AnwserAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Utils;

namespace Application.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerManage answerManage;
        private readonly IExamDbContext examContext;

        public AnswerService(IAnswerManage manage, IExamDbContext context)
        {
            this.answerManage = manage;
            this.examContext = context;
        }

        public bool AddOrEdit(AnswerDTO model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<AnswerInfo>();
            return answerManage.AddOrEdit(entity) ? examContext.SaveChanges() > 0 : false;
        }

        public bool Remove(ISpecification<AnswerInfo> spec)
        {
            return answerManage.Remove(spec) ? examContext.SaveChanges() > 0 : false;
        }

        public AnswerDTO FindBy(ISpecification<AnswerInfo> spec)
        {
            return answerManage.FindBy(spec).MapTo<AnswerDTO>();
        }

        public List<AnswerDTO> QuerySet(ISpecification<AnswerInfo> spec)
        {
            return answerManage.QuerySet(spec).MapToList<AnswerDTO>();
        }
    }
}
