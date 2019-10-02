using System.Linq;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Domain.IManages;

namespace Domain.Manages
{
    internal class UserManage : IUserManage
    {
        private readonly IEfCoreRepository<UserInfo> efCore;

        public UserManage(IEfCoreRepository<UserInfo> ef)
        {
            this.efCore = ef;
        }

        public bool InsertOrUpdate(UserInfo inf)
        {
            if (inf == null)
                return false;
            return inf.ID == null ? efCore.UpdateEntity(inf) : efCore.InsertEntity(inf);
        }

        public bool Remove(ISpecification<UserInfo> spec)
        {
            var entity = FindBySpec(spec);
            return entity == null ? false : efCore.RemoveEntity(entity);
        }

        public UserInfo FindBySpec(ISpecification<UserInfo> spec)
        {
            return efCore.FindBySpec(spec);
        }

        public IQueryable<UserInfo> QueryBySpec(ISpecification<UserInfo> spec)
        {
            return efCore.QueryBySpec(spec);
        }
    }
}
