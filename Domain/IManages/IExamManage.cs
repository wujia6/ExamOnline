using System.Linq;
using Domain.Entities.ExamAgg;
using Domain.IComm;

namespace Domain.IManages
{
    public interface IExamManage
    {
        bool InsertOrUpdate(ExamInfo inf);

        bool Remove(ISpecification<ExamInfo> spec);

        ExamInfo FindBySpec(ISpecification<ExamInfo> spec);

        IQueryable<ExamInfo> QueryBySpec(ISpecification<ExamInfo> spec);
    }
}
