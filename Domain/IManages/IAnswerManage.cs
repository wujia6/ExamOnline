using System.Linq;
using Domain.Entities.AnwserAgg;
using Domain.IComm;

namespace Domain.IManages
{
    public interface IAnswerManage
    {
        bool InsertOrUpdate(AnswerInfo inf);

        bool Remove(ISpecification<AnswerInfo> spec);

        AnswerInfo FindBySpec(ISpecification<AnswerInfo> spec);

        IQueryable<AnswerInfo> QueryBySpec(ISpecification<AnswerInfo> spec);
    }
}
