using System.Collections.Generic;
using Application.DTO;
using Application.IServices;
using Domain.Entities.ExamAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Utils;

namespace Application.Services
{
    internal class ExamService : IExamService
    {
        private readonly IExamManage examManage;
        private readonly IExamDbContext examContext;

        public ExamService(IExamManage manage, IExamDbContext context)
        {
            this.examManage = manage;
            this.examContext = context;
        }

        public bool InsertOrUpdate(ExaminationDTO inf)
        {
            if (inf == null)
                return false;
            var entity = inf.MapTo<ExaminationInfo>();
            return examManage.InsertOrUpdate(entity) ? examContext.SaveChanges() > 0 : false;
        }

        public bool Remove(ISpecification<ExaminationInfo> spec)
        {
            return examManage.Remove(spec) ? examContext.SaveChanges() > 0 : false;
        }

        public ExaminationDTO Single(ISpecification<ExaminationInfo> spec)
        {
            return examManage.FindBySpec(spec).MapTo<ExaminationDTO>();
        }

        public List<ExaminationDTO> Query(ISpecification<ExaminationInfo> spec)
        {
            return examManage.QueryBySpec(spec).MapToList<ExaminationDTO>();
        }
    }
}
