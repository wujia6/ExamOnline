using System.Linq;
using Application.IServices;
using Domain.Entities.ExamAgg;
using Domain.IComm;
using Domain.IManages;
using Infrastructure.Utilities;

namespace Application.Services
{
    internal class ExamService : IExamService
    {
        private readonly IExamManage examManage;
        private readonly IExamDbContext sqlContext;

        public ExamService(IExamManage manage, IExamDbContext context)
        {
            this.examManage = manage;
            this.sqlContext = context;
        }

        public bool InsertOrUpdate(ExamInfo inf)
        {
            if (inf == null)
                return false;
            return examManage.InsertOrUpdate(inf) ? sqlContext.SaveChanges() > 0 : false;
        }

        public bool Remove(ISpecification<ExamInfo> spec)
        {
            return examManage.Remove(spec) ? sqlContext.SaveChanges() > 0 : false;
        }

        public ExamInfo Single(ISpecification<ExamInfo> spec)
        {
            return examManage.FindBySpec(spec);
        }

        public IQueryable<ExamInfo> Query(ISpecification<ExamInfo> spec)
        {
            return examManage.QueryBySpec(spec);
        }
    }
}
