using System.Linq;
using Domain.Entities;
using Domain.IComm;
using Domain.IManages;

namespace Domain.Manages
{
    public class ClassManage<T> : IClassManage<T> where T : BaseEntity, IAggregateRoot
    {
        private readonly IEfCoreRepository<T> efCore;

        public ClassManage(IEfCoreRepository<T> ef)
        {
            this.efCore = ef;
        }

        public bool AddOrEdit(T entity)
        {
            if (entity == null)
                return false;
            return entity.ID > 0 ? efCore.InsertEntity(entity) : efCore.UpdateEntity(entity);
        }

        public bool Remove(ISpecification<T> spec)
        {
            var entity = FindBy(spec);
            return entity == null ? false : efCore.RemoveEntity(entity);
        }

        public T FindBy(ISpecification<T> spec)
        {
            return efCore.SingleEntity(spec);
        }

        public IQueryable<T> QuerySet(ISpecification<T> spec)
        {
            return efCore.QueryEntity(spec);
        }
    }
}
