using System.Linq;
using Domain.Entities.ClassAgg;
using Domain.IComm;
using Domain.IManages;

namespace Domain.Manages
{
    internal class ClassManage<T> : IClassManage<T> where T : ClassRoot
    {
        private readonly IEfCoreRepository<T> efCore;

        public ClassManage(IEfCoreRepository<T> ef)
        {
            this.efCore = ef;
        }

        public bool InsertOrUpdate(T inf)
        {
            if (inf == null)
                return false;
            return inf.ID > 0 ? efCore.InsertEntity(inf) : efCore.UpdateEntity(inf);
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
