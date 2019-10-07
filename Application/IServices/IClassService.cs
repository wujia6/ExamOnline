using System.Linq;
using Domain.Entities.ClassAgg;
using Domain.IComm;

namespace Application.IServices
{
    /// <summary>
    /// 班级应用服务接口
    /// </summary>
    public interface IClassService<TSource, TDest> where TSource : ClassRoot where TDest : class
    {
        bool InsertOrUpdate(TDest inf);

        bool Remove(ISpecification<TSource> spec);

        TDest Single(ISpecification<TSource> spec);

        IQueryable<TDest> Query(ISpecification<TSource> spec);
    }
}
