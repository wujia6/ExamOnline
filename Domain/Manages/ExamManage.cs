using System.Linq;
using Domain.Entities.ExamAgg;
using Domain.IComm;
using Domain.IManages;

namespace Domain.Manages
{
    internal class ExamManage : IExamManage
    {
        private readonly IEfCoreRepository<ExamInfo> efCore;

        public ExamManage(IEfCoreRepository<ExamInfo> ef)
        {
            this.efCore = ef;
        }

        public bool InsertOrUpdate(ExamInfo inf)
        {
            if (inf == null)
                return false;
            return inf.ID == null ? efCore.InsertEntity(inf) : efCore.UpdateEntity(inf);
        }

        public bool Remove(ISpecification<ExamInfo> spec)
        {
            var entity = FindBySpec(spec);
            return entity == null ? false : efCore.RemoveEntity(entity);
        }

        public ExamInfo FindBySpec(ISpecification<ExamInfo> spec)
        {
            return efCore.FindBySpec(spec);
        }

        public IQueryable<ExamInfo> QueryBySpec(ISpecification<ExamInfo> spec)
        {
            return efCore.QueryBySpec(spec);
        }
    }
}
