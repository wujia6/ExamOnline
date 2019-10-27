using System.Collections.Generic;
using Domain.Entities.ClassAgg;
using Domain.IComm;

namespace Application.IServices
{
    /// <summary>
    /// 班级应用服务接口
    /// </summary>
    public interface IClassService<TSource, TDest> where TSource : ClassBase where TDest : class
    {
        bool InsertOrUpdate(TDest inf);

        bool Remove(ISpecification<TSource> spec);

        TDest Single(ISpecification<TSource> spec);

        List<TDest> Query(ISpecification<TSource> spec);
    }
}
