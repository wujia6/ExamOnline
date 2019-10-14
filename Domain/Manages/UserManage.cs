using System.Linq;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Domain.IManages;

namespace Domain.Manages
{
    /// <summary>
    /// 用户领域服务实现类
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    internal class UserManage<T> : IUserManage<T> where T : UserRoot
    {
        private readonly IEfCoreRepository<T> efCore;

        public UserManage(IEfCoreRepository<T> ef)
        {
            this.efCore = ef;
        }

        public bool InsertOrUpdate(T inf)
        {
            if (inf == null)
                return false;
            return inf.ID > 0 ? efCore.UpdateEntity(inf) : efCore.InsertEntity(inf);
        }

        public bool Remove(ISpecification<T> spec)
        {
            var entity = FindBySpec(spec);
            return entity == null ? false : efCore.RemoveEntity(entity);
        }

        public T FindBySpec(ISpecification<T> spec)
        {
            return efCore.FindBySpec(spec);
        }

        public IQueryable<T> QueryBySpec(ISpecification<T> spec)
        {
            return efCore.QueryBySpec(spec);
        }
    }
}
