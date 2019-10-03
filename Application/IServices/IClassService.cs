using System.Linq;
using Domain.Entities.ClassAgg;
using Domain.IComm;

namespace Application.IServices
{
    /// <summary>
    /// 班级应用服务接口
    /// </summary>
    public interface IClassService<T> where T : ClassRoot
    {
        bool InsertOrUpdate(T inf);

        bool Remove(ISpecification<T> spec);

        T Single(ISpecification<T> spec);

        IQueryable<T> Query(ISpecification<T> spec);
    }
}
