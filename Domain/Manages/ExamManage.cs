using System.Linq;
using Domain.Entities.ExamAgg;
using Domain.IComm;
using Domain.IManages;

namespace Domain.Manages
{
    internal class ExamManage : IExamManage
    {
        private readonly IEfCoreRepository<ExaminationInfo> efCore;

        public ExamManage(IEfCoreRepository<ExaminationInfo> ef)
        {
            this.efCore = ef;
        }

        public bool InsertOrUpdate(ExaminationInfo inf)
        {
            if (inf == null)
                return false;
            return inf.ID > 0 ? efCore.InsertEntity(inf) : efCore.UpdateEntity(inf);
        }

        public bool Remove(ISpecification<ExaminationInfo> spec)
        {
            var entity = FindBySpec(spec);
            return entity == null ? false : efCore.RemoveEntity(entity);
        }

        public ExaminationInfo FindBySpec(ISpecification<ExaminationInfo> spec)
        {
            return efCore.FindBySpec(spec);
        }

        public IQueryable<ExaminationInfo> QueryBySpec(ISpecification<ExaminationInfo> spec)
        {
            return efCore.QueryBySpec(spec);
        }
    }
}
