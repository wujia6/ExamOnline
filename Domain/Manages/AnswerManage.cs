using System.Linq;
using Domain.Entities.AnwserAgg;
using Domain.IComm;
using Domain.IManages;

namespace Domain.Manages
{
    public class AnswerManage : IAnswerManage
    {
        private readonly IEfCoreRepository<AnswerInfo> efCore;

        public AnswerManage(IEfCoreRepository<AnswerInfo> ef)
        {
            this.efCore = ef;
        }

        public bool AddOrEdit(AnswerInfo entity)
        {
            if (entity == null)
                return false;
            return entity.ID > 0 ? efCore.InsertEntity(entity) : efCore.UpdateEntity(entity);
        }

        public bool Remove(ISpecification<AnswerInfo> spec)
        {
            var entity = FindBy(spec);
            return entity == null ? false : efCore.RemoveEntity(entity);
        }

        public AnswerInfo FindBy(ISpecification<AnswerInfo> spec)
        {
            return efCore.SingleEntity(spec);
        }

        public IQueryable<AnswerInfo> QuerySet(ISpecification<AnswerInfo> spec)
        {
            return efCore.QueryEntity(spec);
        }
    }
}
