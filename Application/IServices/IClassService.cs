using System.Collections.Generic;
using Domain.Entities;
using Domain.IComm;

namespace Application.IServices
{
    /// <summary>
    /// 班级应用服务接口
    /// </summary>
    public interface IClassService<TSource, TDest> 
        where TSource : BaseEntity, IAggregateRoot 
        where TDest : class
    {
        bool AddOrEdit(TDest model);

        bool Remove(ISpecification<TSource> spec);

        TDest FindBy(ISpecification<TSource> spec);

        List<TDest> QuerySet(ISpecification<TSource> spec);
    }
}
