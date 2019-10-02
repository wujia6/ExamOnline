using System.Linq;
using Domain.Entities.QuestionAgg;
using Domain.IComm;

namespace Domain.IManages
{
    public interface IQuestionManage
    {
        bool InsertOrUpdate(QuestionInfo inf);

        bool Remove(ISpecification<QuestionInfo> spec);

        QuestionInfo FindBySpec(ISpecification<QuestionInfo> spec);

        IQueryable<QuestionInfo> QueryBySpec(ISpecification<QuestionInfo> spec);
    }
}
