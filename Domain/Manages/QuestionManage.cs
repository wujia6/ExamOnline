using System.Linq;
using Domain.Entities.QuestionAgg;
using Domain.IComm;
using Domain.IManages;

namespace Domain.Manages
{
    internal class QuestionManage : IQuestionManage
    {
        private readonly IEfCoreRepository<QuestionInfo> efCore;

        public QuestionManage(IEfCoreRepository<QuestionInfo> ef)
        {
            this.efCore = ef;
        }

        public bool InsertOrUpdate(QuestionInfo inf)
        {
            if (inf == null)
                return false;
            return inf.ID == null ? efCore.InsertEntity(inf) : efCore.UpdateEntity(inf);
        }

        public bool Remove(ISpecification<QuestionInfo> spec)
        {
            var entity = FindBySpec(spec);
            return entity == null ? false : efCore.RemoveEntity(entity);
        }

        public QuestionInfo FindBySpec(ISpecification<QuestionInfo> spec)
        {
            return efCore.FindBySpec(spec);
        }

        public IQueryable<QuestionInfo> QueryBySpec(ISpecification<QuestionInfo> spec)
        {
            return efCore.QueryBySpec(spec);
        }
    }
}
