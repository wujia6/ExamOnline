using System.Linq;
using Application.IServices;
using Domain.Entities.ClassAgg;
using Domain.IComm;
using Domain.IManages;

namespace Application.Services
{
    internal class ClassService<T> : IClassService<T> where T : ClassRoot
    {
        private readonly IClassManage<T> classManage;
        private readonly ISqlContext sqlContext;

        public ClassService(IClassManage<T> manage, ISqlContext context)
        {
            this.classManage = manage;
            this.sqlContext = context;
        }

        public bool InsertOrUpdate(T inf)
        {
            if (inf == null)
                return false;
            return classManage.InsertOrUpdate(inf) ? sqlContext.SaveChanges() > 0 : false;
        }

        public bool Remove(ISpecification<T> spec)
        {
            return classManage.Remove(spec);
        }

        public T Single(ISpecification<T> spec)
        {
            return classManage.FindBySpec(spec);
        }

        public IQueryable<T> Query(ISpecification<T> spec)
        {
            return classManage.QueryBySpec(spec);
        }
    }
}
