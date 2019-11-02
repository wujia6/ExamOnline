using System.Linq;
using Domain.Entities.QuestionAgg;
using Domain.IComm;
using Domain.IManages;

namespace Domain.Manages
{
    public class QuestionManage : IQuestionManage
    {
        private readonly IEfCoreRepository<QuestionInfo> efCore;

        public QuestionManage(IEfCoreRepository<QuestionInfo> ef)
        {
            this.efCore = ef;
        }

        public bool AddOrEdit(QuestionInfo entity)
        {
            if (entity == null)
                return false;
            return entity.ID > 0 ? efCore.InsertEntity(entity) : efCore.UpdateEntity(entity);
        }

        public bool Remove(ISpecification<QuestionInfo> spec)
        {
            var entity = FindBy(spec);
            return entity == null ? false : efCore.RemoveEntity(entity);
        }

        public QuestionInfo FindBy(ISpecification<QuestionInfo> spec)
        {
            return efCore.FindBySpec(spec);
        }

        public IQueryable<QuestionInfo> QuerySet(ISpecification<QuestionInfo> spec)
        {
            return efCore.QueryBySpec(spec);
        }
    }
}
