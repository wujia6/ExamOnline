using System.Linq;
using Domain.Entities.AnwserAgg;
using Domain.IComm;
using Domain.IManages;

namespace Domain.Manages
{
    internal class AnswerManage : IAnswerManage
    {
        private readonly IEfCoreRepository<AnswerInfo> efCore;

        public AnswerManage(IEfCoreRepository<AnswerInfo> ef)
        {
            this.efCore = ef;
        }

        public bool InsertOrUpdate(AnswerInfo inf)
        {
            if (inf == null)
                return false;
            return inf.ID > 0 ? efCore.InsertEntity(inf) : efCore.UpdateEntity(inf);
        }

        public bool Remove(ISpecification<AnswerInfo> spec)
        {
            var entity = FindBySpec(spec);
            return entity == null ? false : efCore.RemoveEntity(entity);
        }

        public AnswerInfo FindBySpec(ISpecification<AnswerInfo> spec)
        {
            return efCore.FindBySpec(spec);
        }

        public IQueryable<AnswerInfo> QueryBySpec(ISpecification<AnswerInfo> spec)
        {
            return efCore.QueryBySpec(spec);
        }
    }
}
