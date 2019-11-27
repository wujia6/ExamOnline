using System.Linq;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Domain.IManages;

namespace Domain.Manages
{
    /// <summary>
    /// 用户领域服务实现类
    /// </summary>
    public class UserManage : IUserManage
    {
        private readonly IEfCoreRepository<UserInfo> efCore;

        public UserManage(IEfCoreRepository<UserInfo> ef)
        {
            this.efCore = ef;
        }

        public UserInfo FindBy(ISpecification<UserInfo> spec)
        {
            return efCore.SingleEntity(spec);
        }

        public bool AddOrEdit(UserInfo entity)
        {
            if (entity == null)
                return false;
            return entity.ID > 0 ? efCore.UpdateEntity(entity) : efCore.InsertEntity(entity);
        }

        public IQueryable<UserInfo> QueryBy(ISpecification<UserInfo> spec)
        {
            return efCore.QueryEntity(spec);
        }

        public bool Remove(ISpecification<UserInfo> spec)
        {
            var entity = FindBy(spec);
            return entity == null ? false : efCore.RemoveEntity(entity);
        }
    }
}
