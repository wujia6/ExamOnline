using System.Collections.Generic;
using Application.DTO;
using Application.IServices;
using Domain.Entities.ExamAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Utils;

namespace Application.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamManage examManage;
        private readonly IExamDbContext examContext;

        public ExamService(IExamManage manage, IExamDbContext context)
        {
            this.examManage = manage;
            this.examContext = context;
        }

        public bool AddOrEdit(ExaminationDTO model)
        {
            if (model == null)
                return false;
            var entity = model.MapTo<ExaminationInfo>();
            return examManage.AddOrEdit(entity) ? examContext.SaveChanges() > 0 : false;
        }

        public bool Remove(ISpecification<ExaminationInfo> spec)
        {
            return examManage.Remove(spec) ? examContext.SaveChanges() > 0 : false;
        }

        public ExaminationDTO FindBy(ISpecification<ExaminationInfo> spec)
        {
            return examManage.FindBy(spec).MapTo<ExaminationDTO>();
        }

        public List<ExaminationDTO> QuerySet(ISpecification<ExaminationInfo> spec)
        {
            return examManage.QuerySet(spec).MapToList<ExaminationDTO>();
        }
    }
}
