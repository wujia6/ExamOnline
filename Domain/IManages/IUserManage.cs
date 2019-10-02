using System.Linq;
using Domain.Entities.UserAgg;
using Domain.IComm;

namespace Domain.IManages
{
    public interface IUserManage
    {
        bool InsertOrUpdate(UserInfo inf);

        bool Remove(ISpecification<UserInfo> spec);

        UserInfo FindBySpec(ISpecification<UserInfo> spec);

        IQueryable<UserInfo> QueryBySpec(ISpecification<UserInfo> spec);
    }
}
