using System.Linq;
using Domain.Entities.ExamAgg;
using Domain.IComm;
using Domain.IManages;

namespace Domain.Manages
{
    public class ExamManage : IExamManage
    {
        private readonly IEfCoreRepository<ExaminationInfo> efCore;

        public ExamManage(IEfCoreRepository<ExaminationInfo> ef)
        {
            this.efCore = ef;
        }

        public bool AddOrEdit(ExaminationInfo entity)
        {
            if (entity == null)
                return false;
            return entity.ID > 0 ? efCore.UpdateEntity(entity) : efCore.InsertEntity(entity);
        }

        public bool Remove(ISpecification<ExaminationInfo> spec)
        {
            var entity = FindBy(spec);
            return entity == null ? false : efCore.RemoveEntity(entity);
        }

        public ExaminationInfo FindBy(ISpecification<ExaminationInfo> spec)
        {
            return efCore.SingleEntity(spec);
        }

        public IQueryable<ExaminationInfo> QuerySet(ISpecification<ExaminationInfo> spec)
        {
            return efCore.QueryEntity(spec);
        }
    }
}
